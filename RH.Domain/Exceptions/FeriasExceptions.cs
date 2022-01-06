using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Exceptions
{
    public class SemDireitoAFeriasException : Exception
    {
        public SemDireitoAFeriasException() : base("Este funcionário não tem direito a férias!")
        { }
    }
}