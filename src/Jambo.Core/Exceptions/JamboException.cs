using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Exceptions
{
    public class JamboException : Exception
    {
        public JamboException(int codigo, string mensagem)
        {
            this.Codigo = codigo;
            this.Mensagem = mensagem;
        }

        public int Codigo { get; private set; }
        public string Mensagem { get; private set; }
    }
}
