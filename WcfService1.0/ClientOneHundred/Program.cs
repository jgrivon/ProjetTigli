using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientOneHundred
{
  class Program
  {
    static void Main(string[] args)
    {

      ServiceVelib.VelibServiceClient service = new ServiceVelib.VelibServiceClient();
      ServiceVelib.Coordinates depart = new ServiceVelib.Coordinates()
      {
        Lattitude = 0
      };
      depart.Longitude = 0;

      ServiceVelib.Coordinates arrive = new ServiceVelib.Coordinates()
      {
        Lattitude = 0
      };
      arrive.Longitude = 0;

      Console.WriteLine(service.CalculTrajectory(depart,arrive));
      Console.WriteLine("GG tu peux aller dormir mnt ");
      Console.ReadKey();

    }
  }
}
