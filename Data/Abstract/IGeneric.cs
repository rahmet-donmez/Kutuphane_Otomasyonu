using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
	public interface IGeneric<T> where T:class
	{
		public void create(T t);
		public void update(T t);
		public void delete(T t);
		public T get(int id);
		public List<T> listAll();
		public List<T> listFilter(Expression<Func<T, bool>> filter);

	}
}
