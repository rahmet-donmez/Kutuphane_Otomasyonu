using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public class GenericRepo<T> : IGeneric<T> where T : class
    {
        
        public void create(T t)
        {
            using var context = new Context();
            context.Add(t);
            context.SaveChanges();

        }
        public void update(T t)
        {
            using var context = new Context();
            context.Update(t);
            context.SaveChanges();
        }
        public void delete(T t)
        {
            using var context = new Context();
            context.Remove(t);
            context.SaveChanges();

        }
        public T get(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> listAll()
        {
            using var _context = new Context();
            return _context.Set<T>().ToList();
        }

        public List<T> listFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new Context();

            return context.Set<T>().Where(filter).ToList();
        }
    }
}
