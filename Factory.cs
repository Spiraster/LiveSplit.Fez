using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

[assembly: ComponentFactory(typeof(LiveSplit.Fez.FezFactory))]

namespace LiveSplit.Fez
{
    public class FezFactory : IComponentFactory
    {
        public string ComponentName => "Fez Auto Splitter";
        public string Description => "Autosplitter for Fez v1.12";
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public ComponentCategory Category => ComponentCategory.Control;

        public string UpdateName => ComponentName;
        public string UpdateURL => "https://raw.githubusercontent.com/Spiraster/LiveSplit.Fez/master/";
        public string XMLURL => UpdateURL + "Components/update.LiveSplit.Fez.xml";

        public IComponent Create(LiveSplitState state)
        {
            return new FezComponent(state);
        }
    }
}
