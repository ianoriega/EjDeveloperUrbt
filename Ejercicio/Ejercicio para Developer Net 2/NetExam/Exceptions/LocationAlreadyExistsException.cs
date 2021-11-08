using System;
using System.Collections.Generic;
using System.Text;

namespace NetExam.Exceptions
{
    class LocationAlreadyExistsException : Exception
    {
        public LocationAlreadyExistsException(string cadena) : base(cadena)
        {

        }
    }
}
