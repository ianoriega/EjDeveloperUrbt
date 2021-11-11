using NetExam.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetExam.Clases
{
    public class Booking : IBooking
    {
        public DateTime DateTime { get; }
        public string OfficeName { get; }

        public Booking(DateTime dateTime, string officeName)
        {
            DateTime = dateTime;
            OfficeName = officeName;
        }

    }
}
