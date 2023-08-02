using Data.Repo;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles = "User")]
    public class BookController : Controller
    {
        BookRepo b_repo = new BookRepo();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookListAll()
        {
           var values= b_repo.listAll();
            return View(values);
            }
     
    
       

    }
}
