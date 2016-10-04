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
        private TimerModel model { get; set; }
        private FezMemory memory { get; set; }

        private Timer processTimer;
        
        public FezComponent(LiveSplitState state)
        {
            settings = new FezSettings();

            model = new TimerModel() { CurrentState = state };
            model.CurrentState.OnStart += timer_OnStart;

            processTimer = new Timer() { Interval = 2000, Enabled = true };
            processTimer.Tick += processTimer_OnTick;

            memory = new FezMemory();
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
                            model.Start();
                        }
                    }
                }
                else
                {
                    if (settings.AutoReset)
                    {
                        if (memory.doReset(game))
                            model.Reset();
                    }
                }

                if (state.CurrentPhase == TimerPhase.Running)
                {
                    if (memory.doSplit(game))
                        model.Split();
                }
            }
            else if (!processTimer.Enabled)
            {
                processTimer.Enabled = true;
            }
        }

        Process getGameProcess()
        {
            Process process = Process.GetProcesses().FirstOrDefault(p => p.ProcessName.ToLower() == "FEZ" && !p.HasExited);

            if (process != null)
            {
                memory.setPointers();
                return process;
            }

            return null;
        }

        void timer_OnStart(object sender, EventArgs e)
        {
            if (game != null && !game.HasExited)
            {
                memory.setSplits(settings);
            }
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
            model.CurrentState.OnStart -= timer_OnStart;
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
