using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excessoes
{
    public class TabuleiroException : Exception
    {
        public TabuleiroException(string mensagem) : base(mensagem)
        {

        }
    }
}
