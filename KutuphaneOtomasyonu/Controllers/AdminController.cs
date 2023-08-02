using Data;
using Data.Repo;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        BookRepo b_repo = new BookRepo();
        UserRepo u_repo = new UserRepo();
        ProcessRepo p_repo = new ProcessRepo();
        int bookid;
        public IActionResult AdminDashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserListAll()
        {
            var values = u_repo.listFilter(x=>x.roleId==2);
            return View(values);
        }

        [HttpGet]
        public IActionResult UserAddPage()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public IActionResult UserAdd(User user)
        {
            

           


            user.roleId = 2;
            u_repo.create(user);
            return RedirectToAction("UserListAll", "Admin");
        }
        
       // [HttpPost]
        public IActionResult UserDelete(int id)
        {
            u_repo.delete(u_repo.get(id));
            return RedirectToAction("UserListAll", "Admin");
        }
        //[HttpPost]
        public IActionResult OduncListByUserForAdmin(int userId)
        {
            List<Book> books = new List<Book>();
            List<DateTime> dates = new List<DateTime>();
          

            Context context = new Context();
            List<Process> values = context.Process.Where(x => x.UserId == userId && x.deleted == false).ToList();

            foreach (var book in values)
            {

                dates.Add(book.date);
                books.Add(b_repo.get(book.BookId));
            }
            ViewBag.DatesAdmin = dates;
            

            return View(books);
        }

      //  [HttpPost]
        public IActionResult OduncPage(int bookId)
        {
            TempData["bookId"] = bookId.ToString();
            return View();
        }
        [HttpGet]
        public IActionResult IadePage()
        {
            return View();
        }

        public IActionResult Odunc(int id)
        {
            OduncIslem model = new OduncIslem();
            model.BookId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Odunc(OduncIslem model)
        {

            Process process = new Process();
            Book book = b_repo.get(model.BookId);

            book.statues = false;
            b_repo.update(book);

            process.BookId = model.BookId;
            process.UserId =model.UserId;
            process.type = "odunc";
            process.date = DateTime.Now;
            process.deleted = false;

            p_repo.create(process);
            return RedirectToAction("BookListAllByAdmin", "Admin");
        }
       //[HttpPost]
        public IActionResult Iade(int id)
        {
            
            Book book = b_repo.get(id);

            book.statues = true;
            b_repo.update(book);

           
            Context context = new Context();
            List<Process> values = context.Process.Where(x => x.BookId == id && x.deleted == false).ToList();
            int userId = values.First().UserId;
            foreach (var value in values)
            {
                value.deleted = true;
                p_repo.update(value);
            }

            Process process = new Process();

            process.BookId = id;
            process.UserId = userId;
            process.type = "iade";
            process.date = DateTime.Now;
            process.deleted = true;

            p_repo.create(process);

            return RedirectToAction("IadePage", "Admin");
        }
        [HttpGet]
        public IActionResult BookListAllByAdmin()
        {
            var values = b_repo.listAll();
            return View(values);
        }
       // [HttpPost]
        public IActionResult BookUpdatePage(int id)
        {
            bookid = id;
            var value = b_repo.get(id);
           
            return View(value);
        }
        [HttpPost]
        public IActionResult BookUpdate(Book book)
        {
          

            b_repo.update(book);
            return RedirectToAction("BookListAllByAdmin", "Admin");
        }
        [HttpGet]
        public IActionResult BookAddPage()
        {
            Book book = new Book();
            return View(book);
        }
        [HttpPost]
        public IActionResult BookAdd(Book book)
        {
            b_repo.create(book);
            return RedirectToAction("BookListAllByAdmin", "Admin");
        }
        //[HttpDelete]
        public IActionResult BookDelete(int id)
        {
            b_repo.delete(b_repo.get(id));
            return RedirectToAction("BookListAllByAdmin", "Admin");
        }
    }
}
