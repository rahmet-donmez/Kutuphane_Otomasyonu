using System.ComponentModel.DataAnnotations;
namespace Entity.Models
{
	public class User
	{
		[Key]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
       // public string? last_name { get; set; } //şeklinde bir tanımlama last_name değişkeninin boş geçilebileceğini belirtir
        public string email { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
        public Role role { get; set; }
        public List<Process> processes { get; set; }


	}
}
