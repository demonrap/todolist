using System.Globalization;
using System.Reflection.Metadata;
using ToDoList.Entities;
using ToDoList.Interface;

namespace ToDoList.Repositories
{
    internal class AttivitaRepository : IAttivitaRepository
    {
        private Dictionary<int, Attivita> dizionarioAttivita = new Dictionary<int, Attivita>();

        public void Aggiungi(Attivita attivita)
        {
            try
            {
                //Verifica se la data di inizio è precedente alla data odierna
                if (attivita.DataInizio < DateTime.Now)
                    throw new ArgumentException("\nLa Data Inserita non è valida. La Data non può essere precedente o uguale alla Data Odierna");

                //Idem Data Fine
                if (attivita.DataInizio >= attivita.DataFine)
                    throw new ArgumentException("\nLa Data Inserita non è valida. La Data di Fine non può essere precedente o uguale alla Data di Inizio");

                //Non permette di registrare attività con date sovrapposte
                foreach (var item in dizionarioAttivita)
                {
                    var i = item.Value;

                    if (attivita.DataInizio >= i.DataInizio && attivita.DataInizio < i.DataFine ||
                        attivita.DataFine > i.DataInizio && attivita.DataFine <= i.DataFine ||
                        attivita.DataInizio <= i.DataInizio && attivita.DataFine >= i.DataFine)
                    {
                        throw new ArgumentException("\nLa Data Inserita non è valida. In quel periodo di tempo sei già occupato");
                    }
                }

                //Aggiunta dell'attività al dizionario
                //Verifico se si tratti di un aggiunta o di un aggiornamento
                //se l'attivita viene creata avrà un id inizializzato a 0,
                //invece l'id sarà sempre maggiore se viene aggiornata
                if (attivita.Id == 0) {
                    attivita.Id = dizionarioAttivita.Count + 1;
                }
                
                //Aggiunge attivita 
                dizionarioAttivita.Add(attivita.Id, attivita);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"L'attività {attivita.Nome} è stata aggiunta alla Lista");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Si è verificato un errore durante l'aggiunta dell'attività: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool Rimuovi(int id)
        {
            try
            {
                //Se l'attività è presente, la elimina
                if (dizionarioAttivita.ContainsKey(id))
                {
                    Attivita attivita = dizionarioAttivita[id];
                    dizionarioAttivita.Remove(id);

                     
                    return true;
                }
                else
                {
                    
                    throw new Exception("L'attività non esiste");
                    
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Errore: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return false;
        }

        public void Visualizza(int scelta)
        {
            try
            {
                if (dizionarioAttivita.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("La lista delle attività è vuota.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                //Creo una lista personalizzata
                List<Attivita> listaAttivita;

                switch (scelta)
                {
                    case 1:
                        //Ordina lista in base a ID
                        listaAttivita = dizionarioAttivita.Values.OrderBy(a => a.Id).ToList();
                        break;
                    case 2:
                        //Ordina Lista in base alla data di inizio più vicina
                        listaAttivita = dizionarioAttivita.Values.OrderBy(a => a.DataInizio).ToList();
                        break;
                    default:
                        throw new ArgumentException("Scelta non valida. Utilizzare 1 per ID o 2 per data.");
                }

                foreach (var attivita in listaAttivita)
                {
                    //Stampa attivita
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine(attivita.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
          
        }


        public void Aggiorna(int id, Attivita attivita)
        {
            try
            {
                    //Chiamo rimuovi nel Program
                    //Rimuovi(id);
                    attivita.Id = id;
                    Aggiungi(attivita);
                
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Errore: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public IList<Attivita> Ricerca(string queryString)
        {
            //Ricerca con query
            
                var listaAttivita = new List<Attivita>();
                foreach (var entity in dizionarioAttivita.Values)
                {
                    listaAttivita.Add(entity);
                }
                if (string.IsNullOrEmpty(queryString)) return listaAttivita;
                return listaAttivita.Where(v => v.Nome.Contains(queryString) || v.Descrizione.Contains(queryString)).ToList();
            
        }

        public Attivita RicercaDaId(int id)
        {
            //Ricerca con ID
            
            foreach (var entity in dizionarioAttivita)
            {
                if (entity.Key == id)
                {
                    return entity.Value; 
                }
            }
            throw new KeyNotFoundException($"Attività con ID {id} non trovata.");
            
            
        }
        //Fine implementazione interfaccia

        //per calendario
        public IList<Attivita> RicercaPerData(DateTime data)
        {
            return dizionarioAttivita.Values.Where(a => a.DataInizio.Date == data.Date || a.DataFine.Date == data.Date).ToList();
        }


    }
}

