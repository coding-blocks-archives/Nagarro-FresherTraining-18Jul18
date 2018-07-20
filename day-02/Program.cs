using System;
using AdapterUser;

namespace day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Test.main();
            // VehicleUser.main();
            // day_02_ShapeUser.Main.main();
            StackUser.main();

        }
        public static void InputArray(int[] arr){
            // TODO make a template 
            String[] input = Console.ReadLine().Split(' ');
            for(int i = 0; i < arr.Length; ++i){
                arr[i] = int.Parse(input[i]);
            }
        }
    }
}
