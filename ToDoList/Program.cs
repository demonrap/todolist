using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDoList.Entities;
using ToDoList.Repository;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            ImpegniRepository repository = new ImpegniRepository
            {
                EntityDictionary = new Dictionary<int, Attivita>()
            };

            bool exit = false;

            while (!exit)
            {
                repository.Print("\n--- Menu ---");
                repository.Print("1. Crea Attività");
                repository.Print("2. Aggiorna Attività");
                repository.Print("3. Elimina Attività");
                repository.Print("4. Visualizza Tutte le Attività");
                repository.Print("5. Filtra Attività");
                repository.Print("6. Ottieni Attività per ID");
                repository.Print("7. Ottieni Attività per Priorità");
                repository.Print("8. Filtra per giorno");
                repository.Print("9. Filtra per mese");
                repository.Print("10. Filtra per anno");
                repository.Print("11. Filtra per periodo");
                repository.Print("12. Esci");
                Console.Write("Seleziona un'opzione: ");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.Clear();
                    switch (option)
                    {
                        case 1:
                            CreateActivity(repository);
                            break;
                        case 2:
                            UpdateActivity(repository);
                            break;
                        case 3:
                            DeleteActivity(repository);
                            break;
                        case 4:
                            DisplayAllActivities(repository);
                            break;
                        case 5:
                            FilterActivities(repository);
                            break;
                        case 6:
                            GetActivityById(repository);
                            break;
                        case 7:
                            GetActivityByPrio(repository);
                            break;
                        case 8:
                            FiltraByDay(repository);
                            break;
                        case 9:
                            FiltraByMonth(repository);
                            break;
                        case 10:
                            FiltraByYear(repository);
                            break;
                        case 11:
                            FiltraByPeriod(repository);
                            break;
                        case 12:
                            exit = true;
                            break;
                        default:
                            repository.Print("Opzione non valida. Riprova.");
                            break;
                    }
                }
                else
                {
                    repository.Print("Input non valido. Inserisci un numero.");
                }
            }
        }

        private static void FiltraByPeriod(ImpegniRepository repository)
        {
            Console.Write("Inserisci data inizio periodo (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Inserisci data fine periodo (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            var activities = repository.GetByPeriod(startDate, endDate);
            DisplayActivities(activities);
        }

        private static void FiltraByYear(ImpegniRepository repository)
        {
            Console.Write("Inserisci anno: ");
            int anno = int.Parse(Console.ReadLine());

            var activities = repository.GetByYear(anno);
            DisplayActivities(activities);
        }

        private static void FiltraByMonth(ImpegniRepository repository)
        {
            Console.Write("Inserisci mese: ");
            int mese = int.Parse(Console.ReadLine());

            Console.Write("Inserisci anno: ");
            int anno = int.Parse(Console.ReadLine());

            var activities = repository.GetByMonth(mese, anno);
            DisplayActivities(activities);
        }

        private static void FiltraByDay(ImpegniRepository repository)
        {
            Console.Write("Inserisci giorno: ");
            DateTime giorno = DateTime.Parse(Console.ReadLine());

            var activities = repository.GetByDay(giorno);
            DisplayActivities(activities);
        }

        static void DisplayActivities(IList<Attivita> activities)
        {
            if (activities.Count == 0)
            {
                Console.WriteLine("Nessuna attività trovata.");
            }
            else
            {
                foreach (var activity in activities)
                {
                    Console.WriteLine($"ID: {activity.Key}, Nome: {activity.Nome}, Descrizione: {activity.Descrizione}, Data di Scadenza: {activity.DataScadenza.ToShortDateString()}");
                }
            }
        }

        static void CreateActivity(ImpegniRepository repository)
        {
            DataValidator validator = new DataValidator();
            bool validate = false;
            string id = "";
            while (!validate)
            {
                Console.Write("Inserisci ID: ");
                 id = Console.ReadLine();
                if (int.TryParse(id, out int numero))
                {
                    validate = true;
                }
                else
                {
                    Console.WriteLine($"La stringa '{id}' non è un numero intero valido.");
                }

            }
            int tmpid = int.Parse(id);
            string prio="";
            validate = false;
            while (!validate)
            {

                Console.Write("Inserisci la priorità dell'attività (minore è il numero minore è la priorità): ");
                 prio = Console.ReadLine();
                if (int.TryParse(prio, out int priocount))
                {
                    validate = true;
                }
                else
                {
                    Console.WriteLine($"La stringa '{prio}' non è un numero intero valido.");
                }

            }
            int tmpprio = int.Parse(prio);

            Console.Write("Inserisci Nome: ");
            string nome = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(nome))
            {
                Console.Write("Il nome dell'attività non può essere vuoto, nullo o solo uno spazio vuoto\n");
                Console.Write("Inserisci Nome: ");
                nome = Console.ReadLine();
            }
            Console.Write("Inserisci Descrizione: ");
            string descrizione = Console.ReadLine(); ;
            while (String.IsNullOrWhiteSpace(nome))
            {
                Console.Write("La descrizione dell'attività non può essere vuoto, nullo o solo uno spazio vuoto");
                Console.Write("Inserisci Descrizione: ");
                descrizione = Console.ReadLine();
            }
            bool validDate = false;
            DateTime dataScadenza = DateTime.MinValue;
            while (!validDate)
            {
                try
                {  
                    
                   
                    Console.Write("Inserisci Giorno (dd): ");
                     int giorno= int.Parse(Console.ReadLine());
       
                    Console.Write("Inserisci Mese (MM): ");
                    int mese = int.Parse(Console.ReadLine());

                    Console.Write("Inserisci Anno (yyyy): ");
                    int anno = int.Parse(Console.ReadLine());

                    validDate = DataValidator.ValidaData(anno, mese, giorno);
                    if (validDate)
                    {
                        dataScadenza = new DateTime(anno, mese, giorno);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    repository.Print("Errore: " + ex.Message);
                    validDate = false;
                }
            }

            var attivita = new Attivita(tmpid, nome, descrizione, tmpprio, dataScadenza);

            try
            {
                repository.Create(attivita);
                repository.Print("Attività creata con successo.");
            }
            catch (Exception ex)
            {
                repository.Print(ex.Message);
            }
        }

        static void GetActivityByPrio(ImpegniRepository repository)
        {
            var activities = repository.GetAllByPrio();
            if (activities.Count == 0)
            {
                repository.Print("Nessuna attività trovata.");
            }
            else
            {
                foreach (var activity in activities)
                {
                    repository.Print($"ID: {activity.Key}, Priorita: {activity.Prio}, Nome: {activity.Nome}, Descrizione: {activity.Descrizione}, Data di Scadenza: {activity.DataScadenza.ToShortDateString()}");
                }
            }
        }

        static void UpdateActivity(ImpegniRepository repository)
        {
            bool validate=false;
            
            string id= ""; 
           
            while (!validate)
            {
                Console.Write("Inserisci ID: ");
                id= Console.ReadLine();
                if (int.TryParse(id, out int numero))
                {
                    validate = true;
                }
                else
                {
                    Console.WriteLine($"La stringa '{id}' non è un numero intero valido.");
                }

            }
            var tmpid = int.Parse(id);

           

            validate = false;
            while (!validate)
            {
                Console.Write("Inserisci la priorità dell'attività (minore è il numero minore è la priorità): ");
               string prio = Console.ReadLine();
                if (int.TryParse(prio, out int priocount))
                {
                    validate = true;
                }
                else
                {
                    Console.WriteLine($"La stringa '{prio}' non è un numero intero valido.");
                }

            }
            var tmpprio = int.Parse(id);



            
            Console.Write("Inserisci Nome: ");
            string nome = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(nome))
            {
                Console.Write("Il nome dell'attività non può essere vuoto, nullo o solo uno spazio vuoto\n");
                Console.Write("Inserisci Nome: ");
                nome = Console.ReadLine();
            }
            Console.Write("Inserisci Descrizione: ");
            string descrizione = Console.ReadLine(); ;
            while (String.IsNullOrWhiteSpace(nome))
            {
                Console.Write("La descrizione dell'attività non può essere vuoto, nullo o solo uno spazio vuoto");
                Console.Write("Inserisci Descrizione: ");
                descrizione = Console.ReadLine();
            }
            bool validDate = false;
            DateTime dataScadenza = DateTime.MinValue;
            int giorno=0, mese=0, anno=0;
            while (!validDate)
            {
                try
                {
                    Console.Write("Inserisci Giorno (dd): ");
                     giorno = int.Parse(Console.ReadLine());

                    Console.Write("Inserisci Mese (MM): ");
                     mese = int.Parse(Console.ReadLine());

                    Console.Write("Inserisci Anno (yyyy): ");
                     anno = int.Parse(Console.ReadLine());

                    validDate = DataValidator.ValidaData(anno, mese, giorno);
                    if (validDate)
                    {
                        dataScadenza = new DateTime(anno, mese, giorno);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    repository.Print("Errore: " + ex.Message);
                    validDate = false;
                }
            }
                var attivita = new Attivita(tmpid, nome, descrizione, tmpprio, Convert.ToDateTime($"{anno}/{mese}/{giorno}"));
            try
            {
                repository.Update(attivita);
                repository.Print("Attività aggiornata con successo.");
            }
            catch (Exception ex)
            {
                repository.Print(ex.Message);
            }
        }

        static void DeleteActivity(ImpegniRepository repository)
        {
            Console.Write("Inserisci ID dell'attività da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                repository.Delete(id);
                repository.Print("Attività eliminata con successo.");
            }
            catch (Exception ex)
            {
                repository.Print(ex.Message);
            }
        }

        static void DisplayAllActivities(ImpegniRepository repository)
        {
            var activities = repository.GetAll();
            if (activities.Count == 0)
            {
                repository.Print("Nessuna attività trovata.");
            }
            else
            {
                foreach (var activity in activities)
                {
                    repository.Print($"ID: {activity.Key}, Priorita: {activity.Prio}, Nome: {activity.Nome}, Descrizione: {activity.Descrizione}, Data di Scadenza: {activity.DataScadenza.ToShortDateString()}");
                }
            }
        }

        static void FilterActivities(ImpegniRepository repository)
        {
            Console.Write("Inserisci stringa di ricerca: ");
            string query = Console.ReadLine();

            var activities = repository.GetByFilter(query);
            if (activities.Count == 0)
            {
                repository.Print("Nessuna attività trovata.");
            }
            else
            {
                foreach (var activity in activities)
                {
                    repository.Print($"ID: {activity.Key}, Priorita: {activity.Prio}, Nome: {activity.Nome}, Descrizione: {activity.Descrizione}, Data di Scadenza: {activity.DataScadenza.ToShortDateString()}");
                }
            }
        }

        static void GetActivityById(ImpegniRepository repository)
        {
            Console.Write("Inserisci ID: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                var activity = repository.GetById(id);
                repository.Print($"ID: {activity.Key}, Priorita: {activity.Prio}, Nome: {activity.Nome}, Descrizione: {activity.Descrizione}, Data di Scadenza: {activity.DataScadenza.ToShortDateString()}");
            }
            catch (Exception ex)
            {
                repository.Print(ex.Message);
            }
        }
    }
}
