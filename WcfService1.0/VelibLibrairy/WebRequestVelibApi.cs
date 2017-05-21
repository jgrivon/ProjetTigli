using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace VelibLibrairy
{
  class WebRequestVelibApi
  {
    private static string contractName = "Paris";
    private static string apiKey = "6e0b0fc2be5ababcfad0e80ea1dea2ad81e6f4ac";
    private static string uri = "https://api.jcdecaux.com/vls/v1/stations?contract=" + contractName + "&apiKey=" + apiKey;

    public List<VelibModel> Get()
    {
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
      var list = JsonConvert.DeserializeObject<List<VelibModel>>(responseFromServer);
      return list;
    }
  }
}
