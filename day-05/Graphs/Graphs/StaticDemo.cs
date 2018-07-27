using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class StaticDemo
    {
    }

    class Animal
    {
        // I want to record how many animals have been to this earth so far
        static public int AnimalSoFar;
        string name;

        public Animal()
        {
            ++AnimalSoFar;
            name = "dog " + AnimalSoFar;
        }

        public void getAnimal()
        {
            Console.Write(AnimalSoFar + " " + name);
        }

    }

    class StaticMain
    {
        public void Staticmain()
        {
            Animal a = new Animal();
            Console.WriteLine(Animal.AnimalSoFar);
            a.getAnimal();
        }
    }
}
