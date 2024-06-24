using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
public class Azioni : Lista    {

        public override void AggiuntaTask()
        {
            Console.WriteLine("Aggiungere una nuova attività: ");
            string task = Console.ReadLine();
            toDoList.Add(task);
            Console.WriteLine($"Attività \"{task}\" aggiunta alla lista.");

        }

        public override void VisualizzazioneTask()
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("La lista è vuota.");
                return;
            }

            Console.WriteLine("Attività: ");
            for (int i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{toDoList[i]}");
            }
        }

        public override void VisualizzazioneUltima()
        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("La lista è vuota.");
                return;
            }
            int visualUltima = toDoList.Count - 1;
            Console.WriteLine($"{toDoList[visualUltima]}");
            
        }

        public override void VisualizzazioneNumero()

        {
            if (toDoList.Count == 0)
            {
                Console.WriteLine("La lista è vuota.");
                return;
            }

            Console.WriteLine("Attività: ");
            int numeroAttivita = 0;
            for (int i = 0; i < toDoList.Count; i++)
            {
                numeroAttivita++;
            }
            Console.WriteLine($"{numeroAttivita}");
        }

        public override void RimozioneTask()
        {
            VisualizzazioneTask();

            if (toDoList.Count == 0)
            {
                return;
            }
            Console.WriteLine("Inserire il numero dell'attività da rimuovere: ");
            int numAttDaRimuovere = Convert.ToInt32(Console.ReadLine());
            if (numAttDaRimuovere > 0 && numAttDaRimuovere <= toDoList.Count)
            {
                string taskRimossa = toDoList[numAttDaRimuovere - 1];
                toDoList.RemoveAt(numAttDaRimuovere - 1);
                Console.WriteLine($"Attività \"{taskRimossa}\" rimossa.");
            }
            else
            {
                Console.WriteLine("Numero attività non valido.");
            }
        }

        public override void RimozioneUltima()

        {
            VisualizzazioneTask();

            if (toDoList.Count == 0)
            {
                return;
            }
            Console.WriteLine("Confermare la rimozione dell'ultima attività inserita? ");
            Console.WriteLine("'1': Confermare");
            int conferma = Convert.ToInt32(Console.ReadLine());
            if (conferma == 1)
            {
                int ultima = (toDoList.Count - 1);
                toDoList.RemoveAt(ultima);
                Console.WriteLine($"Attività rimossa.");
            }
            else
            {
                Console.WriteLine("$Cancellazione non confermata.");
            }

        }

        public override void RimozioneTotale()

        {
            VisualizzazioneTask();

            if (toDoList.Count == 0)
            {
                return;

            }
            Console.WriteLine("Confermare la rimozione totale? ");
            Console.WriteLine("'1': Confermare");
            int conferma = Convert.ToInt32(Console.ReadLine());
            if (conferma == 1)
            {

                toDoList.Clear();
                Console.WriteLine($"Tutte le attività sono state rimosse.");

            }
            else
            {
                Console.WriteLine("$Cancellazione non confermata.");
            }
        }
    }
}
