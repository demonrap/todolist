using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Generics.Interfaces
{
    public interface ICrud<T>
    {
        T Create(T item);
        T GetById(int id);
        bool Update(T item);
        bool Delete(int id);
        List<T> GetAll();
    }
}

