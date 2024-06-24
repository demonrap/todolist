using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFinale
{
    public class TaskManager : ITaskManager
    {
        private readonly List<string> Tasks;

        public TaskManager()
        {
            Tasks = new List<string>();

        }

        public void AddTask(string task)
        {
            Tasks.Add(task);
        }

        public void DisplayTasks()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("Nessuna attività  nella lista");
                return;
            }
            Console.WriteLine("Attività: ");
            for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Tasks[i]}");
            }
        }

        public List<string> GetTasks()
        {
            return Tasks;
        }

        public void RemoveTask(int taskId)
        {
            if (taskId > 0 && taskId <= Tasks.Count)
            {
                Tasks.RemoveAt(taskId - 1);
            }
            else
            {
                Console.WriteLine("ID Attività non valido!");
            }
        }
    }
}


