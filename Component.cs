using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LiveSplit.Fez
{
    class FezComponent : LogicComponent
    {
        [DllImport("user32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        public override string ComponentName => "Fez Auto Splitter";

        public FezSettings settings { get; set; }

        private Process game { get; set; }
        private TimerModel timer { get; set; }
        private FezMemory memory { get; set; }

        private Timer processTimer;
        
        public FezComponent(LiveSplitState state)
        {
            settings = new FezSettings();

            timer = new TimerModel() { CurrentState = state };
            timer.CurrentState.OnStart += timer_OnStart;

            processTimer = new Timer() { Interval = 2000, Enabled = true };
            processTimer.Tick += processTimer_OnTick;

            memory = new FezMemory();
            memory.LoadStart += memory_OnLoadStart;
            memory.LoadEnd += memory_OnLoadEnd;
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            if (game != null && !game.HasExited)
            {
                if (state.CurrentPhase == TimerPhase.NotRunning)
                {
                    if (settings.AutoStartTimer)
                    {
                        if (memory.doStart(game))
                        {
                            timer.Start();
                        }
                    }
                }
                else
                {
                    if (settings.AutoReset)
                    {
                        if (memory.doReset(game))
                            timer.Reset();
                    }
                }

                if (state.CurrentPhase == TimerPhase.Running)
                {
                    if (memory.doSplit(game))
                        timer.Split();
                }
            }
            else if (!processTimer.Enabled)
            {
                processTimer.Enabled = true;
            }
        }

        Process getGameProcess()
        {
            Process process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "fez" && !p.HasExited);

            if (process != null)
            {
                memory.setPointers();
                return process;
            }

            return null;
        }

        void timer_OnStart(object sender, EventArgs e)
        {
            timer.InitializeGameTime();
            memory.Initialize(settings);
        }

        void memory_OnLoadStart(object sender, EventArgs e)
        {
            timer.CurrentState.IsGameTimePaused = true;
        }

        void memory_OnLoadEnd(object sender, EventArgs e)
        {
            timer.CurrentState.IsGameTimePaused = false;
        }

        void processTimer_OnTick(object sender, EventArgs e)
        {
            if (game == null || game.HasExited)
            {
                game = getGameProcess();
            }
            else
            {
                processTimer.Enabled = false;
            }
        }

        public override void Dispose()
        {
            timer.CurrentState.OnStart -= timer_OnStart;
            processTimer.Tick -= processTimer_OnTick;
        }

        public override System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        public override System.Windows.Forms.Control GetSettingsControl(UI.LayoutMode mode)
        {
            return settings;
        }

        public override void SetSettings(System.Xml.XmlNode settings)
        {
            this.settings.SetSettings(settings);
        }
    }
}
