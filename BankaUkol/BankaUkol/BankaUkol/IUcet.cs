using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaUkol
{
    interface IUcet
    {
        double Zustatek { get; }

        string Vlastnik { get; }
    }
}
