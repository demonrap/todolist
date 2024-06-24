using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Interfaces;

namespace TodoList.Repository
{
    /// <summary>Implementazione di un elemento della lista.</summary>
    public class Activity : IActivity
    {
        private string Message = "";

        public string GetMessage() { return Message; }

        public void SetMessage(string message)
        {
            Message = message;
        }
    }
}
