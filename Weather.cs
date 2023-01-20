using System;

namespace Greenhouse
{
    public class Weather
    {
        int counter = 0;
        int hour = 0, day = 0;
        int temp_water = 20, temp_air = 20, humid = 50;
        bool increase = false;
        const int limit = 5;
        Tulpan[] tulpans;

        public Weather(Tulpan[] tulpans) 
        {
            this.tulpans = tulpans;
            apply();
        }
 
        void setIncreaseFlag()
        {
            int random_state = getRand(0, 2);
            if (random_state == 1)
            {
                increase = true;
            }
            else
            {
                increase = false;
            }

        }

        public void setChanges()
        {
            if (counter == limit)
            {
                counter = 0;
            }
            if (counter == getRand(counter, limit))
            {
                setIncreaseFlag();
                if (increase)
                {
                    temp_air += getRand(0, 2);
                    temp_water += getRand(0, 2);
                    humid += getRand(0, 3);
                    if (humid > 100) humid = 100;
                }
                else
                {
                    temp_air -= getRand(0, 2);
                    temp_water -= getRand(0, 2);
                    humid -= getRand(0, 3);
                    if (humid < 0) humid = 0;
                }
                apply();
            }
            counter++;

            hour++;
            if (hour == 24)
            {
                day++;
                hour = 0;
            }
        }

        void apply()
        {
            for (int i = 0; i < tulpans.Length; i++)
            {
                tulpans[i].temp_air = temp_air;
                tulpans[i].temp_water = temp_water;
                tulpans[i].humid = humid;
            }
        }
        
        int getRand(int from, int to)
        {
            Random rnd = new Random();
            int value = rnd.Next(from, to);
            return value;
        }

    }
}
