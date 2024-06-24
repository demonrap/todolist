using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListEx.Interface;

namespace ToDoListEx.Repository
{
    public class Opzioni : ILista
    {
        List<string> Lista = new List<string>();

        public void Aggiungi()
        {
            bool stato = true;

            Console.Write("\nScrivi l'attività che vuoi inserire nelle lista (0 per uscire): ");
            string attivita = Console.ReadLine();
            if (attivita == "0")
            {
                stato = false;
            }
            else if (Lista.Contains(attivita))
            {
                Console.WriteLine($" --> L'attività {attivita} è già presente nella lista <-- ");
            }
            else
            {
                Lista.Add(attivita);
                Console.WriteLine($" --> L'attivita {attivita} è stata inserita nella lista <-- ");

            }

        }

        public void Visualizza()
        {
            if (Lista.Count == 0)
            {
                Console.WriteLine(" --> La lista è vuota <-- ");
                return;
            }

            Console.WriteLine("Questa è la lista: ");
            for (int i = 0; i < Lista.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Lista[i]}");
            }
        }

        public void Rimuovi()
        {
            Visualizza();

            bool stato = true;

            do
            {
                Console.Write("Inserisci il numero della riga che vuoi eliminare (0 per uscire): ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= Lista.Count)
                {
                    string attivita = Lista[index - 1];
                    Lista.RemoveAt(index - 1);
                    Console.WriteLine($"L'attività '{attivita}' è stata rimossa dalla lista.");
                    break;
                }
                else if (index == 0)
                {
                    stato = false;

                }
                else
                {
                    Console.WriteLine("Numero non valido. Riprova.");
                }

            } while (stato);
        }

        public void Modifica()
        {


            bool stato = true;

            Visualizza();

            do
            {

                Console.Write("Inserisci il numero della riga che vuoi modificare (0 per uscire): ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index <= Lista.Count)
                {
                    if (index == 0)
                    {
                        stato = false;
                    }
                    else
                    {
                        Console.Write("Inserisci la nuova attività: ");
                        string nuovaAttivita = Console.ReadLine();
                        string attivitaPrecedente = Lista[index - 1];
                        Lista[index - 1] = nuovaAttivita;
                        Console.WriteLine($"L'attività '{attivitaPrecedente}' è stata modificata in '{nuovaAttivita}'.");
                        stato = false;
                    }
                }
                else
                {
                    Console.WriteLine("Numero non valido. Riprova.");
                }
            } while (stato);
        }
    }
}
