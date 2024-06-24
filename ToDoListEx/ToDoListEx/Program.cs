using System.Security.Cryptography.X509Certificates;
using ToDoListEx.Interface;
using ToDoListEx.Repository;

namespace ToDoListEx
{
    internal class Programs
    {
        static void Main(string[] args)
        {
            ILista classi = new Opzioni();
            bool stato = true;

            Console.WriteLine("Ciao benvenuto nella lista delle tue attività....!!");
            while (stato)
            {

                Console.WriteLine("\n In base a quello che dei fare premi il numero corrispondente: ");
                Console.WriteLine("  1) AGGIUNGERE ATTIVITA ");
                Console.WriteLine("  2) VISUALIZZARE ATTIVITA ");
                Console.WriteLine("  3) RIMUOVERE ATTIVITA ");
                Console.WriteLine("  4) MODIFICA ATTIVITA ");
                Console.WriteLine("  5) ESCI \n");

                Console.Write(" Inserisci il comando: ");
                string comando = Console.ReadLine();


                switch (comando)
                {
                    case "1":

                        classi.Aggiungi();

                        break;

                    case "2":

                        classi.Visualizza();

                        break;

                    case "3":

                        classi.Rimuovi();

                        break;

                    case "4":

                        classi.Modifica();

                        break;

                    case "5":

                        stato = false;
                        Console.WriteLine("\nChiusura del programma in corso...");

                        break;

                    default:

                        Console.WriteLine("\nComando non valido");

                        break;


                }
            }
        }
    }
}

