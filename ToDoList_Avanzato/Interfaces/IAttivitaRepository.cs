using ToDoList_Avanzato.Entities;

namespace ToDoList_Avanzato.Interfaces
{
    public interface IAttivitaRepository
    {
        IEnumerable<Attivita> GetAll();
        void Add(Attivita attivita);
        void Remove(int id);
        Attivita GetById(int id);
    }
}



