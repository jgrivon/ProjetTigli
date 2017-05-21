using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetVelib
{
  class Program
  {
    static void Main(string[] args)
    {
      Position Depart = new Position(48.853720, 2.338358);
      Position station = findClosestStation(48.853720, 2.338358);
      if(station != null)
      {
        roadToStation(Depart, station);
      }
      else { Console.Error.WriteLine("Position is null !"); }
      Console.ReadKey();
    }

    public static Position findClosestStation(double departlong, double lattitude)
    {
      WebRequestVelibApi test = new WebRequestVelibApi();
      List<VelibModel> datas = test.Get();
      // for example, using random Paris coordinate
      var sCoord = new GeoCoordinate(48.853720, 2.338358);
      int i = 0;
      GoogleModel Min = null;
      Position Arrival = null;
      Console.WriteLine(datas.ToString());

      foreach (VelibModel data in datas)
      {

        if (data.status.Equals("OPEN") && data.available_bikes > 0)
        {
          var eCoord = new GeoCoordinate(data.position.lat, data.position.lng);
          double distance = sCoord.GetDistanceTo(eCoord);

          if (i < 10 && distance <= 2000)
          {
            WebRequestGoogleApi google = new WebRequestGoogleApi();
            GoogleModel result = google.Get(sCoord, eCoord);

            //Cherche la distance minimum 
            if (i == 0)
            {

              Min = result;
              Arrival = new Position(eCoord.Latitude, eCoord.Longitude);
            }
            if ((Min != null) && (result.distance < Min.distance))
            {
              Min = result;
              Arrival = new Position(eCoord.Latitude, eCoord.Longitude);
            }
            i++;

            // Console.WriteLine("départ: "+result.adresse_start+", arrivé: "+result.adresse_end+", distance : "+result.distance+"m, durée:"+result.distance/60+" mn");

          }

        }
      }
      return Arrival;
    }

    public static void roadToStation(Position depart, Position arrive)
    {
      WebRequestGoogleApi directions = new WebRequestGoogleApi();
      directions.GetTrajectoryFoot(depart, arrive);

    }

    
  }
}
