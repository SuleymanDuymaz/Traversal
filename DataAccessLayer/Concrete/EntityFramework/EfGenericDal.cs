using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfGenericDal<T> : IGenericDal<T> where T : class
    {
        public void Add(T t)
        {
            using var context = new Context();  
            context.Add(t);
            context.SaveChanges();
        }

        public void Delete(T t)
        {
            using var context = new Context();
            context.Remove(t);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            using var context = new Context();
            return context.Set<T>().ToList().AsQueryable();

        }

        public IQueryable<T> List(Expression<Func<T, bool>> filter)
        {
            using var context = new Context();
            return context.Set<T>().Where(filter).ToList().AsQueryable();
        }

        public void Update(T t)
        {
            using var context = new Context();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
