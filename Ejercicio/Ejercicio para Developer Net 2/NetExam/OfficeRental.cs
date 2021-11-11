namespace NetExam
{
    using System;
    using System.Collections.Generic;
    using NetExam.Abstractions;
    using NetExam.Dto;
    using NetExam.Clases;

    public class OfficeRental : IOfficeRental
    {
        Stock aux;
        public OfficeRental()
        {
            aux = new Stock();
        }

        public void AddLocation(LocationSpecs locationSpecs)
        {
            
            Location location = new Location(locationSpecs.Name, locationSpecs.Neighborhood);
            aux.SetLocation(location);
        }

        public void AddOffice(OfficeSpecs officeSpecs) 
        {
            Office office = new Office(officeSpecs.LocationName, officeSpecs.Name, officeSpecs.MaxCapacity, officeSpecs.AvailableResources);    
            aux.SetOffice(office);
        }

        public void BookOffice(BookingRequest bookingRequest)
        { 
            Booking booking = new Booking(bookingRequest.DateTime, bookingRequest.OfficeName);
            aux.SetBooking(booking);
        }

        public IEnumerable<IBooking> GetBookings(string locationName, string officeName)
        {
            return aux.GetBookings();
        }

        public IEnumerable<ILocation> GetLocations()
        {
            return aux.GetLocations();
        }

        public IEnumerable<IOffice> GetOffices(string locationName)
        {
            return aux.GetOffices();
        }

        public IEnumerable<IOffice> GetOfficeSuggestion(SuggestionRequest suggestionRequest)
        { 
            return aux.GetOficinasEspecificas(suggestionRequest);
        }
    }
}