using System;
using System.Collections.Generic;
using ToDoList.Entities;
using ToDoList.Interface;

namespace ToDoList.Repository
{
    public class AttivitaRepository : IAttivitaRepository
    {
        private Dictionary<int, Attivita> attivitaDictionary = new Dictionary<int, Attivita>(); // Dizionario delle attività
        private int nextKey = 1; // chiave da assegnare a una nuova attività

        public Attivita Create(Attivita item)
        {
            try
            {
                // Assegna la prossima chiave disponibile
                item.Key = nextKey++;
                // Aggiunge l'attività al dizionario
                attivitaDictionary[item.Key] = item;
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la creazione dell'attività: {ex.Message}");
                return null;
            }
        }

        public Attivita GetById(int key)
        {
            try
            {
                // Cerca e restituisce l'attività per chiave
                attivitaDictionary.TryGetValue(key, out var attivita);
                return attivita;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il recupero dell'attività con chiave {key}: {ex.Message}");
                return null;
            }
        }

        public bool Update(Attivita item)
        {
            try
            {
                // Trova l'attività esistente per chiave e aggiorna la descrizione
                if (attivitaDictionary.ContainsKey(item.Key))
                {
                    attivitaDictionary[item.Key].Descrizione = item.Descrizione;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'aggiornamento dell'attività con chiave {item.Key}: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int key)
        {
            try
            {
                // Rimuove l'attività dal dizionario
                return attivitaDictionary.Remove(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'eliminazione dell'attività con chiave {key}: {ex.Message}");
                return false;
            }
        }

        public List<Attivita> GetAll()
        {
            try
            {
                // Restituisce l'intera lista di attività
                return new List<Attivita>(attivitaDictionary.Values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il recupero della lista delle attività: {ex.Message}");
                return new List<Attivita>();
            }
        }

        public void Print(string message)
        {
            try
            {
                // Stampa il messaggio sulla console
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la stampa del messaggio: {ex.Message}");
            }
        }
    }
}

