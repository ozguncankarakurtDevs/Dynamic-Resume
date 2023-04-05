using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.PortfoliosCount = portfolioManager.TGetList().Count;
            ViewBag.MessagesCount = messageManager.TGetList().Count;
            ViewBag.ServicesCount = serviceManager.TGetList().Count;
            return View();
        }
    }
}
