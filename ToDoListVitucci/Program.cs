// Classe principale del programma

using System;
using ProgettoFinale;

public class Program
{
    static void Main(string[] args)
    {
        // Inizializzazione del gestore delle attività e variabili
        ITaskManager taskManager = new TaskManager();  // Crea un'istanza del gestore delle attività
        bool loggedIn = false;  // Variabile per tracciare lo stato di accesso
        string currentUsername = null;  // Memorizza il nome utente corrente

        // Messaggio di benvenuto iniziale
        Console.WriteLine("Benvenuto! Seleziona un'opzione:");

        while (true)  // Loop principale dell'applicazione
        {
            if (!loggedIn)  // Se non si è ancora effettuato l'accesso
            {
                // Menu di accesso e registrazione
                Console.WriteLine("1. Registrati");
                Console.WriteLine("2. Accedi");
                Console.WriteLine("3. Esci");
                Console.Write("Inserisci il comando: ");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        // Registrazione di un nuovo utente
                        Console.Write("Inserisci il nome utente: ");
                        var username = Console.ReadLine();
                        currentUsername = username;  // Imposta il nome utente corrente
                        Console.WriteLine($"Benvenuto, {currentUsername}!");
                        Console.Write("Inserisci la password: ");
                        var password = Console.ReadLine();
                        taskManager.RegisterUser(username, password);  // Chiama il metodo per registrare l'utente
                        break;
                    case "2":
                        // Accesso con nome utente e password
                        Console.Write("Inserisci il nome utente: ");
                        var loginUsername = Console.ReadLine();
                        Console.Write("Inserisci la password: ");
                        var loginPassword = Console.ReadLine();
                        loggedIn = taskManager.Login(loginUsername, loginPassword);  // Chiama il metodo per effettuare l'accesso
                        currentUsername = loginUsername;  // Imposta il nome utente corrente se l'accesso ha avuto successo
                        break;
                    case "3":
                        // Uscita dall'applicazione
                        Console.WriteLine("Grazie per aver usato la To-Do List. Arrivederci!");
                        return;
                    default:
                        // Comando non valido
                        Console.WriteLine("Comando non valido. Riprova.");
                        break;
                }
            }
            else  // Se l'utente è loggato
            {
                // Menu delle attività disponibili
                Console.WriteLine("\nScegli un'opzione:");
                Console.WriteLine("1. Aggiungi attività");
                Console.WriteLine("2. Visualizza attività");
                Console.WriteLine("3. Rimuovi attività");
                Console.WriteLine("4. Modifica attività");
                Console.WriteLine("5. Esci");
                Console.Write("\nInserisci il comando: ");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        // Aggiunta di un'attività
                        Console.Write("Inserisci il nome dell'attività: ");
                        var task = Console.ReadLine();
                        taskManager.AddTask(task);  // Chiama il metodo per aggiungere un'attività
                        Console.WriteLine($"L'attività '{task}' è stata aggiunta.");
                        break;
                    case "2":
                        // Visualizzazione delle attività
                        taskManager.DisplayTasks();  // Chiama il metodo per visualizzare le attività
                        break;
                    case "3":
                        // Rimozione di un'attività
                        Console.Write("Inserisci l'identificativo dell'attività da rimuovere: ");
                        if (int.TryParse(Console.ReadLine(), out int taskNumberToRemove))
                        {
                            taskManager.RemoveTask(taskNumberToRemove);  // Chiama il metodo per rimuovere un'attività
                        }
                        else
                        {
                            Console.WriteLine("Numero non valido.");
                        }
                        break;
                    case "4":
                        // Modifica di un'attività
                        Console.Write("Inserisci l'identificativo dell'attività da modificare: ");
                        if (int.TryParse(Console.ReadLine(), out int taskNumberToUpdate))
                        {
                            Console.Write("Inserisci il nuovo nome dell'attività: ");
                            var newTaskName = Console.ReadLine();
                            taskManager.UpdateTask(taskNumberToUpdate, newTaskName);  // Chiama il metodo per aggiornare un'attività
                        }
                        else
                        {
                            Console.WriteLine("Identificativo non valido.");
                        }
                        break;
                    case "5":
                        // Uscita dall'applicazione
                        Console.WriteLine("Grazie per aver usato la To-Do List. Arrivederci!");
                        return;
                    default:
                        // Comando non valido
                        Console.WriteLine("Comando non valido. Riprova.");
                        break;
                }
            }
        }
    }
}