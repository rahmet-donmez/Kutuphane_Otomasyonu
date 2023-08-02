using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class Context:DbContext
	{
	
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			
		options.UseSqlServer("server=.\\SQLEXPRESS;database=KutuphaneOtomasyonu; integrated security=true;TrustServerCertificate=True; Encrypt=True;");
		
		}
		public DbSet<User> User { get; set; }
		public DbSet<Role> Role { get; set; }
		public DbSet<Book> Book { get; set; }
		public DbSet<Process> Process { get; set; }


	}
}
