using System;
using Exiled.API.Features;

namespace PluginPrueba_EXILED
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "TheKillerIdle";
        public override string Name { get; } = "Broadcast tonto";
        public override string Prefix { get; } = "plugin1";
        public override Version Version { get; } = new Version(1,1);

        public EventHandlers EventHandlers;
        public static Plugin Singleton;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Player.Dying += EventHandlers.OnPlayerDying;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.OnRoundStarted;
            EventHandlers = null;
            Singleton = null;
            base.OnDisabled();
        }
    }
}