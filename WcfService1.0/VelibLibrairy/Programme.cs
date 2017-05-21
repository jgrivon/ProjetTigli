using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VelibLibrairy
{
  class Program
  {
    public static string[] GetTrajectoryArray(Position Start, Position Arrival)
    {
     

      Position Depart = Start;//new Position(48.854709, 2.368867);
      Position Arrive = Arrival;//new Position(48.870203, 2.306852);

      Position station = findClosestStation(Depart.lng,Depart.lat);

      string[] instructionsToStation;
      string[] instructionToDestination;

      string[] finalresult = null;


      if (station != null)
      {
        instructionsToStation = roadToStation(Depart, station);
        instructionToDestination = roadToDestination(station, Arrive);

        finalresult = new string[instructionsToStation.Length + 1 + instructionToDestination.Length];

        Array.Copy(instructionsToStation, 0, finalresult, 0, instructionsToStation.Length);
        finalresult[instructionsToStation.Length] = "<br> BIKE STATION : Take a Bike to Continue the trip <br>";
        Array.Copy(instructionToDestination, 0, finalresult, instructionsToStation.Length + 1, instructionToDestination.Length);

     
      }
  
      return finalresult;
    }

    public static Position findClosestStation(double departlong, double lattitude)
    {
      WebRequestVelibApi test = new WebRequestVelibApi();
      List<VelibModel> datas = test.Get();
      // for example, using random Paris coordinate
      var sCoord = new GeoCoordinate(lattitude, departlong);
      int i = 0;
      GoogleModel Min = null;
      Position Arrival = null; 

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

           
          }

        }
      }
      return Arrival;
    }

    public static string[] roadToStation(Position depart, Position arrive)
    {
      WebRequestGoogleApi directions = new WebRequestGoogleApi();
      return directions.GetTrajectoryFoot(depart, arrive);

    }

    public static string[] roadToDestination(Position depart, Position arrive)
    {
      WebRequestGoogleApi directions = new WebRequestGoogleApi();
      return directions.GetTrajectoryBike(depart, arrive);
    }

  }
}
