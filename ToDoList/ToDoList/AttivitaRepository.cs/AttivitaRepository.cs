using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Generics.Entities;
using ToDoList.Generics.Interfaces;

namespace ToDoList.Generics.Repository
{
    public class AttivitaRepository : IAttivitaRepository
    {
        private List<Attivita> attivitaList = new List<Attivita>();
        private int nextKey = 1;

        public Attivita Create(Attivita item)
        {
            item.Key = nextKey++;
            attivitaList.Add(item);
            return item;
        }

        public bool Delete(int key)
        {
            var attivita = attivitaList.FirstOrDefault(a => a.Key == key);
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

    internal class Attivita
    {
    }

    public interface IAttivitaRepository
    {
    }
}
