using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ServiceClient
{
  class Program
  {
    static void Main(string[] args)
    {
   
      ServiceVelib.VelibServiceClient client = new ServiceVelib.VelibServiceClient();

      Console.WriteLine(client.HelloWorld());

      ServiceVelib.Coordinates dep = new ServiceVelib.Coordinates();
      Console.WriteLine("Entrer le point de départ , Longitude puis Lattitude :");

      dep.Longitude = Convert.ToInt32(Console.ReadLine());
      dep.Lattitude = Convert.ToInt32(Console.ReadLine());
      ServiceVelib.Coordinates arr = new ServiceVelib.Coordinates();

      Console.WriteLine("Entrer le point d'arrivé , Longitude puis Lattitude :");
      arr.Longitude = Convert.ToInt32(Console.ReadLine());
      arr.Lattitude = Convert.ToInt32(Console.ReadLine());

      string[] instructions = client.GetInstructionsTrajectory(dep, arr);

      foreach(String instruction in instructions)
      {
        Console.WriteLine(instruction);
      }
      Console.WriteLine(client.CalculTrajectory(dep, arr));

      Console.ReadKey();

    }
  }
}
