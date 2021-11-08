namespace NetExam
{
    using System;
    using System.Collections.Generic;
    using NetExam.Abstractions;
    using NetExam.Dto;
    using NetExam.Clases;

    public class OfficeRental : IOfficeRental
    {
        public void AddLocation(LocationSpecs locationSpecs)
        {
            Location location = new Location(locationSpecs.Name, locationSpecs.Neighborhood);
            Stock.SetLocation(location);
        }

        public void AddOffice(OfficeSpecs officeSpecs) 
        {
            Office office = new Office(officeSpecs.LocationName, officeSpecs.Name, officeSpecs.MaxCapacity, officeSpecs.AvailableResources);    
            Stock.SetOffice(office);
        }

        public void BookOffice(BookingRequest bookingRequest)
        {
            Booking booking = new Booking(bookingRequest.DateTime, bookingRequest.OfficeName);
            Stock.SetBooking(booking);
        }

        public IEnumerable<IBooking> GetBookings(string locationName, string officeName)
        {
            return Stock.GetBookings();
        }

        public IEnumerable<ILocation> GetLocations()
        {
            return Stock.GetLocations();
        }

        public IEnumerable<IOffice> GetOffices(string locationName)
        {
            return Stock.GetOffices();
        }

        public IEnumerable<IOffice> GetOfficeSuggestion(SuggestionRequest suggestionRequest)
        {
           return Stock.GetOficinasEspecificas(suggestionRequest);
        }
    }
}