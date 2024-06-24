using ToDoList_Avanzato.Entities;
using ToDoList_Avanzato.Interfaces;
using ToDoList_Avanzato.Exceptions;

namespace ToDoList_Avanzato.Management
{
    public class AttivitaManager : IAttivitaManager
    {
        private readonly IAttivitaRepository Repository;

        public AttivitaManager(IAttivitaRepository repository)
        {
            Repository = repository;
        }
        #region Metodi Esecutivi (Core)
        public void Esegui()
        {
            bool inEsecuzione = true;
            MostraMenu();

            while (inEsecuzione)
            {
                string comando = Console.ReadLine();

                switch (comando)
                {
                    case "1":
                        AddAttivita();
                        MostraMessaggioRiapparizioneMenu();
                        break;
                    case "2":
                        MostraAttivita();
                        MostraMessaggioRiapparizioneMenu();
                        break;
                    case "3":
                        DeleteAttivita();
                        MostraMessaggioRiapparizioneMenu();
                        break;
                    case "4":
                        inEsecuzione = false;
                        MostraMessaggioUscita();
                        break;
                    case "5":
                        ModificaAttivita();
                        MostraMessaggioRiapparizioneMenu();
                        break;
                    case "6":
                        SegnaComeCompletata();
                        MostraMessaggioRiapparizioneMenu();
                        break;
                    case "7":
                        SegnaComeNonCompletata();
                        MostraMessaggioRiapparizioneMenu();
                        break;
                    case "8":
                        FiltraAttivita();
                        MostraMessaggioRiapparizioneMenu();
                        break;
                    case "9":
                        MostraMenu();
                        break;
                    default:
                        MostraMessaggioComandoNonValido();
                        break;
                }
            }
        }

        private void MostraMenu()
        {
            Console.WriteLine("\nCosa vuoi fare?");
            Console.WriteLine("1. Aggiungi una nuova attività");
            Console.WriteLine("2. Visualizza le attività");
            Console.WriteLine("3. Rimuovi un'attività");
            Console.WriteLine("4. Esci");
            Console.WriteLine("5. Modifica un'attività");
            Console.WriteLine("6. Segna attività come completata");
            Console.WriteLine("7. Segna attività come non completata");
            Console.WriteLine("8. Filtra un'attività");
            Console.Write("Inserisci il comando: ");
        }
        #endregion

        #region Operazioni di Crud (Principali)
        private void AddAttivita()
        {
            try
            {
                Console.Write("\nInserisci la descrizione dell’attività: ");
                string descrizione = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(descrizione))
                {
                    throw new ArgumentException("La descrizione dell'attività non può essere vuota.");
                }

                var nuovaAttivita = new Attivita
                {
                    Id = Repository.GetAll().Count() + 1,
                    Descrizione = descrizione
                };

                Repository.Add(nuovaAttivita);
                MessaggiPerEccezioni.StampaMessaggioSuccesso("Attività aggiunta con successo.");
            }
            catch (ArgumentException ex)
            {
                MessaggiPerEccezioni.StampaMessaggioErrore($"{ex.Message}");
            }
            catch (Exception ex)
            {
                MessaggiPerEccezioni.StampaMessaggioErrore($"Si è verificato un errore durante l'aggiunta dell'attività: {ex.Message}");
            }
        }

        private void MostraAttivita()
        {
            var attivita = Repository.GetAll();
            Console.WriteLine("\nLe attività sono:");
            foreach (var item in attivita)
            {
                Console.WriteLine($"{item.Id}. {item.Descrizione} - {(item.Completata ? "Completata" : "Da completare")}");
            }
        }

