

using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
	public class Role

	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
        public List<User> Users{ get; set; }





    }
}
