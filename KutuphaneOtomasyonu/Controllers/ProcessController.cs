using Data;
using Data.Repo;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles = "User")]
    public class ProcessController : Controller
	{
		ProcessRepo p_repo=new ProcessRepo();
		BookRepo b_repo=new BookRepo();
		BookController b_controller = new BookController();
		//ödünç alma işlemleri. type=>
		public IActionResult Index()
		{
			return View();
		}
		/*public IActionResult Odunc(int id)
		{
            var a = User.Claims.Select(claim => new { claim.Value });
            List<string> degerler = new List<string>();

            foreach (var i in a)
            {
                degerler.Add(i.Value);
            }

            Process process =new Process();
			 Book book = b_repo.get(id);

			book.statues = false;
			b_repo.update(book);

			process.BookId = id;
			process.UserId = Int32.Parse(degerler[2]);
            process.type = "odunc";
			process.date = DateTime.Now;
			process.deleted = false;

			p_repo.create(process);
			return RedirectToAction("OduncListByUser","Process");
		}public IActionResult Iade(int id)
		{
             Book book = b_repo.get(id);

			book.statues = true;
			b_repo.update(book);

            var a = User.Claims.Select(claim => new { claim.Value });
            List<string> degerler = new List<string>();

            foreach (var i in a)
            {
                degerler.Add(i.Value);
            }
            Context context=new Context();
			List<Process> values=context.Process.Where(x => x.BookId == id && x.UserId == Int32.Parse(degerler[2]) && x.deleted==false).ToList();
            
			foreach(var value in values)
			{
				value.deleted = true;
				p_repo.update(value);
			}

			Process process =new Process();
			
			process.BookId = id;
			process.UserId = Int32.Parse(degerler[2]);
			process.type = "iade";
            process.date = DateTime.Now;
            process.deleted = true;

            p_repo.create(process);
		
			return RedirectToAction("OduncListByUser","Process");
		}*/
		/*public IActionResult OduncListByUser()
		{
			List<Book> books = new List<Book>();
			List<DateTime> dates = new List<DateTime>();
            //var values = p_repo.listFilter(x => x.UserId == 1);

            var a = User.Claims.Select(claim => new { claim.Value });
            List<string> degerler = new List<string>();

            foreach (var i in a)
            {
                degerler.Add(i.Value);
            }

            Context context = new Context();
            List<Process> values = context.Process.Where(x => x.UserId == Int32.Parse(degerler[2]) && x.deleted == false).ToList();

            foreach (var book in values)
			{
				dates.Add(book.date.Date);
				books.Add(b_repo.get(book.BookId));
			}
			ViewBag.Dates = dates;

			return View(books);
		}*/
		
	}
}
