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
	public class UserRepo:IUser
	{
		GenericRepo<User> repo = new GenericRepo<User>();
		public void create(User t)
		{
			repo.create(t);
		}

		public void delete(User t)
		{
			repo.delete(t);
		}

		public User get(int id)
		{
			return repo.get(id);
		}

        public List<User> listAll()
        {
			return repo.listAll();
        }

      

        public List<User> listFilter(Expression<Func<User, bool>> filter)
        {
            return repo.listFilter(filter);
        }

        public void update(User t)
		{
			repo.update(t);
		}
	}
}
