using Exiled.API.Interfaces;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacklistSCP
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("List of blacklisted roles")]
        public List<RoleTypeId> BlacklistedRoles { get; set; } = new List<RoleTypeId>()
        {
            RoleTypeId.Scp049,
            RoleTypeId.Scp173,
            RoleTypeId.Scp096,
            RoleTypeId.Scp079,
            RoleTypeId.Scp939,
            RoleTypeId.Scp106
        };

        [Description("List or roles for which players with blaclisted role can be swaped")]
        public List<RoleTypeId> SwapRoles { get; set; } = new List<RoleTypeId>()
        {
            RoleTypeId.ClassD,
            RoleTypeId.Spectator
        };
    }
}
