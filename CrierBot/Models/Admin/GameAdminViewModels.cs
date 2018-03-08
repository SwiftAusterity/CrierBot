using NetMud.Authentication;
using NetMud.DataStructure.Base.Usage;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NetMud.Models.Admin
{
    public class DashboardViewModel : BaseViewModel
    {
        public ApplicationUser authedUser { get; set; }

        public DashboardViewModel()
        {
            SlackUsers = Enumerable.Empty<ISlackUser>();
            Games = Enumerable.Empty<IGame>();
        }

        //Backing Data
        public IEnumerable<ISlackUser> SlackUsers { get; set; }
        public IEnumerable<IGame> Games { get; set; }

        //Running Data
        public Dictionary<string, CancellationTokenSource> LiveTaskTokens { get; set; }
    }
}