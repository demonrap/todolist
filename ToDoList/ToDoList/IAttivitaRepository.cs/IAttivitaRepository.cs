using System;
using System.Collections.Generic;
using ToDoList.Generics.Entities;

namespace ToDoList.Generics.Interfaces
{
    public interface IAttivitaRepository
    {
        Attivita Create(Attivita item);
        bool Delete(int key);
        List<Attivita> GetAll();
        void Print(string message);
    }
}

