
// Definizione dell'interfaccia per il gestore delle attività Alessandro Vitucci

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgettoFinale;

public interface ITaskManager
{
    void AddTask(string task);
    void DisplayTasks();
    void RemoveTask(int taskId);
    List<string> GetTasks();
    void UpdateTask(int taskId, string newTask);
    bool RegisterUser(string username, string password);
    bool Login(string username, string password);
}
