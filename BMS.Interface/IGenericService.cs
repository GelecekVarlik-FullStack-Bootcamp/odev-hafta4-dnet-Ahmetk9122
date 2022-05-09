using BMS.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Interface
{
    public interface IGenericService<T,TDto> where T :IEntityBase where TDto : IDtoBase
    {
        //apiden bll'a TDto çalışır bll den dataya geçişte t olur.

        //Listeleme
        IResponse<List<TDto>> GetAll();

        //Filtreli Listeleme
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression);

        //Getirme işlemi 
        IResponse<TDto> Find(int id);

        //Kaydetme
        IResponse<TDto> Add(TDto item, bool saveChanges = true);

        //Async Kaydetme
        Task<IResponse<TDto>> AddAsync(TDto item, bool saveChanges = true);

        //Güncelleme
        IResponse<TDto> Update(TDto item, bool saveChanges = true);

        //Async Güncelleme
        Task<IResponse<TDto>> UpdateAsync(TDto item, bool saveChanges = true);

        //Silme
        IResponse<bool> DeleteById(int id, bool saveChanges = true);

        //Async Silme
        Task<IResponse<bool>> DeleteByIdAsync(int id, bool saveChanges = true);

        //IQueryable
        IResponse<IQueryable<TDto>> GetQueryable();

        //Ortak olanlar burada toplanır
        void Save();
    }
}
