using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        
        public IViewComponentResult Invoke()
        {
            ViewBag.SkillCount = skillManager.TGetList().Count;
            ViewBag.MessageNoRead = messageManager.TGetList().Where(x => x.Status == false).Count();
            ViewBag.MessageYesRead = messageManager.TGetList().Where(x => x.Status == true).Count();
            ViewBag.ExperienceCount = experienceManager.TGetList().Count;
            return View();
        }
    }
}
