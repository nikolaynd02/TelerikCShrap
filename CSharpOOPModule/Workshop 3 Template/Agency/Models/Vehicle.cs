using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models
{
    public abstract class Vehicle : IVehicle
    {
        private int id;
        private int passengerCap;
        private double pricePerKm;

        public Vehicle(int id, int passengerCap, double pricePerKm)
        {
            Id = id;
            PassengerCapacity = passengerCap;
            PricePerKilometer = pricePerKm;
        }

        public int Id
        {
            get { return id; }
            private set
            {
                id = value;
            }
        }
        public int PassengerCapacity
        {
            get { return passengerCap; }
            private set 
            { 

                passengerCap = value; 
            }
        }

        public double PricePerKilometer
        {
            get { return pricePerKm; }
            private set 
            { 
                pricePerKm = value; 
            }
        }

        public abstract string Print();
    }
}
