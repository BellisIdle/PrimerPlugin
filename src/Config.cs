using Exiled.API.Interfaces;

namespace PluginPrueba_EXILED
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public ushort BroadcastDuration { get; set; } = 5;
        public string BroadcastMsg { get; set; } = "<color=red>ASESINOOOO</color>";
    }
}