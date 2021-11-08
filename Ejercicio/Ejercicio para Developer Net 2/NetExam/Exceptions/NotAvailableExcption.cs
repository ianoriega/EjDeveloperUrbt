using System;
using System.Collections.Generic;
using System.Text;

namespace NetExam.Exceptions
{
    class NotAvailableExcption : Exception
    {
        public NotAvailableExcption(string cadena) : base(cadena)
        {

        }
    }
}
