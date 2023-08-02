using System.ComponentModel.DataAnnotations;
namespace Entity.Models
{
	public class Process
	{
		[Key]
		public int id { get; set; }
        public string type { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public bool deleted { get; set; }
        public int BookId { get; set; }
        public Book book { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
	}
}
