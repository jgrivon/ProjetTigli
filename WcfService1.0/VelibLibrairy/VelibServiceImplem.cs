using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelibLibrairy
{
  public class VelibServiceImplem : IVelibService
  {
    public string HelloWorld()
    {
      return "Hello darkness my old friend";
    }
    public long CalculTrajectory(Coordinates departure, Coordinates destination)
    {
      long result =
      destination.Lattitude - departure.Lattitude
        + destination.Longitude - departure.Longitude;

      return result;
    }
  }
}

