using System;
using System.Collections.Generic;
using System.Text;

namespace NetExam.Exceptions
{
    class NotFoundException : Exception
    {
        public NotFoundException(string cadena) : base(cadena)
        {

        }
    }
}
