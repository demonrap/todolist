namespace ToDoListApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var azioni = new Azioni();
            bool inEsecuzione = true;

            while (inEsecuzione == true)
            {
                //menù di scelta
                Console.WriteLine("-----------------------");
                Console.WriteLine("Comandi: ");
                Console.WriteLine("1: AGGIUNGI ATTIVITÀ");
                Console.WriteLine("2: VISUALIZZA ATTIVITÀ");
                Console.WriteLine("3: RIMUOVI UN'ATTIVITÀ");
                Console.WriteLine("4: RIMUOVI TUTTE LE ATTIVITÀ");
                Console.WriteLine("5: ESCI");
                Console.WriteLine("-----------------------");


                int comando = Convert.ToInt32(Console.ReadLine());

                //switch che controlla il comando inserito dall'utente
                switch (comando)
                {
                    case 1:
                        azioni.AggiungiTask();
                        break;
                    case 2:
                        azioni.VisualizzaTask();
                        break;
                    case 3:
                        azioni.RimuoviTask();
                        break;
                    case 4:
                        azioni.RimuoviTutto();
                        break;
                    case 5:
                        inEsecuzione = false;
                        break;
                    default:
                        Console.WriteLine("Comando non valido, riprova.");
                        break;
                }
            }
        }
    }
}
