using System.Threading;
using Greenhouse;
Main(args);
int Main(string[] args)
{
    int tulpans = 0;
    
    System.Console.WriteLine("How many tulpans do you want to plant?");
    tulpans = System.Int32.Parse(System.Console.ReadLine());
    if (tulpans <= 0) { return 0; }
    Tulpan[] tulpans_array = new Tulpan[tulpans];
    for (int j = 0; j < tulpans; j++)
    {
        tulpans_array[j] = new Tulpan(j + 1);
    }

    Weather weather = new Weather(tulpans_array);
    
    Datchik datchik = new Datchik(tulpans_array);

    while (true) {
        weather.setChanges();

        datchik.raspisanie();
        datchik.one_hour();
        Thread.Sleep(100);
    }
    return 0;
}