using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Interfaces
{
    /// <summary>Interfaccia che rappresenta la funzionalità di un elemento nella lista.</summary>
    public interface IActivity
    {
        public string GetMessage();

        public void SetMessage(string message);
    }
}
