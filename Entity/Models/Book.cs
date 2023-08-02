

using System.ComponentModel.DataAnnotations;

namespace Entity.Models
{
	public class Book
	{
		[Key]
		public int id { get; set; }
		public string name { get; set; }
		public bool statues { get; set; }
		public List<Process> processes;





	}
}
