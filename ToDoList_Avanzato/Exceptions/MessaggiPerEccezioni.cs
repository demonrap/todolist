namespace ToDoList_Avanzato.Exceptions
{
    public static class MessaggiPerEccezioni
    {
        public static void StampaMessaggioErrore(string messaggio)
        {
            Console.WriteLine($"\nErrore: {messaggio}");
        }

        public static void StampaMessaggioSuccesso(string messaggio)
        {
            Console.WriteLine($"\nSuccesso: {messaggio}");
        }
    }
}