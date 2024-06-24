namespace ProgettoFinale
{
        public class Program
        {
            static void Main(string[] args)
            {
                ITaskManager taskManager = new TaskManager();
                bool running = true;

                while (running)
                {
                    Console.WriteLine("Buongiorno! Inserisci un comando:");
                    Console.WriteLine("1. Aggiungi attività");
                    Console.WriteLine("2. Visualizza attività");
                    Console.WriteLine("3. Modifica attività");
                    Console.WriteLine("4. Rimuovi attività");
                    Console.WriteLine("5. Esci");

                    string command = Console.ReadLine();

                    switch (command)
                    {
                    case "1":
                            Console.Clear();
                            Console.WriteLine("Inserisci il nome dell'attività:");
                            string task = Console.ReadLine();
                            taskManager.AddTask(task);
                            break;
                    case "2":
                            Console.Clear();
                            taskManager.DisplayTasks();
                            break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Inserisci l'ID dell'attività da modificare:");
                        if (int.TryParse(Console.ReadLine(), out int taskIdModify))
                        {
                            Console.WriteLine("Inserisci il nuovo nome dell'attività:");
                            string newTask = Console.ReadLine();
                            taskManager.ModifyTask(taskIdModify, newTask);
                        }
                        else
                        {
                            Console.WriteLine("ID attività non valido.");
                        }
                        break;
                    case "4":
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
                    case "5":
                        Console.Clear();
                        running = false;
                        Console.WriteLine("Grazie per aver usato la To-Do List. Arrivederci!");
                        break;
                        
                    default:
                        Console.Clear();
                        Console.WriteLine("Comando non valido. Riprova.");
                        break;
                    }
                }
            }
        }
}