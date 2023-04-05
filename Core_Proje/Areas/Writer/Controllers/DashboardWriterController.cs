using BusinessLayer.Concrete;
using Core_Proje.Areas.Writer.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class DashboardWriterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardWriterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            ViewBag.v = values.Name + " " + values.Surname;

            //weather API
            string api = "cd8d257e45e75818a911be0f6c18a73b&";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=mersin&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //Statistics
            ViewBag.v1 = writerMessageManager.TGetList().Where(x => x.Receiver == values.Email).Count();
            ViewBag.v2 = announcementManager.TGetList().Count();
            ViewBag.v3 = _userManager.Users.Count();
            ViewBag.v4 = skillManager.TGetList().Count();
            return View();
        }
    }
}
/*https://api.openweathermap.org/data/2.5/weather?q=mersin&mode=xml&lang=tr&units=metric&appid=cd8d257e45e75818a911be0f6c18a73b&*/