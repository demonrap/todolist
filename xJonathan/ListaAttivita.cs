namespace ProgettoFinale
{
    public class ListaAttivita : IAttivitaManager
    {
        private List<string> toDoList = new List<string>();
        private Random random = new Random();
        private List<string> suggerimenti = new List<string>
        {
            "Ascoltare un podcast interessante",
            "Organizzare una serata giochi da tavolo",
            "Partecipare a una lezione di yoga",
            "Visitare un museo o una galleria d'arte",
            "Fare una passeggiata al tramonto",
            "Imparare a suonare uno strumento musicale",
            "Esplorare nuovi ristoranti o locali",
            "Partecipare a un corso di cucina",
            "Fare una gita fuori porta",
            "Provare una nuova attività sportiva",
            "Fare una sessione di volontariato",
            "Leggere articoli su un argomento che ti interessa",
            "Partecipare a un webinar o a un workshop online",
            "Fare una giornata di relax alle terme",
            "Andare al cinema o guardare un film in streaming",
            "Fare una sessione di foto o pittura",
            "Esplorare nuove vie di camminata o escursioni",
            "Organizzare una cena con amici o parenti",
            "Imparare a ballare un nuovo tipo di ballo",
            "Fare un tour gastronomico dei locali della tua città"
        };

        public void AggiungiAttivita()
        {
            Console.WriteLine("Inserisci una nuova attività:");
            string nuovaAttivita = Console.ReadLine();
            toDoList.Add(nuovaAttivita);
            Console.WriteLine("Attività aggiunta con successo!");
        }

        public void VediAttivita()
        {
            Console.WriteLine("Le tue attività:");
            if (toDoList.Count == 0)
            {
                Console.WriteLine("Non hai attività nella lista.");
            }
            else
            {
                for (int i = 0; i < toDoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {toDoList[i]}");
                }
            }
        }

        public void ModificaAttivita()
        {
            Console.WriteLine("Inserisci il numero dell'attività da modificare:");
            VediAttivita();

            if (toDoList.Count == 0)
            {
                return;
            }

            if (int.TryParse(Console.ReadLine(), out int numeroAttivita) && numeroAttivita > 0 && numeroAttivita <= toDoList.Count)
            {
                Console.WriteLine($"Attività da modificare: {toDoList[numeroAttivita - 1]}");
                Console.WriteLine("Inserisci la nuova descrizione:");
                string nuovaDescrizione = Console.ReadLine();
                toDoList[numeroAttivita - 1] = nuovaDescrizione;
                Console.WriteLine("Attività modificata con successo!");
            }
            else
            {
                Console.WriteLine("Numero attività non valido.");
            }
        }

        public void RimuoviAttivita()
        {
            Console.WriteLine("Inserisci il numero dell'attività da rimuovere:");
            VediAttivita();

            if (toDoList.Count == 0)
            {
                return;
            }

            if (int.TryParse(Console.ReadLine(), out int numeroAttivita) && numeroAttivita > 0 && numeroAttivita <= toDoList.Count)
            {
                Console.WriteLine($"Sei sicuro di voler eliminare questa attività? ({toDoList[numeroAttivita - 1]}) Si/No");
                string conferma = Console.ReadLine().ToLower();

                if (conferma == "si")
                {
                    toDoList.RemoveAt(numeroAttivita - 1);
                    Console.WriteLine("Attività rimossa con successo!");
                }
                else
                {
                    Console.WriteLine("Operazione annullata.");
                }
            }
            else
            {
                Console.WriteLine("Numero attività non valido.");
            }
        }

        public void ConsiglioAttivita()
        {
            int index = random.Next(suggerimenti.Count);
            string consiglio = suggerimenti[index];
            Console.WriteLine();
            Console.WriteLine($"Ti consiglio di: {consiglio}");
        }
    }
}
