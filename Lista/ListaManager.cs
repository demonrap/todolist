using Lista.Interfaccie;
using Lista.Repository;

namespace Lista
{
    internal class ListaManager
    {

        public void Manager()
        {

            ICrud listaRepository = new ListaRepository();
            

            bool Acceso = true;

            while (Acceso)
            {
                Console.WriteLine("LA TUA LISTA");
                Console.WriteLine("Digita un numero per avviare un comando");
                Console.WriteLine("1: Aggiungi attività");
                Console.WriteLine("2: Visualizza tutte le attività");
                Console.WriteLine("3: Rimuovi attività");
                Console.WriteLine("4: Esci\n");

                string comando = Console.ReadLine();


                switch (comando)
                {
                    case "1":

                        listaRepository.AggiungiAttivita();

                        break;
                    case "2":
                        listaRepository.VisualizzaAttivita();
                        break;
                    case "3":
                        Console.Write("Inserisci il numero dell'attività da rimuovere: ");
                        int numeroAttivita;
                        comando = Console.ReadLine();
                        if (int.TryParse(comando, out numeroAttivita))
                        {
                            listaRepository.RimuoviAttivita(numeroAttivita);
                        }
                        else
                        {
                            Console.WriteLine("Input non valido. Inserisci un numero.");
                        }
                        break;
                    case "4":
                        Acceso = false;
                        Console.WriteLine("Grazie per aver utilizzato la lista. Arrivederci");
                        break;
                    default:
                        Console.WriteLine("Comando non valido");
                        break;
                }
            }

        }
    }
}
