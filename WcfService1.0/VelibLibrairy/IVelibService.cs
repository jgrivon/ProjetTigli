using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace VelibLibrairy
{
  [ServiceContract]
  public interface IVelibService
  {
    [OperationContract]
    long CalculTrajectory(Coordinates departure, Coordinates destination);

    [OperationContract]
    string HelloWorld();
    
    [OperationContract]
    List<String> GetInstructionsTrajectory(Coordinates depart, Coordinates destination);
  }
}
