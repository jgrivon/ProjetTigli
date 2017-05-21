using System;
using System.Collections.Generic;
using System.Globalization;
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

      ServiceVelib.Coordinates dep = new ServiceVelib.Coordinates();
      Console.WriteLine("Entrer start point.");
      Console.Write("Longitude : ");
      dep.Longitude = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //2.368867; // 
      Console.Write("Lattitude : ");
      dep.Lattitude = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //48.854709; // 
      ServiceVelib.Coordinates arr = new ServiceVelib.Coordinates();

      Console.WriteLine("Enter Destination point.");
      Console.Write("Longitude : ");
      arr.Longitude =  Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //2.306852; //
      Console.Write("Lattitude : ");
      arr.Lattitude = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //48.870203;//

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
