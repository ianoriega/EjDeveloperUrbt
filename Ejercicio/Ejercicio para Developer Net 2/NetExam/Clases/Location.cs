using NetExam.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetExam.Clases
{
    public class Location : ILocation
    {
        string name;
        string neighborhoodName;

        public string Name
        {
            get { return name; }
        }

        public string NeighborhoodName
        {
            get { return neighborhoodName; }
        }
        
        public Location(string name, string neighborhood)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            if (string.IsNullOrWhiteSpace(neighborhood)) throw new ArgumentException(nameof(neighborhood));
           
            this.name = name;
            neighborhoodName = neighborhood;
        }
    }
}
