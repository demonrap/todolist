using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public abstract class Lista
    {
        public List<string> toDoList = new List<string>();
        public abstract void AggiungiTask();
        public abstract void VisualizzaTask();
        public abstract void RimuoviTask();
        public abstract void RimuoviTutto();
    }
}
