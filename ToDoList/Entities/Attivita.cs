namespace ToDoList.Entities
{
    internal class Attivita
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        public Attivita(string nome, string descrizione, DateTime dataInizio, DateTime dataFine)
        {
            //ID = 0 per AutoIncrement e gestione aggiornamento/aggiunta
            Id = 0;
            Nome = nome;
            Descrizione = descrizione;
            DataInizio = dataInizio;
            DataFine = dataFine;
        }

      
    }
}
