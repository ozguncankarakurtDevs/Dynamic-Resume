using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> _userManager;

        public AdminNavbarMessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            var filter = "admin@gmail.com";
            var list = (from x in context.Users
                        join y in context.WriterMessages
                        on x.Email equals y.Sender
                        where y.Receiver == filter 
                        select new WriterMessageImageUrl
                        {
                            ImageUrl = x.ImageUrl,
                            Date = y.Date,
                            SenderName = y.SenderName,
                            MessageContent = y.MessageContent,
                            Id = y.WriterMessageID
                        }).OrderByDescending(x => x.Id).Take(3).ToList();
            return View(list);
        }
    }
}
