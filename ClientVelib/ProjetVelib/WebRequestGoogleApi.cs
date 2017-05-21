using GeoCoordinatePortable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVelib
{
  class WebRequestGoogleApi
  {
    private static string apiKey = "AIzaSyDKug9PW5gx8hPH85GgZCul4ZAoiAgsRuE";
    private string uri;

    private void fillCoordDirectionsWithBike(Position start, Position end)
    {
      uri = "https://maps.googleapis.com/maps/api/directions/json?origin=" + start.ToString() + "&destination=" + end.ToString() + "" +
  "&avoid=highways&mode=bicycling&key=" + apiKey;
    }
    private void fillCoordDirectionsFeet(Position start, Position end)
    {
      uri = "https://maps.googleapis.com/maps/api/directions/json?origin=" + start.ToString() + "&destination=" + end.ToString() + "" +
  "&avoid=highways&mode=walking&key=" + apiKey;
    }

    private void fillCoord(string start, string end)
    {
      uri = "https://maps.googleapis.com/maps/api/distancematrix/json?mode=walking&origins=" + start + "&destinations=" + end + "&key=" + apiKey;
    }

    public void GetTrajectoryFoot(Position start, Position end)
    {
      fillCoordDirectionsFeet(start, end);

      WebRequest request = WebRequest.Create(uri);
      request.Credentials = CredentialCache.DefaultCredentials;
      WebResponse response = request.GetResponse();
      Stream dataStream = response.GetResponseStream();
      StreamReader reader = new StreamReader(dataStream);

      string responseFromServer = reader.ReadToEnd();
      reader.Close();
      response.Close();

      

      JObject json = JObject.Parse(responseFromServer);

      //List<String> instructions = new List<string>();
      JArray routes = json.GetValue("routes").ToObject<JArray>();
      JArray legs = routes[0]["legs"].ToObject<JArray>();
      JArray steps = legs[0]["steps"].ToObject<JArray>();
      for(int i=0; i<steps.ToArray().Length || i<10; i++)
      {
        Console.WriteLine(steps[i]["html_instructions"].ToObject<String>());
      }



      /*
      JArray startArr = json.GetValue("origin_addresses").ToObject<JArray>();
      JArray endArr = json.GetValue("destination_addresses").ToObject<JArray>();
      JArray tmp = json.GetValue("rows").ToObject<JArray>();
      JArray tmp2 = tmp[0]["elements"].ToObject<JArray>();


      GoogleModel google = new GoogleModel(
          (int)tmp2[0]["distance"]["value"],
          (int)tmp2[0]["duration"]["value"],
          (string)startArr[0],
          (string)endArr[0]
          );


      return google;
      */
    }



    public GoogleModel Get(GeoCoordinate start, GeoCoordinate end)
    {
      fillCoord(start.ToString(), end.ToString());
      // Create a request for the URL.   
      WebRequest request = WebRequest.Create(uri);
      // If required by the server, set the credentials.  
      request.Credentials = CredentialCache.DefaultCredentials;
      // Get the response.  
      WebResponse response = request.GetResponse();
      // Get the stream containing content returned by the server.  
      Stream dataStream = response.GetResponseStream();
      // Open the stream using a StreamReader for easy access.  
      StreamReader reader = new StreamReader(dataStream);
      // Read the content.  
      string responseFromServer = reader.ReadToEnd();
      reader.Close();
      response.Close();
      JObject json = JObject.Parse(responseFromServer);
      JArray startArr = json.GetValue("origin_addresses").ToObject<JArray>();
      JArray endArr = json.GetValue("destination_addresses").ToObject<JArray>();
      JArray tmp = json.GetValue("rows").ToObject<JArray>();
      JArray tmp2 = tmp[0]["elements"].ToObject<JArray>();

      GoogleModel google = new GoogleModel(
          (int)tmp2[0]["distance"]["value"],
          (int)tmp2[0]["duration"]["value"],
          (string)startArr[0],
          (string)endArr[0]
          );


      return google;
    }

  }
}
