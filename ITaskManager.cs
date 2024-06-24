using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoFinale
{
    public interface ITaskManager
    {
        void AddTask(string task);
        void DisplayTasks();
        void RemoveTask(int taskId);
        void ModifyTask(int taskId, string newTask);
        List<string> GetTasks();
    }
}
