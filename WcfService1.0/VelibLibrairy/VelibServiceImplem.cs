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
      long result = 0;
      /*destination.Lattitude - departure.Lattitude
        + destination.Longitude - departure.Longitude;
        */
      return result;
    }

    public List<string> GetInstructionsTrajectory(Coordinates depart, Coordinates destination)
    {
      //using programme 
      string[] temp = Program.GetTrajectoryArray(new Position(depart.Lattitude, depart.Longitude), 
                                                  new Position(destination.Lattitude, destination.Longitude));
      if(temp == null)
      {
        throw new Exception();
      }
      return temp.ToList<string>();
    }

  }
}

