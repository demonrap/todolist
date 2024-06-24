using ToDoList.Entities;

namespace ToDoList.Interfaces
{
    public interface IAttivitaRepository : ICrud<Attivita,int>
    {
        void Print(string message);
    }
}
