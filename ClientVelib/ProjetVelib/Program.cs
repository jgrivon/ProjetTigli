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
            WebRequestVelibApi test = new WebRequestVelibApi();
            List<VelibModel> datas = test.Get();
            // for example, using random Paris coordinate
            var sCoord = new GeoCoordinate(48.853720, 2.338358);
            int i = 0;
            foreach (VelibModel data in datas)
            {
                if (data.status.Equals("OPEN") && data.available_bikes > 0)
                {
                    var eCoord = new GeoCoordinate(data.position.lat, data.position.lng);
                    double distance = sCoord.GetDistanceTo(eCoord);
                    if(i < 10 && distance <= 2000)
                    {
                        i++;
                        WebRequestGoogleApi google = new WebRequestGoogleApi();
                        GoogleModel result = google.Get(sCoord, eCoord);
                      
                        Console.WriteLine("départ: "+result.adresse_start+", arrivé: "+result.adresse_end+", distance : "+result.distance+"m, durée:"+result.distance/60+" mn");
                        
                    }
                           
                }
            }
            Console.ReadKey();
    }
  }
}
