using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgettoFinale
{
    // Classe che implementa l'interfaccia ITaskManager
    public class TaskManager : ITaskManager
    {
        // Lista delle attività e lista degli utenti registrati
        public readonly List<string> Tasks;  // Lista pubblica delle attività
        private readonly List<User> users;   // Lista privata degli utenti

        // Costruttore della classe TaskManager
        public TaskManager()
        {
            Tasks = new List<string>();  // Inizializza la lista delle attività
            users = new List<User>();    // Inizializza la lista degli utenti registrati
        }

        // Metodo per aggiungere un'attività alla lista
        public void AddTask(string task)
        {
            Tasks.Add(task);  // Aggiunge l'attività alla lista Tasks
        }

        // Metodo per mostrare tutte le attività presenti nella lista
        public void DisplayTasks()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("Non ci sono attività da mostrare.");
                return;
            }

            Console.WriteLine("Elenco delle attività:");
            for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Tasks[i]}");  // Mostra ogni attività numerata
            }
        }

        // Metodo per rimuovere un'attività dalla lista tramite ID
        public void RemoveTask(int taskId)
        {
            if (taskId > 0 && taskId <= Tasks.Count)
            {
                Tasks.RemoveAt(taskId - 1);  // Rimuove l'attività corrispondente all'ID specificato
                Console.WriteLine("Attività rimossa con successo.");
            }
            else
            {
                Console.WriteLine("ID attività non valido.");
            }
        }

        // Metodo per ottenere tutte le attività presenti nella lista
        public List<string> GetTasks()
        {
            return Tasks;  // Restituisce l'intera lista delle attività
        }

        // Metodo per aggiornare un'attività nella lista tramite ID
        public void UpdateTask(int taskId, string newTask)
        {
            if (taskId > 0 && taskId <= Tasks.Count)
            {
                Tasks[taskId - 1] = newTask;  // Aggiorna l'attività corrispondente all'ID specificato
                Console.WriteLine("Attività aggiornata con successo.");
            }
            else
            {
                Console.WriteLine("ID attività non valido.");
            }
        }

        // Metodo per registrare un nuovo utente
        public bool RegisterUser(string username, string password)
        {
            // Verifica se il nome utente è già in uso
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Nome utente già in uso. Scegli un altro nome utente.");
                return false;  // Ritorna false se il nome utente è già presente
            }

            users.Add(new User(username, password));  // Aggiunge un nuovo utente alla lista
            Console.WriteLine($"Utente '{username}' registrato con successo.");
            return true;  // Ritorna true se la registrazione è avvenuta con successo
        }

        // Metodo per effettuare il login di un utente
        public bool Login(string username, string password)
        {
            // Cerca l'utente corrispondente alle credenziali fornite
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine($"Accesso effettuato come '{username}'.");
                return true;  // Ritorna true se il login ha avuto successo
            }
            else
            {
                Console.WriteLine("Credenziali non valide. Riprova.");
                return false;  // Ritorna false se le credenziali non sono corrette
            }
        }
    }
}