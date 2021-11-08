using NetExam.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;


namespace NetExam.Clases
{
    class Office : IOffice
    {

        public string LocationName { get; }
        public string Name { get; }
        public int MaxCapacity { get; }
        public IEnumerable<string> AvailableResources { get; }
        public bool Availability { get; set; }

        public Office(string locationName, string name, int maxCapacity)
        {
            LocationName = locationName;
            Name = name;
            Availability = true;
            MaxCapacity = maxCapacity;
        }

        public Office(string locationName, string name, int maxCapacity, IEnumerable<string> availableResources = null) : this(locationName, name, maxCapacity)
        {
            AvailableResources = availableResources ?? new List<string>();
        }

    }
}
