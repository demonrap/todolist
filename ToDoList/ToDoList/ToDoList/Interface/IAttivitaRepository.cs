using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.Interface
{
    internal interface IAttivitaRepository : ICrud<Attivita, int>
    {
    }
}
