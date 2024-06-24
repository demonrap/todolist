using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities
{
    internal class Attivita
    {
        public int Prio { get; set; }
        public int Key { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
       

        public Attivita(int id, string nome, string descrizione, int prio, DateTime datascadenza)
        {
            Key = id;
            Nome = nome;
            Descrizione = descrizione;
            Prio = prio;
            DataScadenza=datascadenza;
        }

       
    }
}
