using Lista.Interfaccie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista.Repository
{

    
    internal class ListaRepository : ICrud
    {
        ListaManager listaManager = new ListaManager();

        List<string> toDoList = new List<string>();
        public void AggiungiAttivita()
        {
            Console.Write("Inserisci la descrizione dell'attività: ");
            string nuovaAttivita = Console.ReadLine();
            if (toDoList.Contains(nuovaAttivita))
            {
                Console.WriteLine($"L'attività: {nuovaAttivita} è già presente");
            }
            else
            {
                toDoList.Add(nuovaAttivita);
                Console.WriteLine($"L'attività: {nuovaAttivita} è stata aggiunta");
            }

        }
        public void VisualizzaAttivita()
        {
            if (toDoList.Count <= 0)
            {
                Console.WriteLine("La lista è vuota. Per visualizzare aggiungi almeno un attività");
            }
            for (int i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {toDoList[i]}");
            }  
        }

        public void RimuoviAttivita(int id)
        {
            VisualizzaAttivita();

            if (toDoList.Count == 0)
            {
                Console.WriteLine("Non ci sono attività da rimuovere.");
                return;
            }

            if (id > 0 && id <= toDoList.Count)
            {
                string attivitaRimossa = toDoList[id - 1];
                toDoList.RemoveAt(id - 1);
                Console.WriteLine($"Attività \"{attivitaRimossa}\" rimossa dalla lista.");
            }
            else
            {
                Console.WriteLine("Numero attività non valido. Riprova.");
            }

        }

    }
}
