using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ToDoList
    {

        //creiamo la lista di attività.
        private List<string> tasks;

        public ToDoList()
        {

            //inizializziamo la lista.
            tasks = new List<string>();
        }

        public void Add(string task)
        {
            tasks.Add(task); //Aggiungiamo le attività alla lista creata.
            Console.WriteLine($"L'attività \"{task}\" è stata AGGIUNTA alla lista! :)");
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                Console.WriteLine($"L'attività \"{tasks[index]}\" è stata ELIMINATA dalla lista! :(");

                //Funzione che rimuove l'attività aggiunta in precedenza 
                //(o qualunque attività si voglia)
                //dall'indice specificato.
                tasks.RemoveAt(index); 
            }
            else
            {
                Console.WriteLine("Indice non valido! :(");
            }
        }


        //stampa tutte le attività nella lista,
        //numerandole in modo da mostrare l’indice corrispondente. 
        public void Print()
        {
            Console.WriteLine("Attività:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        //Funzione che mi fornisce il numero di attività presenti nella lista.
        public int TaskCount()
        {
            return tasks.Count;
        }

        //Funzione che mi azzera la lista, pulendola.
        public void Clear()
        {
            tasks.Clear();
            Console.WriteLine("Tutte le attività sono state rimosse dalla lista! :)");
        }
    }
}