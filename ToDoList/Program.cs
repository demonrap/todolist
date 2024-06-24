using System;
using System.Globalization;
using ToDoList.Entities;
using ToDoList.Repositories;

namespace ToDoLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AttivitaRepository listaAttivita = new AttivitaRepository();
            int sceltaMenu = 0;

            while (sceltaMenu != 6)
            {
                //Menu
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n----- To-Do List -----\n");
                Console.WriteLine("1: Aggiungi Attività");
                Console.WriteLine("2: Visualizza Attività");
                Console.WriteLine("3: Ricerca Attività");
                Console.WriteLine("4: Aggiorna Attività");
                Console.WriteLine("5: Rimuovi Attività");

                Console.WriteLine("6: Esci");

                Console.Write("\nScelta: ");
                sceltaMenu = int.Parse(Console.ReadLine());

                switch (sceltaMenu)
                {
                    case 1:
                        GestisciAggiuntaAttivita(listaAttivita);
                        break;

                    case 2:
                        GestisciVisualizzazioneAttivita(listaAttivita);
                        break;

                    case 3:
                        GestisciRicercaAttivita(listaAttivita);
                        break;

                    case 4:
                        GestisciAggiornamentoAttivita(listaAttivita);

                        break;

                    case 5:
                        GestisciRimozioneAttivita(listaAttivita);
                        break;

                    case 6:
                        GestisciUscita();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Comando non valido. Riprova.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                Console.WriteLine();
            }
        }

        #region Gestione Aggiunta Attività

        static void GestisciAggiuntaAttivita(AttivitaRepository listaAttivita)
        {
            //Gestisce Aggiunta di Attivita
            Console.WriteLine("\n----- Aggiungi Attività -----\n");

            Console.Write("Inserisci il nome dell'attività: ");
            string nome = Console.ReadLine();

            Console.Write("Inserisci la descrizione dell'attività: ");
            string descrizione = Console.ReadLine();

            //controlla se il formato della data viene rispettato
            DateTime dataInizio = LeggiData("Inserisci la data di inizio (formato dd/MM/yyyy HH:mm): ");
            DateTime dataFine = LeggiData("Inserisci la data di fine (formato dd/MM/yyyy HH:mm): ");

            Attivita attivita = new Attivita(nome, descrizione, dataInizio, dataFine);
            listaAttivita.Aggiungi(attivita);
        }

        #endregion

        #region Gestione Visualizzazione Attività

        static void GestisciVisualizzazioneAttivita(AttivitaRepository listaAttivita)
        {
            Console.WriteLine("\n----- Visualizza Attività -----\n");

            Console.WriteLine("Come vuoi visualizzare le attività?");
            Console.WriteLine("1: Ordinamento per ID");
            Console.WriteLine("2: Ordinamento per Data di Inizio");
            Console.WriteLine("3: Visualizza Calendario Mensile");

            Console.Write("\nScelta: ");
            int scelta;
            int.TryParse(Console.ReadLine(), out scelta);
            if (scelta == 3)
            {
                VisualizzaCalendario(listaAttivita);
            } else 
            { 
            listaAttivita.Visualizza(scelta);
            }

        }

        #endregion

        #region Gestione Rimozione Attività

        static void GestisciRimozioneAttivita(AttivitaRepository listaAttivita)
        {
            Console.WriteLine("\n----- Rimuovi Attività -----\n");

            int id;
            while (true)
            {
                Console.Write("Inserisci Id dell'Attività da Eliminare: ");
                try
                {
                    id = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input non valido. Inserisci un numero intero.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            listaAttivita.Rimuovi(id);
        }

        #endregion

        #region Gestisci Aggiornamento Attività
        static void GestisciAggiornamentoAttivita(AttivitaRepository listaAttivita)
        {
            Console.WriteLine("\n----- Aggiorna Attività -----\n");

            int id;
            while (true)
            {
                Console.Write("Inserisci Id dell'Attività da Aggiornare: ");
                try
                {
                    id = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input non valido. Inserisci un numero intero.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }


            //Prova a eliminare e verifica che l'eliminazione sia riuscita
            if (listaAttivita.Rimuovi(id))
            {

                //Se ha effettivamente eliminato l'attivita procede con l'aggiunta alla lista
                //Per evitare che l'id venga modificato, ho aggiunto un controllo nella Repo

                Console.Write("Inserisci il nome dell'attività aggiornata: ");
                string nome = Console.ReadLine();

                Console.Write("Inserisci la descrizione dell'attività aggiornata: ");
                string descrizione = Console.ReadLine();

                DateTime dataInizio = LeggiData("Inserisci la data di inizio aggiornata (formato dd/MM/yyyy HH:mm): ");
                DateTime dataFine = LeggiData("Inserisci la data di fine aggiornata (formato dd/MM/yyyy HH:mm): ");

                Attivita attivita = new Attivita(nome, descrizione, dataInizio, dataFine);

                listaAttivita.Aggiorna(id, attivita);
            }


        }
        #endregion

        #region Gestisci Ricerca Attività
        private static void GestisciRicercaAttivita(AttivitaRepository listaAttivita)
        {
            try
            {
                int scelta;
                Console.WriteLine("----- Ricerca Attivita -----");
                Console.WriteLine("1: Ricerca da Id");
                Console.WriteLine("2: Ricerca da Query");
                if (!int.TryParse(Console.ReadLine(), out scelta) || (scelta != 1 && scelta != 2))
                {
                    throw new ArgumentException("Scelta non valida. Utilizzare 1 per ID o 2 per Query.");
                }

                switch (scelta)
                {
                    case 1:
                        //Ricerca con ID
                        Console.WriteLine("Inserisci l'Id dell'attivita da cercare:");
                        Console.Write("ID: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            try
                            {
                                var attivita = listaAttivita.RicercaDaId(id);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nID: {attivita.Id}, Nome: {attivita.Nome}, Descrizione: {attivita.Descrizione}, Data Inizio: {attivita.DataInizio}, Data Fine: {attivita.DataFine}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            catch (KeyNotFoundException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Input non valido. Inserisci un numero intero.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 2:

                        //Ricerca con Query
                        Console.WriteLine("Inserisci il testo da ricercare nella lista delle attivita:");
                        Console.Write("Testo: ");
                        string queryString = Console.ReadLine();
                        try
                        {
                            var risultatoRicerca = listaAttivita.Ricerca(queryString);
                            //Se non trova nessuna attivita che contiene il testo specificato, lancia l'eccezione
                            if (risultatoRicerca.Count == 0)
                            {
                                throw new Exception("Nessuna attività trovata contenente il testo specificato.");
                            }
                            //Stampa le attività trovate
                            foreach (var attivita in risultatoRicerca)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nID: {attivita.Id}, Nome: {attivita.Nome}, Descrizione: {attivita.Descrizione}, Data Inizio: {attivita.DataInizio}, Data Fine: {attivita.DataFine}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    default:
                        throw new ArgumentException("Scelta non valida. Utilizzare 1 per ID o 2 per Query.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion

        #region Gestione Uscita

        static void GestisciUscita()
        {   
            //Gestisce l'uscita
            Console.Clear();
            Console.WriteLine("Grazie per aver usato la To-Do List. Arrivederci!");
            Console.WriteLine("Premi un pulsante per uscire...");
            Console.ForegroundColor= ConsoleColor.Black;
        }

        #endregion

        #region Leggi Data

        static DateTime LeggiData(string messaggio)
        {
            //Prende una data in input  e verifica se rispetta il formato
            DateTime data = new DateTime();
            bool inputValido = false;

            while (!inputValido)
            {
                Console.Write(messaggio);
                string input = Console.ReadLine();

                //Verifica se rispetta il formato
                if (DateTime.TryParseExact(input, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out data))
                {
                    inputValido = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Data non valida. Assicurati di inserire il formato corretto (dd/MM/yyyy HH:mm).");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return data;
        }

        #endregion

        #region Visualizza Calendario
        private static void VisualizzaCalendario(AttivitaRepository listaAttivita)
        {
            //Permette di visualizzare i giorni in base al mese e controlla se sono presenti attività in quel mese
            Console.WriteLine("\n----- Visualizza Calendario -----\n");

            Console.Write("Inserisci il mese (MM): ");
            int mese = int.Parse(Console.ReadLine());

            Console.Write("Inserisci l'anno (YYYY): ");
            int anno = int.Parse(Console.ReadLine());

            //Formato diverso da LeggiData
            DateTime primoGiornoDelMese;
            try
            {
                primoGiornoDelMese = new DateTime(anno, mese, 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Data non valida. Assicurati di inserire un mese e un anno validi.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            int giorniNelMese = DateTime.DaysInMonth(anno, mese);

            //Stampa il nome del mese
            Console.WriteLine("\n" + primoGiornoDelMese.ToString("MMMM yyyy", CultureInfo.CurrentCulture));

            //Stampa Giorni
            Console.WriteLine("Lu Ma Me Gi Ve Sa Do");

            int inizioSettimana = (int)primoGiornoDelMese.DayOfWeek;
            bool almenoUnaAttivitaTrovata = false;
            List<string> attivitaDaStampare = new List<string>();

            for (int i = 0; i < inizioSettimana; i++)
            {
                Console.Write("   ");
            }

            for (int giorno = 1; giorno <= giorniNelMese; giorno++)
            {
                DateTime dataCorrente = new DateTime(anno, mese, giorno);
                var attivitaGiornaliere = listaAttivita.RicercaPerData(dataCorrente);

                //Sostituisci il numero del giorno con "X" se ci sono attività
                string giornoDaStampare = attivitaGiornaliere.Count > 0 ? " X" : $"{giorno,2}";
                Console.Write($"{giornoDaStampare} ");

                if ((giorno + inizioSettimana) % 7 == 0)
                {
                    Console.WriteLine();
                }

                //Aggiunge Attivita trovate alla lista
                if (attivitaGiornaliere.Count > 0)
                {
                    almenoUnaAttivitaTrovata = true;
                    attivitaDaStampare.Add($"\n\nAttività per il giorno {giorno}/{mese}/{anno}:");
                    foreach (var attivita in attivitaGiornaliere)
                    {
                        attivitaDaStampare.Add($"- Nome: {attivita.Nome}, Descrizione: {attivita.Descrizione}, Ora: {attivita.DataInizio:HH:mm}");
                    }
                    
                }
            }

            //Nel caso in cui non trovasse attività
            if (!almenoUnaAttivitaTrovata)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\nNon è presente nessuna attività per questo mese");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                //Stampa tutte le attività trovate
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in attivitaDaStampare)
                {
                    Console.WriteLine(item);
                }
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nLe attivita sono contrassegnate con X sul calendario");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
        }
        #endregion

    }
}
