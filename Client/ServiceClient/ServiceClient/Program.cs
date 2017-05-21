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
      ServiceReference.VelibServiceClient client = new ServiceReference.VelibServiceClient();

      Console.WriteLine(client.HelloWorld());

      ServiceReference.Coordinates dep = new ServiceReference.Coordinates();
      Console.WriteLine("Entrer le point de départ , Longitude puis Lattitude :");

      dep.Longitude = Convert.ToInt32(Console.ReadLine());
      dep.Lattitude = Convert.ToInt32(Console.ReadLine());
      ServiceReference.Coordinates arr = new ServiceReference.Coordinates();

      Console.WriteLine("Entrer le point d'arrivé , Longitude puis Lattitude :");
      arr.Longitude = Convert.ToInt32(Console.ReadLine());
      arr.Lattitude = Convert.ToInt32(Console.ReadLine());

      
      Console.WriteLine(client.CalculTrajectory(dep, arr));
    
      // Task<long> res = client.CalculTrajectoryAsync(dep, arr);

     //  while (!res.IsCompleted)
     // {
        
      //}
      //Console.WriteLine(res.Result);

      Console.ReadKey();

    }
  }
}
