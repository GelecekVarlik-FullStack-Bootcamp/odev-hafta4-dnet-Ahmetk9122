using BMS.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Dal.Abstract
{
    public interface IUnitofWork : IDisposable
    {
        //IDisposable dan kalıtım alıyoruz çünkü garbage collector yeri geldiğinde tetikletebilelim yoksa yoksa bellekte kalabilir ve 
        //şişmeye sebebiyet verebilir.
        //generic method yazılımı
        IGenericRepository<T> GetRepository<T>() where T : EntityBase;
        bool BeginTransaction();
        bool RollBackTransaction();
        int SaveChanges();
    }
}
