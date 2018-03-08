using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using NetMud.Authentication;
using NetMud.Backup;
using NetMud.Data.EntityBackingData;
using NetMud.DataAccess;
using NetMud.DataAccess.Cache;
using NetMud.Models.Admin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetMud.Controllers.GameAdmin
{
    public class GameAdminController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public GameAdminController()
        {
        }

        public GameAdminController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        //Also called Dashboard in most of the html
        public ActionResult Index()
        {
            var dashboardModel = new DashboardViewModel();
            dashboardModel.authedUser = UserManager.FindById(User.Identity.GetUserId());

            dashboardModel.SlackUsers = BackingDataCache.GetAll<SlackUser>();
            dashboardModel.Games = BackingDataCache.GetAll<Game>();

            return View(dashboardModel);
        }

        #region Running Data
        public ActionResult BackupWorld()
        {
            BackingData.WriteFullBackup();

            return RedirectToAction("Index", new { Message = "Backup Started" });
        }
        #endregion
    }
}
