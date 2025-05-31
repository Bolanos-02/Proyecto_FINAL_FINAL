using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_de_clases
{
    public interface Comparador
    {
        bool IgualQue(object q);
        bool MenorQue(object q);
        bool MenorIgualQue(object q);
        bool MayorQue(object q);
        bool MayorIgualQue(object q);
    }
}