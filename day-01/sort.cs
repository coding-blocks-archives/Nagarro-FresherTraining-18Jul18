using System;
using System.Collections.Generic;

namespace day_01
{

    class Student
    {
        public string name;
        public int marks;
        public Student(string nameOfStudent, int marksOfStudent)
        {
            name = nameOfStudent;
            marks = marksOfStudent;
        }
    }

    class Customer
    {
        public string name;
        public string type;
        public Customer(string cusName, string cusType)
        {
            name = cusName;
            type = cusType;
        }
    }

    class Sort
    {
        public static void main()
        {
            // List<int> curList = new List<int>();
            // curList.Add(1);
            // curList.Add(-2);
            // curList.Add(-40);

            // curList.Sort();

            // foreach(int x in curList){
            //     Console.Write(x + " ");
            // }

            List<Student> curList = new List<Student>();
            curList.Add(new Student("johnny", 20));
            curList.Add(new Student("john", 10));
            curList.Add(new Student("shankey", 7));

            curList.Sort(delegate (Student s1, Student s2)
            {
                // shall s1 come before s2??
                if (s1.marks < s2.marks) { return 0; }
                return 1;
            });

            foreach (var x in curList)
            {
                Console.Write(x.name + " " + x.marks);
                Console.WriteLine();
            }

            // List<Customer> curList = new List<Customer>();
            // curList.Add(new Customer("johnny", "priviledged"));
            // curList.Add(new Customer("johnny2", "normal"));

        }





    }
}