using ToDoList.Entities;
using ToDoList.Interfaces;
using ToDoList.Repository;

namespace ToDoList
{
    internal class Program
    {
        internal static IAttivitaRepository attivitaRepository = new AttivitaRepository();
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Inserisci 1 per inserire una nuova attività.");
                Console.WriteLine("Inserisci 2 per osservare tutte le attività.");
                Console.WriteLine("Inserisci 3 per rimuovere un'attività.");
                Console.WriteLine("Inserisci 4 per cambiare lo stato dell'attività.");
                Console.WriteLine("Inserisci 5 per osservare la lista delle attività completate.");
                Console.WriteLine("Inserisci 6 per osservare la lista delle attività da completare.");
                Console.WriteLine("Inserisci 7 per chiudere l'applicazione.");

                bool isRunning = true;
                while (isRunning) 
                { 
                    Console.WriteLine("Inserire un numero per scegliere la funzionalità da svolgere.");
                    var inputMenu = Console.ReadLine();
                    switch (inputMenu)
                    {
                        case "1":
                            Console.WriteLine("Inserire l'attività da aggiungere.");
                            attivitaRepository.Create(new Attivita() { NomeAttivita = Console.ReadLine(),IsCompleted=false });
                            break;
                        case "2":
                            attivitaRepository.GetAll();
                            break;
                        case "3":
                            Console.WriteLine("Inserisci l'id dell'attività da eliminare.");
                            attivitaRepository.Delete(int.Parse(Console.ReadLine()));
                            break;
                        case "4":
                            Console.WriteLine("Inserisci l'id dell'attività completata.");
                            attivitaRepository.ChangeStatus(int.Parse(Console.ReadLine()));
                            break;
                        case "5":
                            attivitaRepository.GetCompletedActivitiesList();
                            break;
                        case "6":
                            attivitaRepository.GetNotCompleteddActivitiesList();
                            break;
                        case "7":
                            Environment.Exit(0);
                            break;
                        default:
                            attivitaRepository.Print("Inserire un numero compreso tra 1 e 4.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                attivitaRepository.Print(ex.Message);
            }
        }
    }
}
