using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using Respawning;
using System;

using Player = Exiled.Events.Handlers.Player;

namespace BlacklistSCP
{
    public class Plugin : Plugin<Config>
    {
        public Plugin() 
        { 
        }

        public static Config Instance;

        public override string Name => "BlacklistSCP";
        public override string Prefix => "SCPBL";
        public override string Author => "VALERA771#1471";
        public override Version Version => new Version(1, 0, 1);
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        public override void OnEnabled()
        {
            Player.ChangingRole += OnPlayerChangedRole;

            base.OnEnabled();
        }

        public override void OnDisabled() 
        {
            Player.ChangingRole -= OnPlayerChangedRole;

            base.OnDisabled();
        }


        void OnPlayerChangedRole(ChangingRoleEventArgs ev)
        {
            if (Instance.BlacklistedRoles.Contains(ev.NewRole))
                ev.Player.Role.Set(Instance.SwapRoles.RandomItem(), Exiled.API.Enums.SpawnReason.Respawn, RoleSpawnFlags.All);
        }
    }
}
