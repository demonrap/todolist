namespace ProgettoFinale
{
    class Programma
    {
        static void Main()
        {
            Console.WriteLine("Benvenuto nella tua ToDoList!");
            Console.WriteLine();

            string nome = InputUtente.GetValidNameOrSurname("Per favore, inserisci il tuo nome:");
            string cognome = InputUtente.GetValidNameOrSurname("Perfetto, adesso inserisci il tuo cognome:");

            Console.Clear();
            string benvenuto = $"Benvenuto {nome} {cognome}";
            Console.WriteLine(benvenuto);

            IAttivitaManager manager = new ListaAttivita();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Progetto ToDoList");
                Console.WriteLine();
                Console.WriteLine("1. Aggiungi una nuova attività");
                Console.WriteLine("2. Vedi tutte le attività");
                Console.WriteLine("3. Modifica un'attività");
                Console.WriteLine("4. Rimuovi un'attività");
                Console.WriteLine("5. Consigliami un'attività");
                Console.WriteLine("6. Pulisci Console");
                Console.WriteLine("7. Esci");
                Console.WriteLine();
                string scelta = Console.ReadLine();
                Console.WriteLine();

                if (Enum.TryParse(scelta, out OpzioniMenu opzione))
                {
                    switch (opzione)
                    {
                        case OpzioniMenu.AggiungiAttivita:
                            manager.AggiungiAttivita();
                            break;
                        case OpzioniMenu.VediAttivita:
                            manager.VediAttivita();
                            break;
                        case OpzioniMenu.ModificaAttivita:
                            manager.ModificaAttivita();
                            break;
                        case OpzioniMenu.RimuoviAttivita:
                            manager.RimuoviAttivita();
                            break;
                        case OpzioniMenu.ConsiglioAttivita:
                            manager.ConsiglioAttivita();
                            break;
                        case OpzioniMenu.PulisciConsole:
                            Console.Clear();
                            break;
                        case OpzioniMenu.Esci:
                            running = false;
                            Console.WriteLine($"Grazie per aver usato l'applicazione! Arrivederci {nome} {cognome}!");
                            break;
                        default:
                            Console.WriteLine("Opzione non valida! Inserisci un numero da 1 a 7, come suggerito.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opzione non valida! Inserisci un numero da 1 a 7, come suggerito.");
                }
            }
        }
    }
}
