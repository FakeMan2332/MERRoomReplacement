﻿using System.Linq;
using Exiled.API.Features;
using HarmonyLib;
using MERRoomReplacement.Events.Handlers;
using MERRoomReplacement.Events.Interfaces;
using MERRoomReplacement.Features.Configuration;
using MERRoomReplacement.Patches;
using PlayerRoles.RoleAssign;
using Version = System.Version;

namespace MERRoomReplacement
{
    public class MERRoomReplacement : Plugin<Config>
    {
        private IEventHandler _replacementHandler;

        private Harmony _harmony;
            
        public override string Name => "MERRoomReplacement";
        
        public override string Author => "FakeMan";

        public override string Prefix => "room_replacement";

        public override Version Version => new(1, 2, 0);
        
        public override void OnEnabled()
        {
            base.OnEnabled();

            _replacementHandler = new ReplacementHandler(
                Config.ReplacementOptions.Where(x => x.IsEnabled),
                Config.Scp079ShouldReplaced);

            _replacementHandler.SubscribeEvents();

            if (Config.Scp079ShouldReplaced) 
                return;
            
            _harmony = new Harmony("fakeman.merroomreplacement.patcher");

            RemoveScp079FromSpawnQueue.PatchSpawnQueue(_harmony);
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            
            _replacementHandler?.UnsubscribeEvents();
            _harmony?.UnpatchAll(_harmony.Id);
        }
    }
}