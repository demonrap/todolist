using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFinale
{
    public interface ITaskManager
    {
        void AddTask(string task);

        void DisplayTasks();

        void RemoveTask(int taskId);

        List<string> GetTasks();

    }
}
