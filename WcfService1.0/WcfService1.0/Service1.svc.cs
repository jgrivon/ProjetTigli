using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1._0
{
  // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code, le fichier svc et le fichier de configuration.
  // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
  public class Service1 : IService1
  {
    public long CalculTrajectory(Coordinates departure, Coordinates destination)
    {
      long result =
      destination.Lattitude - departure.Lattitude
        + destination.Longitude - departure.Longitude;

      return 0;
    }
  }
}
