using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList.Repository
{
    internal class ImpegniRepository : Interfaces.IAttivita
    {
        public Attivita Entity { get; set; }

        public Dictionary<int, Attivita> EntityDictionary { get ; set; }
      

        public Attivita Create(Attivita entity)
        {
            if (EntityDictionary.Any(d => d.Key == entity.Key))
            {
                throw new ArgumentException($"l'attività {entity.Nome} che vuoi aggiungere è già presente");

            }
            if (entity.Key <= 0) throw new ArgumentException($"Non è possibile aggiungere un attività che ha una chiave minore o uguale a 0");
            EntityDictionary.Add(entity.Key, entity);
            return entity;
        }

        public bool Delete(int key)
        {
            var isRemoved = EntityDictionary.Remove(key);
            if (!isRemoved)
            {
                throw new ArgumentException($"l'attivita che stai rimuovendo con codice {key} non è in elenco");
            }
            return isRemoved;
        }

        public IList<Attivita> GetAll()
        {
            var listAttivita = new List<Attivita>();
            foreach (var entity in EntityDictionary.Values)
            {
                listAttivita.Add(entity);
            }
            return listAttivita;
        }

        public IList<Attivita> GetAllByPrio()
        {
            var listAttivita = new List<Attivita>();
            foreach (var entity in EntityDictionary.Values)
            {
                listAttivita.Add(entity);
            }
            
            return listAttivita.OrderByDescending(a => a.Prio).ToList();
        
    }

        public IList<Attivita> GetByFilter(string queryString)
        {
            var listAttivita = new List<Attivita>();
            foreach (var entity in EntityDictionary.Values)
            {
                listAttivita.Add(entity);
            }
            if (string.IsNullOrEmpty(queryString)) return listAttivita;
            return listAttivita.Where(v => v.Nome.Contains(queryString) || v.Descrizione.Contains(queryString)).ToList();
        }

        public Attivita GetById(int key)
        {
            SetEntity(key);
            return Entity;
        }

        public IList<Attivita> GetByDay(DateTime giorno)
        {
            return EntityDictionary.Values.Where(v => v.DataScadenza == giorno).ToList();
        }

        public IList<Attivita> GetByMonth(int mese, int anno)
        {
            return EntityDictionary.Values.Where(v => v.DataScadenza.Month == mese && v.DataScadenza.Year == anno).ToList();
        }

        public IList<Attivita> GetByYear(int anno)
        {
            return EntityDictionary.Values.Where(v => v.DataScadenza.Year == anno).ToList();
        }

        public IList<Attivita> GetByPeriod(DateTime startDate, DateTime endDate)
        {
            return EntityDictionary.Values.Where(v => v.DataScadenza >= startDate && v.DataScadenza <= endDate).ToList();
        }

            public void Print(string message) => Console.WriteLine(message);

        public void SetEntity(int key)
        {
            var entity = EntityDictionary.FirstOrDefault(d => d.Key == key);
            if (entity.Key == 0) throw new ArgumentNullException($"L' attività con codice {entity.Key} non è stata trovato");
            Entity = entity.Value;
        }

        public Attivita Update(Attivita entity)
        {
            SetEntity(entity.Key);
            EntityDictionary.Remove(Entity.Key);
            Create(entity);

            return entity;

        }
    }
}
