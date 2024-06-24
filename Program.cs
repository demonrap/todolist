using System.ComponentModel.Design;

namespace TodoList
{
    // <------- Gianpiero
    /// <summary>Tipologie di scelte conosciute.</summary>
    internal enum EChoices
    {
        CHOICE_CREATE = 1,
        CHOICE_DELETE,
        CHOICE_DISPLAY,
        CHOICE_QUIT,
    }

    /// <summary>Interfaccia che rappresenta la funzionalità di un elemento nella lista.</summary>
    internal interface IListItem
    {
        public string GetMessage();

        public void SetMessage(string message);
    }

    /// <summary>Implementazione di un elemento della lista.</summary>
    internal class ListItem : IListItem
    {
        private string Message = "";

        public string GetMessage() { return Message; }

        public void SetMessage(string message)
        {
            Message = message;
        }
    }

    /// <summary>Elemento della lista del menu.</summary>
    /// <param name="Key">Numero da digitare per la scelta.</param>
    /// <param name="Name">Nome della scelta.</param>
    internal record MenuChoice(EChoices Key, string Name);

    internal static class Program
    {
        // Scelte del menu (usato solo dal programma).
        static List<MenuChoice> MenuChoices = new List<MenuChoice>();

        // Elementi inseriti dall'utente.
        static List<IListItem> ListItems = new List<IListItem>();

        static void Main(string[] args)
        {
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
        
        // <------- Fine Gianpiero
        
        
        private static void ChoiceDisplay()
        {
            Console.WriteLine(ListItems);
        }
        // Nick Niccolo Quinto
        private static void ChoiceCreate()
        {

            //Nick Niccolo quinto
            Console.WriteLine($"Cosa vuoi inserire: ");
            string? input = Console.ReadLine();
            Console.WriteLine(input);
            if (input != null)
            {
                ListItem listItem = new ListItem();
                listItem.SetMessage(input);
                ListItems.Add(listItem);
            } else
            {
                Console.WriteLine("dato non valido");
            }
            // Nick Niccolo Quinto
        }
        private static void ChoiceDelete()
        {
            Console.WriteLine($"Cosa vuoi cancellare?:");
            string? input = Console.ReadLine();
            Console.WriteLine(input);
            if (input != null)
            {
                int index = int.Parse(input);
                if (index > 0 && index <= ListItems.Count)
                {
                    ListItems.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Indice non valido");
                }
            }
        }
    }
}