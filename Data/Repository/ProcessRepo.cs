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
	public class ProcessRepo : IProcess
	{
		GenericRepo<Process> repo = new GenericRepo<Process>();
		public void create(Process t)
		{
			repo.create(t);
		}

		public void delete(Process t)
		{
			repo.delete(t);
		}

		public Process get(int id)
		{
			return repo.get(id);
		}

        public List<Process> listAll()
        {
			return repo.listAll();
        }

        public List<Process> listFilter(Expression<Func<Process, bool>> filter)
        {
			return repo.listFilter(filter);
        }

        public void update(Process t)
		{
			repo.update(t);
		}
	}
}
