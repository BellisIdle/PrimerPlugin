﻿using System.Threading;
using System.Xml;
using CommandSystem;
using CommandSystem.Commands.RemoteAdmin;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups.Projectiles;
using Exiled.Events;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using GameCore;
using InventorySystem;
using InventorySystem.Items.Firearms.Utilities;
using InventorySystem.Items.ThrowableProjectiles;
using MapGeneration.Distributors;
using Mirror;
using PluginAPI.Core.Items;
using RemoteAdmin;
using Respawning;
using UnityEngine;
using Cassie = Exiled.API.Features.Cassie;
using Item = Exiled.API.Features.Items.Item;
using Map = Exiled.API.Features.Map;
using Player = Exiled.API.Features.Player;
using Server = Exiled.API.Features.Server;

namespace PluginPrueba_EXILED
{
    public class EventHandlers
    {
        public void OnRoundStarted()
        {
            Cassie.Message("NATO_S");
            Console.AddLog($"Hay {Server.PlayerCount.ToString()} juadores conectados",Color.blue);
        }

        public void OnPlayerDying(DyingEventArgs ev)
        {
            if (ev.Attacker != null)
            {
                ev.Attacker.Broadcast(Plugin.Singleton.Config.BroadcastDuration , Plugin.Singleton.Config.BroadcastMsg);
            }
        }

        public void OnWaitingPlayers()
        {
            Round.IsLocked = true;
            Console.AddLog($"Roundlock activo", Color.blue);
        }
        

        public void OnPlayerShooting(ShootingEventArgs ev)
        {
            var bum = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
            bum.SpawnActive(ev.Player.Position);
            Console.AddLog($"Granada spawned", Color.yellow);
            if (!ev.Player.IsInventoryFull)
            {
                Item.Create(ItemType.KeycardO5).Give(ev.Player);
            }
        }

        public void OnPlayerVerified(VerifiedEventArgs ev)
        {
            if (ev.Player.UserId == [REDACTED])
            {
                Cassie.Message("welcome killer",false, false, false);
                ev.Player.IsGodModeEnabled = true;
                Round.Start();
            }
        }
        
        public void OnSpawningItem(SpawningItemEventArgs ev)
        {
            Cassie.Message("yes",false,false);
        }
    }
}