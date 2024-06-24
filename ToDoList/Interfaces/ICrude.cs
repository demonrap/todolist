using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Interfaces
{
    internal interface ICrude<TEntity, TKey>
    {
        TEntity Entity { get; }
        Dictionary<TKey, TEntity> EntityDictionary { get; set; }
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TKey key);
        TEntity GetById(TKey key);
        void Print(string message); 
        void SetEntity(TKey key);
        IList<TEntity> GetByDay(DateTime data);
        IList<TEntity> GetByMonth(int mese,int anno);
        IList<TEntity> GetByYear(int anno);
        IList<TEntity> GetByPeriod(DateTime datainizio, DateTime datafine);
        IList<TEntity> GetByFilter(string queryString);
        IList<TEntity> GetAllByPrio();
        IList<TEntity> GetAll();
    }
}
