using System;

namespace Greenhouse
{
    public class Tulpan
    {
        public int temp_water, temp_air, humid;
        public bool light = true;
        public int number;

        public Tulpan(int number)
        {
            this.number = number;
            Console.WriteLine("Tulpan{0} is planted", number);
        }

    }
}
