using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interfaces;

namespace ToDoList
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly List<ToDoItem> _toDoList = new List<ToDoItem>();
        private int _nextId = 1;

        public void Add(ToDoItem item)
        {
            item.Id = _nextId++;
            _toDoList.Add(item);
        }

        public bool Remove(int id)
        {
            var item = _toDoList.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                _toDoList.Remove(item);
                return true;
            }
            return false;
        }

        public List<ToDoItem> GetAll()
        {
            return _toDoList.ToList();
        }
    }
}
