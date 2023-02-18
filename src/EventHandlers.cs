using System.Xml;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using InventorySystem.Items.Firearms.Utilities;
using InventorySystem.Items.ThrowableProjectiles;
using MapGeneration.Distributors;
using Cassie = Exiled.API.Features.Cassie;
using Map = Exiled.API.Features.Map;
using Player = Exiled.API.Features.Player;

namespace PluginPrueba_EXILED
{
    public class EventHandlers
    {
        public void OnRoundStarted()
        {
            Cassie.Message("NATO_S");
        }

        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (ev.Attacker != null)
            {
                ev.Attacker.Broadcast(Plugin.Singleton.Config.BroadcastDuration , Plugin.Singleton.Config.BroadcastMsg);
            }
        }
    }
}