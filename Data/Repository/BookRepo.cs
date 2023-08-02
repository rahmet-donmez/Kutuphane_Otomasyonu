using Data.Abstract;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
	public class BookRepo : IBook
	{
		GenericRepo<Book> repo=new GenericRepo<Book>();
		public void create(Book t)
		{
			repo.create(t);
		}

		public void delete(Book t)
		{
			repo.delete(t);
		}

		public Book get(int id)
		{
			return repo.get(id);
		}

        public List<Book>listAll()
        {
			return repo.listAll();
        }
        public List<Book> listFilter(Expression<Func<Book, bool>> filter)
        {
            return repo.listFilter(filter);
        }

        public List<Book> listFilter()
        {
            throw new NotImplementedException();
        }

        public void update(Book t)
		{
			repo.update(t);
		}
	}
}
