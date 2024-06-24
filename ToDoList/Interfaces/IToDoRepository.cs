using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Interfaces
{
    public interface IToDoRepository
    {
        void Add(ToDoItem item);
        bool Remove(int id);
        List<ToDoItem> GetAll();

    }
}
