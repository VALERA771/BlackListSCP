using Exiled.API.Features;
using MEC;
using System;

using Server = Exiled.Events.Handlers.Server;

namespace BlacklistSCP
{
    public class Plugin : Plugin<Config>
    {
        public Plugin() 
        { 
        }

        public Plugin Instance => _singleton;
        private Plugin _singleton;

        public override string Name => base.Name;
        public override string Prefix => base.Prefix;
        public override string Author => base.Author;
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        public override void OnEnabled()
        {
            Server.RoundStarted += OnRoundStarted;

            _singleton = this;

            base.OnEnabled();
        }

        public override void OnDisabled() 
        {
            Server.RoundStarted -= OnRoundStarted;

            _singleton = null;

            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
        }


        void OnRoundStarted()
        {
            Timing.CallDelayed(0.5f, () =>
            {
                foreach (Player player in Player.List)
                {
                    if (Instance.Config.BlacklistedRoles.Contains(player.Role.Type))
                    {
                        player.Role.Set(Instance.Config.SwapRoles.RandomItem());
                    }
                }
            });
        }
    }
}
