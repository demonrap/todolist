using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp
{
    public abstract class Lista
    {
        public List<string> toDoList = new List<string>();
        public abstract void AggiuntaTask();

        public abstract void VisualizzazioneTask();

        public abstract void VisualizzazioneUltima();

        public abstract void VisualizzazioneNumero();

        public abstract void RimozioneTask();

        public abstract void RimozioneUltima();

        public abstract void RimozioneTotale();

    }

}