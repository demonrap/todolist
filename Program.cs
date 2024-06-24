using TodoList.Enums;
using TodoList.Interfaces;
using TodoList.Repository;

namespace TodoList
{
    // <------- Gianpiero 

    /// <summary>Elemento della lista del menu.</summary>
    /// <param name="Key">Numero da digitare per la scelta.</param>
    /// <param name="Name">Nome della scelta.</param>
    internal record MenuChoice(EChoices Key, string Name);

    internal class Program
    {
        // Scelte del menu (usato solo dal programma).
        static List<MenuChoice> MenuChoices = new List<MenuChoice>();

        // Elementi inseriti dall'utente.
        static List<IActivity> Activities = new List<IActivity>();

        static void Main(string[] args)
        {
            // Aggiunge le scelte da visuallizare nel menu.
            MenuChoices.Add(new MenuChoice(EChoices.CHOICE_CREATE, "Aggiungi"));
            MenuChoices.Add(new MenuChoice(EChoices.CHOICE_DELETE, "Rimuovi"));
            MenuChoices.Add(new MenuChoice(EChoices.CHOICE_DISPLAY, "Cronologia"));
            MenuChoices.Add(new MenuChoice(EChoices.CHOICE_QUIT, "Esci"));

            bool isRunning = true;
            bool invalidChoice = false;

            // Itera per tutta la durata dell'applicazione.
            while (isRunning)
            {
                // Crea le etichette delle scelte che l'utente può eseguire.
                IEnumerable<string> choices = MenuChoices.Select(choice => $"{(int)choice.Key}. {choice.Name}");

                // Mostra al schermata di benvenuto e le scelte dell'utente.
                Console.Clear();
                Console.WriteLine("ToDo app, Benvenuto! Scegli una delle opzioni:");
                Console.WriteLine($"[ {string.Join(' ', choices)} ]");

                if (invalidChoice)
                {
                    invalidChoice = false;
                    Console.WriteLine(" ! Comando non valido. Riprova.");
                }

                // L'utente fa una delle scelte.
                Console.Write(" > ");
                string? userChoice = Console.ReadLine();

                try
                {
                    // Preleva la scelta dall'utente.
                    int choice = int.Parse(userChoice!);

                    // Salta alla schermata in base alla scelta.
                    switch ((EChoices)choice)
                    {
                        case EChoices.CHOICE_CREATE:
                            ChoiceCreate();
                            break;

                        case EChoices.CHOICE_DELETE:
                            ChoiceDelete();
                            break;

                        case EChoices.CHOICE_DISPLAY:
                            ChoiceDisplay();
                            break;

                        case EChoices.CHOICE_QUIT:
                            isRunning = false;
                            break;

                        default:
                            invalidChoice = true;
                            break;
                    }
                }

                // Se l'utente non inserisce un numero valid (stringa vuota o non numerica)
                // ignora l'errore.
                catch (FormatException) { /* empty */ }
            }

            // Se sei arrivato qui l'applicazione è stata terminata.
            Console.WriteLine("Grazie per aver usato la To-Do List. Arrivederci!");
        }

        /// <summary>Mostra la lista delle attività su schermo.</summary>
        private static void ShowItems()
        {
            for (int i = 0; i < Activities.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {Activities[i].GetMessage()}");
            }
        }

        private static void ChoiceDisplay()
        {
            Console.Clear();

            // Mostra la lista di tutte le attività.
            if (Activities.Count > 0)
            {
                Console.WriteLine("Lista delle attività:");

                ShowItems();
            }
            else
            {
                Console.WriteLine("Nessuna attività da mostrare.");
            }

            Console.ReadKey();
        }

        private static void ChoiceCreate()
        {
            Console.Clear();
            Console.WriteLine("Inserisci nome dell'attività:");
            Console.Write(" > ");

            // Ottiene il nome dell'attività dall'utente.
            string? message = Console.ReadLine();

            if (message != null && message.Length > 0)
            {
                // Crea un nuovo oggetto dell'attività.
                Activity item = new Activity();
                item.SetMessage(message);

                // Aggiunge oggetto alla lista.
                Activities.Add(item);
            }
            else
            {
                Console.Error.WriteLine("Attività invalida.");
                Console.ReadKey();
            }
        }

        private static void ChoiceDelete()
        {
            Console.Clear();

            if (Activities.Count > 0)
            {
                Console.WriteLine("Scegli un'attività da rimuovere:");

                ShowItems();

                // Legge scelta dall'utente.
                Console.Write(" > ");
                string? index = Console.ReadLine();

                try
                {
                    // Ottiene indice (partendo da 1).
                    int idx = int.Parse(index!) - 1;

                    if (idx < 0 || idx >= Activities.Count)
                    {
                        Console.Error.WriteLine("Attività invalida.");
                    }
                    else
                    {
                        IActivity item = Activities[idx];
                        Activities.RemoveAt(idx);

                        Console.Error.WriteLine($"Attività {item.GetMessage()} rimossa.");
                    }

                    Console.ReadKey();
                }
                catch (FormatException) { /* empty */ }
            }
            else
            {
                Console.WriteLine("Nessuna attività da rimuovere.");
                Console.ReadKey();
            }
        }

        // <------- Fine Gianpiero
    }
}
