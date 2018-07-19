using System;

namespace day_02
{
    public class VehicleUser
    {
        public static void main(){
            Car car1 = new Car("Audi Q3");
            string car1Name = car1.GetName();
            Console.WriteLine(car1Name);
        }
    }
}