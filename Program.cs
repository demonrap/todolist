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
                Console.WriteLine("Programma: ");
                Console.WriteLine("1: Aggiunta di una attività");
                Console.WriteLine("2: Visualizzazione di tutte le attività");
                Console.WriteLine("3: Visualizzazione dell'ultima attività inserita");
                Console.WriteLine("4: Visualizzazione del numero totale di attività");
                Console.WriteLine("5: Rimozione di una attività");
                Console.WriteLine("6: Rimozione dell'ultima attività inserita");
                Console.WriteLine("7: Rimozione di tutte le attività");
                Console.WriteLine("8: Uscita");
                Console.WriteLine();

                //Si converte il dato in entrata in modo da renderlo intero e permettere il funzionamento dello switch (implementata anche succesivamente)

                int comando = Convert.ToInt32(Console.ReadLine());

                switch (comando)
                {
                    case 1:
                        azioni.AggiuntaTask();
                        break;
                    case 2:
                        azioni.VisualizzazioneTask();
                        break;
                    case 3:
                        azioni.VisualizzazioneUltima();
                        break;
                    case 4:
                        azioni.VisualizzazioneNumero();
                        break;
                    case 5:                        
                        azioni.RimozioneTask();
                        break;
                    case 6:
                        azioni.RimozioneUltima();
                        break;
                    case 7:
                        azioni.RimozioneTotale();
                        break;
                    case 8:
                        inEsecuzione = false;
                        break;
                    default:
                        Console.WriteLine("Comando non valido, riprovare.");
                        break;
                }
            }
        }

    }
}