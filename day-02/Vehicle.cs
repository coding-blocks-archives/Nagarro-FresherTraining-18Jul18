using System;

namespace day_02
{
    abstract class Vehicle  // set of features that can "belong" to something
    {
        protected string color;
        protected string name;
        abstract public string GetName();
        abstract public string GetColor();
    }

    class Car : Vehicle
    {
        //  read about access specifiers
        private int noOfSeats;
        private double curSpeed; 
        
        public Car( 
            string name = "Maruti Suzuki 800", 
            int nSeats = 0, 
            double curSpeed = 0, 
            string color = "bltack" )
        {
            this.color = color;
            this.name = name;

            noOfSeats = nSeats;
            this.curSpeed = curSpeed; 
        }

        public int GetSeats(){
            return noOfSeats;
        }
        
        public double GetCurSpeed(){
            return curSpeed;
        }

        override public string GetName(){
            return this.name;
        }

        override public string GetColor(){
            return this.color;
        }
    }
}
