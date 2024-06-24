using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista.Interfaccie
{
    internal interface ICrud
    {
        void AggiungiAttivita();

        void VisualizzaAttivita();

        void RimuoviAttivita(int id);

    }
}
