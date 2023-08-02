using Data;
using Data.Repo;
using Entity.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
	{
		UserRepo u_repo=new UserRepo();
        BookRepo b_repo = new BookRepo();

        public IActionResult Index()
		{
			return View();
		}


        //kullanıcı girişi
        [HttpGet]
		[AllowAnonymous]
        public async Task<IActionResult> Login(User user)
		{
        
           


            Context context = new Context();
            var value = context.User.FirstOrDefault(x => x.email == user.email
             && x.password == user.password);
            if (value != null)
			{
             

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,value.first_name),
            new Claim(ClaimTypes.Surname,value.last_name),
            new Claim(ClaimTypes.Sid,value.id.ToString()),
            new Claim(ClaimTypes.Role,context.Set<Role>().Find(value.roleId).name)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

				if (value.roleId==1)
				{
                    return RedirectToAction("BookListAllByAdmin", "Admin");
                }
				else
				{
                    return RedirectToAction("BookListAll", "Book");
                }
				
            }
			else
			{
                return RedirectToAction("Index", "Home");

            }
              
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
		{
            

                await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");

            
              
        }


        [HttpGet]
		public IActionResult UserProcess()
		{

            var a = User.Claims.Select(claim => new { claim.Value });
            List<string> degerler = new List<string>();

            foreach (var i in a)
            {
                degerler.Add(i.Value);
            }
            

            var value = u_repo.get(Int32.Parse(degerler[2]));
			return View(value);
		}
        [HttpPost]		
        public async Task<IActionResult> UserUpdate(User user)
		{

             await HttpContext.SignOutAsync();

            user.roleId = u_repo.get(user.id).roleId;
			 u_repo.update(user);
			return RedirectToAction("Login", "User", user);
        }
        //[HttpPost]
        public IActionResult UserDelete(int id)
		{
			u_repo.delete(u_repo.get(id));
            
			return RedirectToAction("Logout", "User");
        }


        [HttpGet]
        public IActionResult OduncListByUser()
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
                dates.Add(book.date);
                books.Add(b_repo.get(book.BookId));
            }
            ViewBag.Dates = dates;

            return View(books);
        }
        [HttpGet]
        public IActionResult ProcessListByUser()
        {
            List<String> books = new List<String>();
      
            //var values = p_repo.listFilter(x => x.UserId == 1);

            var a = User.Claims.Select(claim => new { claim.Value });
            List<string> degerler = new List<string>();

            foreach (var i in a)
            {
                degerler.Add(i.Value);
            }

            Context context = new Context();
            List<Process> values = context.Process.Where(x => x.UserId == Int32.Parse(degerler[2]) ).ToList();
            
            foreach (var book in values)
            {

              
                books.Add(b_repo.get(book.BookId).name);
            }
            ViewBag.Books = books;


            return View(values);
        }







    }
}
