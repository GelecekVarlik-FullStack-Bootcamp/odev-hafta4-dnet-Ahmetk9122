using BMS.Dal.Abstract;
using BMS.Entity.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Dal.Concrete.EntityFramework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        //region blok oluşturmak için kullanılıyor
        #region Variables
        //class içerisindeki değişkenler default olarak private gelir.Classlar internal olarak gelmektedir.
        protected DbContext context;
        protected DbSet<T> dbset;
        #endregion

        #region Constructor
        public GenericRepository(DbContext context)
        {
            //this belirleyici oluyor yani region içerisindeki contexti constructorun sahip olduğu contexten ayırıyor.
            this.context = context;
            this.dbset = this.context.Set<T>();

            //veriyi çek ama değişiklik yapama
            //lazy loading aktif edersek sadee order seçersek order detay da gelir lazy loading =true olursa 
            //this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        #endregion

        #region Methods
        public T Add(T item)
        {
            context.Entry(item).State = EntityState.Added;
            dbset.Add(item);
            return item;
        }
       

        public async Task<T> AddAsync(T item)
        {
            context.Entry(item).State = EntityState.Added;
            //veriyi kaydetmesini bekliyoruz ki item boş dönmesin.
            await dbset.AddAsync(item);
            return item;
        }

        public bool Delete(int id)
        {
            /*
            //id ile silme yapma nesne ile silme yapar
            var item = Find(id);
          if(context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
            */
            return Delete(Find(id));
        }

        public bool Delete(T item)
        {

            if (context.Entry(item).State == EntityState.Detached)
            {
                context.Attach(item);
            }
            return dbset.Remove(item) != null;
        }

        public T Find(int id)
        {
           // return dbset.Find(id.ToString());
            return dbset.Find(id);
        }

        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return dbset.AsQueryable();
        }

        public T Update(T item)
        {
            dbset.Update(item);
            return item;
        }

        #endregion

    }
}
