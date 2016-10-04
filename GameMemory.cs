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
            this.Add(new MemoryWatcher<byte>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x318, 0x50, 0x32C, 0x274)) { Name = "Speedrun" });
            //this.Add(new MemoryWatcher<byte>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x258, 0x78, 0x60, 0x40)) { Name = "Cubes" });
            //this.Add(new MemoryWatcher<byte>(new DeepPointer("Steam2.dll", 0x27B5D4, 0x258, 0x78, 0x60, 0x44)) { Name = "Anticubes" });
        }
    }

    class FezMemory
    {
        private FezData data;
        private InfoList splits;

        private int CurrentLevel = 0;
        private int NextLevel = 0;
        private bool isLoading = false;

        public FezMemory()
        {

        }
        
        public void setPointers()
        {
            data = new FezData();
        }

        public void setSplits(FezSettings settings)
        {
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
            data["Speedrun"].Update(game);

            if (Convert.ToByte(data["Speedrun"].Current) == 1)
                return true;

            return false;
        }

        public bool doReset(Process game)
        {
            data["Speedrun"].Update(game);

            if (Convert.ToByte(data["Speedrun"].Current) == 0)
                return true;

            return false;
        }

        public bool doSplit(Process game)
        {
            data.UpdateAll(game);

            byte _door = Convert.ToByte(data["DoorEnter"].Current);
            if ( _door == 1 && isLoading == false)
            {
                NextLevel = Convert.ToInt32(data["DoorDest"].Current);
                isLoading = true;
            }
            else if (_door == 0 && isLoading == true)
            {
                CurrentLevel = NextLevel;
                isLoading = false;
            }

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
