namespace ProgFinale
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITaskManager taskManager = new TaskManager();
            bool running = true;
            while (running)
            {
                Console.WriteLine("Inserisci un comando");
                Console.WriteLine("1, Aggiungi attività");
                Console.WriteLine("2. Visualizza attività");
                Console.WriteLine("3 Rimuovi attività");
                Console.WriteLine("4. Esci Dal Programma");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Inserisci il nome dell'attività");
                        string task = Console.ReadLine();
                        taskManager.AddTask(task);
                        break;

                    case "2":
                        Console.Clear();
                        taskManager.DisplayTasks();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Inserisci l'ID dell'attività da rimuovere:");
                        if (int.TryParse(Console.ReadLine(), out int taskId))
                        {
                            taskManager.RemoveTask(taskId);
                        }
                        else
                        {
                            Console.WriteLine("ID attività non valido.");
                        }
                        break;

                    case "4":
                        Console.Clear();
                        running = false;
                        Console.WriteLine("Arrivederci");
                        break;

                    default:
                        Console.Clear(); 
                        Console.WriteLine("Comando non valido");
                        break;
                }
            }
        }
    }
}
