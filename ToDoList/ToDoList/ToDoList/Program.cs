using System;
using ToDoList.Entities;
using ToDoList.Repository;

namespace ToDoList.Generics
{
    internal class Program
    {
        //Inizializza un repository per gestire le attività
        internal static AttivitaRepository attivitaRepository = new AttivitaRepository();

        static void Main(string[] args)
        {
            try
            {
                bool running = true;
                while (running)
                {
                    //Mostra le opzioni del menu
                    Console.WriteLine("\nInserisci un comando: ");
                    Console.WriteLine("1: Aggiungi una nuova attività");
                    Console.WriteLine("2: Visualizza tutte le attività");
                    Console.WriteLine("3: Rimuovi un'attività");
                    Console.WriteLine("4: Esci");
                    var command = Console.ReadLine();

                    switch (command)
                    {
                        case "1":
                            AggiungiAttivita(); //Chiama il metodo per aggiungere una nuova attività
                            break;
                        case "2":
                            VisualizzaAttivita(); //Chiama il metodo per visualizzare tutte le attività
                            break;
                        case "3":
                            RimuoviAttivita(); //Chiama il metodo per rimuovere un'attività
                            break;
                        case "4":
                            running = false; //Esci dal ciclo e termina il programma
                            attivitaRepository.Print("Grazie per aver usato la To-Do List. Arrivederci!"); //Stampa un messaggio di addio
                            break;
                        default:
                            attivitaRepository.Print("Comando non valido. Riprova."); //Stampa un messaggio per comando non valido
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                attivitaRepository.Print($"Errore durante l'esecuzione del programma: {ex.Message}");
            }
        }

        //Metodo per aggiungere una nuova attività
        private static void AggiungiAttivita()
        {
            try
            {
                Console.WriteLine("Inserisci la descrizione dell'attività:");
                var descrizione = Console.ReadLine();

                Console.WriteLine("Inserisci la data dell'attività (formato dd/MM/yyyy HH:mm):");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime data))
                {
                    var nuovaAttivita = new Attivita() { Descrizione = descrizione, Data = data };

                    //Aggiunge la nuova attività al repository
                    attivitaRepository.Create(nuovaAttivita);
                    attivitaRepository.Print($"L'attività \"{descrizione}\" per il {data.ToString("dd/MM/yyyy HH:mm")} è stata aggiunta alla lista."); //Stampa un messaggio di conferma
                }
                else
                {
                    //Stampa un messaggio di errore per formato data non valido
                    attivitaRepository.Print("Formato data non valido. Riprova.");
                }
            }
            catch (Exception ex)
            {
                attivitaRepository.Print($"Errore durante l'aggiunta dell'attività: {ex.Message}");
            }
        }

        // Metodo per visualizzare tutte le attività
        private static void VisualizzaAttivita()
        {
            try
            {
                //Recupera tutte le attività dal repository
                var listaAttivita = attivitaRepository.GetAll();
                if (listaAttivita.Count == 0)
                {
                    //Stampa un messaggio se non ci sono attività
                    attivitaRepository.Print("La lista delle attività è vuota.");
                    return;
                }
                attivitaRepository.Print("Attività:");
                foreach (var attivita in listaAttivita)
                {
                    //Stampa i dettagli di ogni attività
                    attivitaRepository.Print($"{attivita.Key}. Descrizione: {attivita.Descrizione} - Data: {attivita.Data.ToString("dd/MM/yyyy HH:mm")}");
                }
            }
            catch (Exception ex)
            {
                attivitaRepository.Print($"Errore durante la visualizzazione delle attività: {ex.Message}");
            }
        }

        //Metodo per rimuovere un'attività
        private static void RimuoviAttivita()
        {
            try
            {
                Console.WriteLine("Inserisci il numero dell'attività da rimuovere:");
                if (int.TryParse(Console.ReadLine(), out int key))
                {
                    //Prova a eliminare l'attività usando la chiave fornita
                    if (attivitaRepository.Delete(key))
                    {
                        // Stampa un messaggio di conferma se l'operazione è riuscita
                        attivitaRepository.Print($"L'attività con numero {key} è stata rimossa.");
                    }
                    else
                    {
                        // Stampa un messaggio se non esiste un'attività con la chiave fornita
                        attivitaRepository.Print($"L'attività con numero {key} non esiste.");
                    }
                }
                else
                {
                    // Stampa un messaggio per input non valido
                    attivitaRepository.Print("Input non valido. Riprova.");
                }
            }
            catch (Exception ex)
            {
                attivitaRepository.Print($"Errore durante la rimozione dell'attività: {ex.Message}");
            }
        }
    }
}
