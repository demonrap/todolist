using System;
using System.Collections.Generic;

namespace ProgettoFinale
{
    // Interfaccia che definisce le operazioni per gestire le attività
    public interface IAttivitaManager
    {
        void AggiungiAttivita();        // Metodo per aggiungere una nuova attività
        void VediAttivita();            // Metodo per visualizzare tutte le attività
        void ModificaAttivita();        // Metodo per modificare un'attività esistente
        void RimuoviAttivita();         // Metodo per rimuovere un'attività esistente
        void ConsiglioAttivita();       // Metodo per fornire un suggerimento casuale di attività
    }
}
