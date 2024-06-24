using ToDoList_Avanzato.Entities;
using ToDoList_Avanzato.Interfaces;

namespace ToDoList_Avanzato.Repository
{
    public class AttivitaRepository : IAttivitaRepository
    {
        private List<Attivita> attivitaList;

        public AttivitaRepository()
        {
            attivitaList = new List<Attivita>();
        }

        public void Add(Attivita attivita)
        {
            attivitaList.Add(attivita);
        }

        public void Remove(int id)
        {
            Attivita attivitaDaRimuovere = attivitaList.FirstOrDefault(a => a.Id == id);
            if (attivitaDaRimuovere != null)
            {
                attivitaList.Remove(attivitaDaRimuovere);
            }
        }

        public IEnumerable<Attivita> GetAll()
        {
            return attivitaList;
        }

        public Attivita GetById(int id)
        {
            return attivitaList.FirstOrDefault(a => a.Id == id);
        }
    }
}
