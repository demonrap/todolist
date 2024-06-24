using System;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Inizializza una nuova lista di attività.
            ToDoList toDoList = new ToDoList();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Inserisci un comando:");
                Console.WriteLine("1:- Aggiungi attività");
                Console.WriteLine("2:- Stampa attività");
                Console.WriteLine("3:- Elimina attività");
                Console.WriteLine("4:- Numero attività in lista");
                Console.WriteLine("5:- Azzera lista attività");
                Console.WriteLine("6:- Esci");


                // Legge l'input dell'utente.
                string command = ReadNonNullInput();

                switch (command)
                {
                    
                    case "1":
                        Console.WriteLine("Inserisci l'attività da AGGIUNGERE:");
                        string task = ReadNonNullInput(); // Legge l'attività da aggiungere.
                        toDoList.Add(task); // Aggiunge l'attività alla lista.
                        break;

                    case "2":
                        toDoList.Print(); // Stampa tutte le attività nella lista
                        break;

                    case "3":
                        Console.WriteLine("Inserisci l'indice dell'attività da ELIMINARE:");
                        if (int.TryParse(ReadNonNullInput(), out int index))
                        {                           
                            // Rimuove l'attività dall'indice specificato.
                            toDoList.Remove(index - 1); 
                        }
                        else
                        {
                            // Messaggio di errore se l'indice non è valido.
                            Console.WriteLine("L' indice non è valido!");
                        }
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("!ARRIVEDERCI!");
                        break;
                    default:

                        //messaggio di errore per i comandi non validi.
                        Console.WriteLine("Comando non valido! Ritenta!");
                        break;

                    case "4":
                        Console.WriteLine($"Le attività attualmente in lista sono: {toDoList.TaskCount()}");
                        break;

                    case "5":
                        toDoList.Clear();
                        break;
                }
            }
        }
       /* legge l’input dell’utente da console e assicura che non sia
        * vuoto o composto solo da spazi.
        * Se l’input è valido, lo restituisce; altrimenti, 
        visualizza un messaggio di errore.*/
        static string ReadNonNullInput()
        {
            string? input;
            while (true)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("Input non valido!");
            }
        }
    }
}
