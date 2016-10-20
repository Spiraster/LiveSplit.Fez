using LiveSplit.ComponentUtil;
using System.Diagnostics;
using System.Windows.Forms;
using System;

namespace LiveSplit.Fez
{
    class FezData : MemoryWatcherList
    {
        public FezData()
        {
            this.Add(new MemoryWatcher<int>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x258, 0x88, 0x32C, 0x8)) { Name = "DoorDest" });
            this.Add(new MemoryWatcher<byte>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x258, 0x88, 0x39B)) { Name = "DoorEnter" });
            this.Add(new MemoryWatcher<byte>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x258, 0x88, 0x368)) { Name = "GomezState" });

            this.Add(new MemoryWatcher<byte>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x358, 0x8, 0x32C, 0x274)) { Name = "SpeedrunBool" });

            this.Add(new MemoryWatcher<byte>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x258, 0x3B8, 0xF8, 0x2C, 0x14)) { Name = "TimerBool" });
            //this.Add(new MemoryWatcher<long>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x258, 0x3B8, 0xF8, 0x2C, 0x4)) { Name = "TimerValue" });
        }
    }

    class FezMemory
    {
        private FezData data;
        private InfoList splits;

        private int CurrentLevel;
        private int NextLevel;
        private bool isLoading;
        private bool inDoor;

        public event EventHandler LoadStart;
        public event EventHandler LoadEnd;

        public FezMemory()
        {

        }
        
        public void setPointers()
        {
            data = new FezData();
        }

        public void Initialize(FezSettings settings)
        {
            CurrentLevel = 0;
            NextLevel = 0;
            isLoading = false;
            inDoor = false;

            //set splits
            splits = new InfoList();
            splits.AddRange(DefaultInfo.BaseSplits);

            foreach (var _setting in settings.CheckedSplits)
            {
                if (!_setting.isEnabled)
                    splits.Remove(splits[_setting.Name]);
            }
        }

        public bool doStart(Process game)
        {
            data["TimerBool"].Update(game);

            if (Convert.ToByte(data["TimerBool"].Current) == 1)
                return true;

            return false;
        }

        public bool doReset(Process game)
        {
            data["SpeedrunBool"].Update(game);

            if (Convert.ToByte(data["SpeedrunBool"].Current) == 0)
                return true;

            return false;
        }

        public bool doSplit(Process game)
        {
            data.UpdateAll(game);
            
            //check for loading
            byte _load = Convert.ToByte(data["TimerBool"].Current);
            if (_load == 0 && isLoading == false)
            {
                LoadStart?.Invoke(this, EventArgs.Empty);
                isLoading = true;
            }
            else if (_load == 1 && isLoading == true)
            {
                LoadEnd?.Invoke(this, EventArgs.Empty);
                isLoading = false;
            }
            
            //check for update to room
            byte _door = Convert.ToByte(data["DoorEnter"].Current);
            if ( _door == 1 && inDoor == false)
            {
                NextLevel = Convert.ToInt32(data["DoorDest"].Current);
                inDoor = true;
            }
            else if (_door == 0 && inDoor == true)
            {
                CurrentLevel = NextLevel;
                inDoor = false;
            }

            //check for splits
            foreach (var _split in splits)
            {
                int count = 0;
                foreach (var _trigger in _split.Triggers)
                {
                    if (_trigger.Key == "CurrentLevel")
                    {
                        if (CurrentLevel == _trigger.Value)
                            count++;
                    }
                    else if(_trigger.Key == "NextLevel")
                    {
                        if (NextLevel == _trigger.Value)
                            count++;
                    }
                    else
                    {
                        int _int = Convert.ToInt32(data[_trigger.Key].Current);

                        if (_int == _trigger.Value)
                            count++;
                    }
                }

                if (count == _split.Triggers.Count)
                {
                    splits.Remove(_split);
                    return true;
                }
            }
            
            return false;
        }
    }
}
