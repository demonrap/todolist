using ToDoList_Avanzato.Entities;
using ToDoList_Avanzato.Management;
using ToDoList_Avanzato.Repository;

namespace ToDoList_Avanzato
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new AttivitaRepository();

            var attivita1 = new Attivita { Id = 1, Descrizione = "Comprare il latte" };
            var attivita2 = new Attivita { Id = 2, Descrizione = "Studiare" };

            repository.Add(attivita1);
            repository.Add(attivita2);

            var gestore = new AttivitaManager(repository);

            gestore.Esegui();
        }
    }
}
