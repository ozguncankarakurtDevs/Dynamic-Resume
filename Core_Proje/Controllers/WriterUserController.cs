using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WriterUserController : Controller
    {
        WriterUserManager writerUser = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(writerUser.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser writer)
        {
            writerUser.TAdd(writer);
            var values = JsonConvert.SerializeObject(writer);
            return Json(values);
        }
    }
}
