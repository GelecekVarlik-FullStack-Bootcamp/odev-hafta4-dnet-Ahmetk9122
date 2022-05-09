using BMS.Dal.Abstract;
using BMS.Dal.Concrete.EntityFramework.Repository;
using BMS.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Dal.Concrete.EntityFramework.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
      
        #region Variables
        DbContext context;
        IDbContextTransaction transaction;
        //default false
        bool dispose;
        #endregion

        #region constructor
       
        public UnitofWork(DbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Method
        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            //Çöp toplama (gorbage collection çalıştırır.)
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            dispose = true;
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            //transaction başlatılır
            var _transaction = transaction != null ? transaction : context.Database.BeginTransaction();
            //işlem bitince transactionu öldür.
            using (_transaction)
            {
                try
                {
                    if (context == null)
                    {
                        //mesaj döndürür.
                        throw new ArgumentException("Context is null");
                    }
                    //contexti kaydeder
                    int result = context.SaveChanges();
                    //transaction onaylandığı yerdir.
                    _transaction.Commit();
                    
                    return result;
                }
                catch (Exception ex)
                {
                    //işlemi geri alır
                    transaction.Rollback();
                    //hata döndürür.
                    throw new Exception("Error on save changes", ex);
                }
            }
        }
        #endregion
    }

}
