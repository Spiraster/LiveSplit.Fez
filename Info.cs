using System.Collections.Generic;
using System.Linq;

namespace LiveSplit.Fez
{
    public static class DefaultInfo
    {
        public static InfoList BaseSplits = new InfoList
        {
            new Info("Village", new Dictionary<string,int> { { "DoorEnter", 1 }, { "CurrentLevel", 0x45004D }, { "NextLevel", 0x41004E } }),
            new Info("BellTower", new Dictionary<string,int> { { "DoorEnter", 1 }, { "CurrentLevel", 0x570054 }, { "NextLevel", 0x41004E } }),
            new Info("Waterfall", new Dictionary<string,int> { { "GomezState", 0x60 }, { "CurrentLevel", 0x4D0043 } }),
            new Info("Arch", new Dictionary<string,int> { { "GomezState", 0x60 }, { "CurrentLevel", 0x490046 } }),
            new Info("Tree", new Dictionary<string,int> { { "DoorEnter", 1 }, { "CurrentLevel", 0x55005A }, { "NextLevel", 0x55005A } }),
            new Info("ZuRuins", new Dictionary<string,int> { { "GomezState", 0x60 }, { "CurrentLevel", 0x490056 } }),
            new Info("Lighthouse", new Dictionary<string,int> { { "DoorEnter", 1 }, { "CurrentLevel", 0x490050 }, { "NextLevel", 0x45004D } }),
            new Info("End", new Dictionary<string,int> { { "DoorEnter", 1 }, { "CurrentLevel", 0x590050 }, { "NextLevel", 0x490056 } })
        };
    }

    public class Info
    {
        public string Name { get; protected set; }
        public Dictionary<string, int> Triggers { get; private set; }
        public bool isEnabled { get; set; }
        
        public Info() { }

        /// <summary>
        /// For a single-trigger split
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_pointer"></param>
        /// <param name="_condition"></param>
        public Info(string _name, string _pointer, int _value)
        {
            Name = _name;
            Triggers = new Dictionary<string, int> { { _pointer, _value } };
        }

        /// <summary>
        /// For a multiple-trigger split
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_triggers"></param>
        public Info(string _name, Dictionary<string, int> _triggers)
        {
            Name = _name;
            Triggers = _triggers;
        }
        
        /// <summary>
        /// For split settings
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_enabled"></param>
        public Info(string _name, bool _enabled)
        {
            Name = _name;
            isEnabled = _enabled;
        }
    }

    public class InfoList : List<Info>
    {
        public Info this[string name]
        {
            get { return this.First(w => w.Name == name); }
        }
    }
}
