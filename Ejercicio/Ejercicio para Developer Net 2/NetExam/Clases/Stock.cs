using NetExam.Abstractions;
using NetExam.Dto;
using NetExam.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace NetExam.Clases
{
    static class Stock
    {
        static List<Location> locales;
        static List<Office> oficinas;
        static List<Booking> reservas;

        static Stock()
        {
            locales = new List<Location>();
            oficinas = new List<Office>();
            reservas = new List<Booking>();
        }

        #region SETs

        /// <summary>
        /// Permite setear un nuevo local en locales
        /// </summary>
        /// <param name="location">Recibe el objeto a agregar</param>
        public static void SetLocation(Location location)
        {
            if (locales.Count() > 0)
            {
                for (int i = 0; i < locales.Count; i++)
                {  
                    if (location.Name == locales[i].Name)
                    {
                        LocationAlreadyExistsException ex =
                            new LocationAlreadyExistsException("El local ya existe");
                        throw ex;
                    }
                }

                locales.Add(location);
            }
            else
            {
                locales.Add(location);
            }

        }

        /// <summary>
        /// Permite setear una nueva oficina a oficinas
        /// </summary>
        /// <param name="office">Recibe el objeto a agregar</param>
        public static void SetOffice(Office office)
        {
            if (locales.Count() == 0)
            {
                NotAvailableExcption ex = 
                    new NotAvailableExcption("Sin locales");
                throw ex;
            }
            else
            {
                bool flagFind = false;

                foreach (var item in locales)
                {
                    if (item.Name == office.LocationName)
                    {
                        oficinas.Add(office);
                        flagFind = true;
                        break;
                    }
                }

                if (!flagFind)
                {
                    NotFoundException ex2 = 
                        new NotFoundException("Local inexistente");
                    throw ex2;
                }

            }
        }

        /// <summary>
        /// Permite setear una reserva en reservas
        /// </summary>
        /// <param name="booking">Recibe el objeto a agregar</param>
        public static void SetBooking(Booking booking)
        {
            foreach (var item in oficinas)
            {
                if (item.Name == booking.OfficeName) 
                { 
                    if (item.Availability)
                    {
                        reservas.Add(booking);
                        item.Availability = false;
                        break;
                    }
                    else
                    {
                        NotAvailableExcption ex = 
                            new NotAvailableExcption("Oficina ya ocupada");
                        throw ex;
                    }
                }
            }
        }

        #endregion

        #region GETs

        /// <summary>
        /// Permite obtener los locales
        /// </summary>
        /// <returns>Listado de locales</returns>
        public static IEnumerable<ILocation> GetLocations()
        {
            return locales.AsEnumerable();
        }

        /// <summary>
        /// Permite obtener las oficinas
        /// </summary>
        /// <returns>Listado de oficinas</returns>
        public static IEnumerable<IOffice> GetOffices()
        {
            return oficinas.AsEnumerable();
        }

        /// <summary>
        /// Permite obtener las reservas
        /// </summary>
        /// <returns>Listado de reservas</returns>
        public static IEnumerable<IBooking> GetBookings()
        {
            return reservas.AsEnumerable();
        }

        #endregion

        /// <summary>
        /// Permite obtener un listado de oficinas filtrado segun las especificaciones requeridas
        /// </summary>
        /// <param name="suggestionRequest">Recibe objeto con especificaciones</param>
        /// <returns>Listado de oficinas</returns>
        public static IEnumerable<IOffice> GetOficinasEspecificas(SuggestionRequest suggestionRequest)
        {
            List<Office> auxOficinas = new List<Office>();
        
            if (suggestionRequest.ResourcesNeeded.Count() > 0)
            {
                foreach (Office oficina in oficinas)
                {
                    if (oficina.AvailableResources.Count() > 0)
                    {
                        var aux = suggestionRequest.ResourcesNeeded.Except(oficina.AvailableResources).ToList();
                        if (aux.Count == 0)
                        {
                            auxOficinas.Add(oficina);
                        }
                    }
                }

                if (auxOficinas.Count() < 1)
                {
                    NotAvailableExcption ex = new NotAvailableExcption("No se encontraron oficinas");
                    throw ex;
                }
            }
            else
            {
                foreach (Office oficina in oficinas)
                {
                    if (oficina.MaxCapacity >= suggestionRequest.CapacityNeeded)
                    {
                        auxOficinas.Add(oficina);
                    }
                }
            }

            auxOficinas.Sort((office1, office2) => office1.MaxCapacity - office2.MaxCapacity);
            auxOficinas.Sort((office1, office2) => office1.AvailableResources.Count() - office2.AvailableResources.Count());

            if (suggestionRequest.PreferedNeigborHood != null)
            {
                auxOficinas = ListaPorBarrio(auxOficinas, suggestionRequest.PreferedNeigborHood);
                return auxOficinas.AsEnumerable();
            }
            else
                return auxOficinas.AsEnumerable();
        }

        /// <summary>
        /// Permite obtener un listado con oficinas en el barrio que se requiera
        /// </summary>
        /// <param name="oficinas">Recibe la lista de oficinas</param>
        /// <param name="barrio">Recibe el dato del barrio</param>
        /// <returns>Lista con las oficinas existentes en el barrio indicado</returns>
        static List<Office> ListaPorBarrio(List<Office> oficinas, string barrio)
        {
            List<Office> aux = new List<Office>();
            foreach (Office office in oficinas)
            {
                foreach (Location location in locales)
                {
                    if (location.Name == office.LocationName)
                    {
                        if (location.NeighborhoodName == barrio)
                        {
                            aux.Add(office);
                            break;
                        }
                    }
                }
            }

            if (aux.Count() < 1)
                return oficinas;
            else
              return aux;
        }
    }
}
