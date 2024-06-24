using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public class Azioni : Lista 
    {
        /// <summary>
        /// Funzione che aggiunge una task alla lista.
        /// </summary>
        public override void AggiungiTask()
        {
            Console.WriteLine("Aggiugni una nuova attività: ");

            string task = Console.ReadLine();
            toDoList.Add(task); //funzione che aggiunge alla lista la task ricevuta in input dall'utente

            Console.WriteLine($"Attività \"{task}\" aggiunta alla lista.");

        }

        /// <summary>
        /// Funzione che visualizza la lista delle task.
        /// </summary>
        public override void VisualizzaTask()
        {
            if (toDoList.Count == 0) //controlla se la lista è vuota, se sì visualizza messaggio
            {
                Console.WriteLine("La lista è vuota.");
                return;
            }

            Console.WriteLine("Attività: ");
            for (int i = 0; i < toDoList.Count; i++) //for che cicla tutte le attività della lista
            {
                Console.WriteLine($"{i + 1}. {toDoList[i]}"); //visualizza numero task (i+1) partendo da 1 
            }
        }

        /// <summary>
        /// Funzione che rimuove una task selezionata dall'utente.
        /// </summary>
        public override void RimuoviTask()
        {
            VisualizzaTask(); //visualizza lista con rispettivi numeri 

            if (toDoList.Count == 0) //controllo lista vuota
            {
                return;
            }
            Console.WriteLine("Inserisci il numero dell'attività da rimuovere: ");

            //riceve in input un intero AND controlla se è compreso tra 1 e l'ultimo numero della lista
            if (int.TryParse(Console.ReadLine(), out int numeroTask) && numeroTask > 0 && numeroTask <= toDoList.Count)
            {

                //memorizza in una variabile di appoggio la task da rimuovere per visualizzarla 
                string taskRimossa = toDoList[numeroTask - 1];


                toDoList.RemoveAt(numeroTask - 1); //rimuove la task selezionata 
                Console.WriteLine($"Attività \"{taskRimossa}\" rimossa.");

            }
            else
            {
                Console.WriteLine("Numero attività non valido.");
            }
        }

        /// <summary>
        /// Funzione che rimuove tutte le task dalla lista.
        /// </summary>
        public override void RimuoviTutto()
        {
            VisualizzaTask(); //visualizza lista

            if (toDoList.Count == 0) //controllo lista vuota
            {
                return;
            }
            Console.WriteLine("Confermare la rimozione totale? ");
            Console.WriteLine("1: Confermare");

            if (int.TryParse(Console.ReadLine(), out int conferma) && conferma == 1) //se l'intero in input è 1 conferma la rimozione, altrimenti annulla
            {

                toDoList.Clear(); //rimuove tutte le attività
                Console.WriteLine($"Tutte le attività sono state rimosse.");

            }
            else
            {
                Console.WriteLine("Rimozione annullata.");
            }
        }

    }
}
