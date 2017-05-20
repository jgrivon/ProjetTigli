using System;
using VelibLibrairy;

namespace Client3
{
    class Program
    {
        static void Main(string[] args)
        {
      //            Veli service = new ServiceVelibImplem();

      VelibServiceImplem service = new VelibServiceImplem();

      string result = service.HelloWorld();

        Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}