using ToDoList.Interfaces;

namespace ToDoList
{
    internal class Program
    {
        
            static void Main(string[] args)
            {
                IToDoRepository repository = new ToDoRepository();
                bool running = true;

                while (running)
                {
                    Console.WriteLine("Inserisci un comando (1: Aggiungi, 2: Visualizza, 3: Rimuovi, 4: Esci):");
                    string command = Console.ReadLine();

                    if (command == "1")
                    {
                        AggiungiAttivita(repository);
                    }
                    else if (command == "2")
                    {
                        VisualizzaAttivita(repository);
                    }
                    else if (command == "3")
                    {
                        RimuoviAttivita(repository);
                    }
                    else if (command == "4")
                    {
                        Esci();
                        running = false;
                    }
                    else
                    {
                        ComandoNonValido();
                    }
                }
            }

            static void AggiungiAttivita(IToDoRepository repository)
            {
                Console.WriteLine("Inserisci l'attività da aggiungere:");
                string descrizione = Console.ReadLine();
                var nuovaAttivita = new ToDoItem { Description = descrizione };
                repository.Add(nuovaAttivita);
                Console.WriteLine($"L'attività \"{descrizione}\" è stata aggiunta alla lista.");
            }

            static void VisualizzaAttivita(IToDoRepository repository)
            {
                Console.WriteLine("Attività nella lista:");
                var lista = repository.GetAll();
                foreach (var attivita in lista)
                {
                    Console.WriteLine($"{attivita.Id}. {attivita.Description}");
                }
            }

            static void RimuoviAttivita(IToDoRepository repository)
            {
                Console.WriteLine("Inserisci il numero dell'attività da rimuovere:");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    bool rimosso = repository.Remove(id);
                    if (rimosso)
                    {
                        Console.WriteLine($"L'attività con ID {id} è stata rimossa dalla lista.");
                    }
                    else
                    {
                        Console.WriteLine("ID non trovato. Riprova.");
                    }
                }
                else
                {
                    Console.WriteLine("Numero non valido. Riprova.");
                }
            }

            static void Esci()
            {
                Console.WriteLine("Grazie per aver usato la To-Do List. Arrivederci!");
            }

            static void ComandoNonValido()
            {
                Console.WriteLine("Comando non valido. Riprova.");
            }
        }
    }

