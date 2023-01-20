using System;

namespace Greenhouse
{
    public class Datchik
    {
        public int hour = 0, day = 0;
        int temp_water = 28, temp_air = 20, humid = 50;
        bool light = false;
        Tulpan[] tulpans;
        
        public Datchik(Tulpan[] tulpans) {
            this.tulpans = tulpans;
        }

        int get_temp_water()
        {
            return tulpans[0].temp_water;
        }

        void set_temp_water() {
            
            for (int i = 0; i < tulpans.Length; i++)
            {
                show_parameter(tulpans[i].number, "water temperature", tulpans[i].temp_water, temp_water);
                tulpans[i].temp_water = temp_water;
            }
        }

        int get_temp_air()
        {
            return tulpans[0].temp_air;
        }

        void set_temp_air() {
            for (int i = 0; i < tulpans.Length; i++)
            {
                show_parameter(tulpans[i].number, "air temperature", tulpans[i].temp_air, temp_air);
                tulpans[i].temp_air = temp_air;
            }
        }

        int get_humid()
        {
            return tulpans[0].humid;
        }

        void set_humid() {
            for (int i = 0; i < tulpans.Length; i++)
            {
                show_parameter(tulpans[i].number, "humid", tulpans[i].humid, humid);
                tulpans[i].humid = humid;
            }
        }

        void set_light(bool lightState)
        {
            
            for (int i = 0; i < tulpans.Length; i++)
            {
                if (tulpans[i].light != lightState)
                {
                    show_parameter(tulpans[i].number, "light", tulpans[i].light, light);
                    tulpans[i].light = lightState;
                }
            }
        }

        bool get_light()
        {
            return tulpans[0].light;
        }

        public void one_hour()
        {
            hour++;
            if (hour == 24)
            {
                hour = 0;
                day++;
                Console.WriteLine("Day {0}", day);
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine("Hour {0}", hour);
        }

        void show_parameter(int number, string name, int old_value, int new_value) {
            Console.WriteLine("Tulpan{0} {1} is changed from {2} to {3}", number, name, old_value, new_value);
        }
        void show_parameter(int number, string name, bool old_value, bool new_value)
        {
            Console.WriteLine("Tulpan{0} {1} is changed from {2} to {3}", number, name, old_value, new_value);
        }

        public void raspisanie()
        {
            if ((hour <= 6) || (hour >= 20))
            {
                set_light(false);
            }
            else
            {
                set_light(true);
            }

            if ((hour <= 6) || (hour >= 22))
            {
                temp_water = 22;
                temp_air = 18;
            }

            if (temp_water != get_temp_water())
            {
                set_temp_water();
            }
            if (temp_air != get_temp_air())
            {
                set_temp_air();
            }
            if (humid != get_humid())
            {
                set_humid();
            }
        }
    }
}