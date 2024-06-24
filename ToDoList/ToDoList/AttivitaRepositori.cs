using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Generics.Entities;
using ToDoList.Generics.Interfaces;

namespace ToDoList.Generics.Repository
{
    public class AttivitaRepository : ICrud<Attivita>
    {
        private List<Attivita> attivitaList = new List<Attivita>();
        private int nextKey = 1;

        public Attivita Create(Attivita item)
        {
            item.Key = nextKey++;
            attivitaList.Add(item);
            return item;
        }

        public Attivita GetById(int key)
        {
            return attivitaList.FirstOrDefault(a => a.Key == key);
        }

        public bool Update(Attivita item)
        {
            var existingAttivita = GetById(item.Key);
            if (existingAttivita != null)
            {
                existingAttivita.Descrizione = item.Descrizione;
                return true;
            }
            return false;
        }

        public bool Delete(int key)
        {
            var attivita = GetById(key);
            if (attivita == null)
                return false;

            attivitaList.Remove(attivita);
            return true;
        }

        public List<Attivita> GetAll()
        {
            return attivitaList;
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