        private void ModificaAttivita()
        {
            Console.Write("\nInserisci l'ID dell'attività da modificare: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Attivita attivitaDaModificare = Repository.GetById(id);
                if (attivitaDaModificare != null)
                {
                    Console.Write("Inserisci la nuova descrizione dell'attività: ");
                    string nuovaDescrizione = Console.ReadLine();

                    attivitaDaModificare.Descrizione = nuovaDescrizione;
                    Console.WriteLine("\nAttività modificata con successo.");
                }
                else
                {
                    Console.WriteLine("\nNessuna attività trovata con questo ID.");
                }
            }
            else
            {
                Console.WriteLine("\nID non valido.");
            }
        }



private void DeleteAttivita()
    {
        try
        {
            Console.Write("\nInserisci l’ID dell’attività da rimuovere: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var attivitaDaRimuovere = Repository.GetById(id);
                if (attivitaDaRimuovere != null)
                {
                    Repository.Remove(id);
                    MessaggiPerEccezioni.StampaMessaggioSuccesso("Attività rimossa con successo.");
                }
                else
                {
                    MessaggiPerEccezioni.StampaMessaggioErrore("Nessuna attività trovata con questo ID.");
                }
            }
            else
            {
                MessaggiPerEccezioni.StampaMessaggioErrore("ID non valido.");
            }
        }
        catch (Exception ex)
        {
            MessaggiPerEccezioni.StampaMessaggioErrore($"Si è verificato un errore durante la rimozione dell'attività: {ex.Message}");
        }
    }

    #endregion

    #region Operazioni di Crud (Opzionali)
    private void SegnaComeCompletata()
        {
            Console.Write("\nInserisci l'ID dell'attività da segnare come completata: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Attivita attivitaDaCompletare = Repository.GetById(id);
                if (attivitaDaCompletare != null)
                {
                    attivitaDaCompletare.Completata = true;
                    Console.WriteLine("\nAttività segnata come completata.");
                }
                else
                {
                    Console.WriteLine("\nNessuna attività trovata con questo ID.");
                }
            }
            else
            {
                Console.WriteLine("\nID non valido.");
            }
        }

        private void SegnaComeNonCompletata()
        {
            Console.Write("\nInserisci l'ID dell'attività da segnare come non completata: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Attivita attivitaDaNonCompletare = Repository.GetById(id);
                if (attivitaDaNonCompletare != null)
                {
                    attivitaDaNonCompletare.Completata = false;
                    Console.WriteLine("\nAttività segnata come non completata.");
                }
                else
                {
                    Console.WriteLine("\nNessuna attività trovata con questo ID.");
                }
            }
            else
            {
                Console.WriteLine("\nID non valido.");
            }
        }

        private void FiltraAttivita()
        {
            Console.WriteLine("\nFiltra per stato:");
            Console.WriteLine("1. Mostra tutte le attività");
            Console.WriteLine("2. Mostra attività completate");
            Console.WriteLine("3. Mostra attività da completare");
            Console.Write("Inserisci il comando: ");

            string filtro = Console.ReadLine();

            switch (filtro)
            {
                case "1":
                    MostraAttivita();
                    break;
                case "2":
                    MostraAttivitaCompletate();
                    break;
                case "3":
                    MostraAttivitaDaCompletare();
                    break;
                default:
                    Console.WriteLine("\nComando non valido per il filtro.");
                    break;
            }
        }

        private void MostraAttivitaCompletate()
        {
            var attivitaCompletate = Repository.GetAll().Where(a => a.Completata);
            Console.WriteLine("\nLe attività completate sono:");
            foreach (var item in attivitaCompletate)
            {
                Console.WriteLine($"{item.Id}. {item.Descrizione}");
            }
        }

        private void MostraAttivitaDaCompletare()
        {
            var attivitaDaCompletare = Repository.GetAll().Where(a => !a.Completata);
            Console.WriteLine("\nLe attività da completare sono:");
            foreach (var item in attivitaDaCompletare)
            {
                Console.WriteLine($"{item.Id}. {item.Descrizione}");
            }
        }
        #endregion

        #region Messaggi
        private void MostraMessaggioRiapparizioneMenu()
        {
            Console.Write("\nInserisci un altro comando. (Help: tasto 9): ");
        }

        private void MostraMessaggioComandoNonValido()
        {
            Console.WriteLine("\nComando non valido. Riprova.");
            Console.Write("Inserisci il comando.  (Help: tasto 9): ");
        }

        private void MostraMessaggioUscita()
        {
            Console.WriteLine("\nGrazie per aver usato la To-Do List. Arrivederci!");
        }
        #endregion

    }
}
