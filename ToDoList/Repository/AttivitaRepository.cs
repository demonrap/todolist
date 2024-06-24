using ToDoList.Entities;
using ToDoList.Interfaces;

namespace ToDoList.Repository
{
    public class AttivitaRepository : IAttivitaRepository
    {
        public Attivita? Entity { get; set; }
        public Dictionary<int, Attivita> EntityDictionary { get; set; } = new Dictionary<int, Attivita>();

        public void ChangeStatus(int key)
        {
            var oldEntity = EntityDictionary.FirstOrDefault(d => d.Key == key);
            if (!EntityDictionary.TryGetValue(key, out var entityForCheck))
            {
                throw new ArgumentException($"Non sono state trovate attività da modificare con chiave : {key}\n");
            }
            oldEntity.Value.IsCompleted = true;
            if(oldEntity.Value.IsCompleted)
            {
                Print($"La seguente attività è stata completata: {oldEntity.Value.NomeAttivita}\n");
            }
        }
        public void Print(string message) => Console.WriteLine(message);
        #region Metodi CRUD
        public void Create(Attivita entity)
        {
            if (EntityDictionary.Any(a => a.Key == entity.Key))
            {
                throw new ArgumentException($"L'attività {entity.NomeAttivita} è stata già aggiunta.\n");
            }
            var keysList = new List<int>();
            if (EntityDictionary.Keys.Count == 0) EntityDictionary.Add(0, null);
            foreach (var k in EntityDictionary.Keys)
            {
                keysList.Add(k);
            }
            var lastKey = keysList.Max();
            var filters = EntityDictionary.Where(x => x.Value != null).Select(x => x.Value).ToList();
            bool exit = true;
            foreach (var entityForCheck in filters)
            {
                if (filters.Last().NomeAttivita.ToLower().Equals(entity.NomeAttivita.ToLower()))
                {
                    Console.WriteLine("Non puoi inserire la stessa attività due volte di fila.\n");
                    exit = false;
                    break; 
                }
            }
            if (exit)
            {
                EntityDictionary.Add(lastKey + 1, entity);
                Console.WriteLine("Attività aggiunta correttamente.\n");
            }
        }
        public bool Delete(int key)
        {
            var isRemoved = EntityDictionary.Remove(key);
            if (!isRemoved)
            {
                throw new ArgumentException($"L'attività che stai rimuovendo con indice {key} non è in elenco");
            }
            return isRemoved;
        }
        public void GetAll()
        {
            Print("Le attività presenti sono:");
            foreach (var entity in EntityDictionary)
            {
                if (entity.Value == null) continue;
                
                Console.Write($"{entity.Key}. {entity.Value.NomeAttivita} = ");
                if (entity.Value.IsCompleted) { Console.WriteLine("Attività svolta"); }
                else { Console.WriteLine("Attività da svolgere"); }
            }
            if (EntityDictionary.Keys.Count == 0) Print("Non sono ancora presenti attività");

        }
        public void Update(Attivita entity, int key)
        {
            var oldEntity = EntityDictionary.FirstOrDefault(d => d.Key == key);
            if (!EntityDictionary.TryGetValue(key, out var entityForCheck))
            {
                throw new ArgumentException($"Non sono state trovate attività da modificare con chiave : {key}\n");
            }
            EntityDictionary.Remove(oldEntity.Key);
            EntityDictionary.Add(oldEntity.Key, entity);
            Print($"La nuova attività modificata è {entity.NomeAttivita} invece di {oldEntity.Value.NomeAttivita}");
        }
        public void GetCompletedActivitiesList()
        {
            if (EntityDictionary.Count == 0) Print("La tua lista di attività completata è vuota, inserisci nuove attività. \n");
            foreach (var entity in EntityDictionary)
            {
                if(entity.Value == null) { continue; }
                if (entity.Value.IsCompleted) Console.WriteLine($"{entity.Key}. {entity.Value.NomeAttivita}");
            }
        }
        public void GetNotCompleteddActivitiesList()
        {
            if (EntityDictionary.Count == 0) Print("Hai completato tutte le tue attività. \n");
            foreach (var entity in EntityDictionary)
            {
                if (entity.Value == null) { continue; }
                if (!entity.Value.IsCompleted) Console.WriteLine($"{entity.Key}. {entity.Value.NomeAttivita}");
            }
        }
        #endregion
    }
}
