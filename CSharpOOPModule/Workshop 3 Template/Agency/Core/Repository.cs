using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models;
using Agency.Models.Contracts;

using System;
using System.Collections.Generic;

namespace Agency.Core
{
    public class Repository : IRepository
    {
        private readonly List<IVehicle> vehicles = new List<IVehicle>();
        private readonly List<IJourney> journeys = new List<IJourney>();
        private readonly List<ITicket> tickets = new List<ITicket>();

        public IList<IVehicle> Vehicles
        {
            get
            {
                var copy = new List<IVehicle>(vehicles);
                return copy;
            }
        }
        public IList<IJourney> Journeys
        {
            get
            {
                var copy = new List<IJourney>(journeys);
                return copy;
            }
        }
        public IList<ITicket> Tickets
        {
            get
            {
                var copy = new List<ITicket>(tickets);
                return copy;
            }
        }

        public IBus CreateBus(int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
        {
            var nextId = vehicles.Count;
            var bus = new Bus(++nextId, passengerCapacity, pricePerKilometer, hasFreeTv);
            this.vehicles.Add(bus);
            return bus;
        }

        public IAirplane CreateAirplane(int passengerCapacity, double pricePerKilometer, bool isLowCost)
        {
            int nextId = vehicles.Count;
            IAirplane airplane = new Airplane(++nextId, passengerCapacity, pricePerKilometer, isLowCost);
            this.vehicles.Add(airplane);
            return airplane;
        }

        public ITrain CreateTrain(int passengerCapacity, double pricePerKilometer, int carts)
        {
            int nextId = vehicles.Count;
            ITrain train = new Train(++nextId, passengerCapacity, pricePerKilometer, carts);
            this.vehicles.Add(train);
            return train;
        }

        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            int nextId = journeys.Count;
            IJourney journey = new Journey(++nextId, startLocation, destination, distance, vehicle);
            this.journeys.Add(journey);
            return journey;
        }

        public ITicket CreateTicket(IJourney journey, double administrativeCosts)
        {
            int nextId = tickets.Count;
            ITicket ticket = new Ticket(++nextId, journey, administrativeCosts);
            this.tickets.Add(ticket);
            return ticket;
        }

        public IVehicle FindVehicleById(int id)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Id == id)
                {
                    return vehicle;
                }
            }

            throw new EntityNotFoundException($"Vehicle with id: {id} was not found!");
        }

        public IJourney FindJourneyById(int id)
        {
            foreach (var journey in journeys)
            {
                if (journey.Id == id)
                {
                    return journey;
                }
            }

            throw new EntityNotFoundException($"Journey with id: {id} was not found!");
        }

        public ITicket FindTicketById(int id)
        {
            foreach (var ticket in tickets)
            {
                if (ticket.Id == id)
                {
                    return ticket;
                }
            }

            throw new EntityNotFoundException($"Ticket with id: {id} was not found!");
        }
    }
}
