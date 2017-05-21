using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelibLibrairy
{
  public class Position
  {
    public double lat { get; set; }
    public double lng { get; set; }

    public Position(double latitude, double longitude)
    {
      lat = latitude;
      lng = longitude;
    }

    override
    public string ToString()
    {
      string latstr = lat.ToString().Replace(',', '.');
      string lngstr = lng.ToString().Replace(',', '.');
      return latstr + "," + lngstr;

    }
  }
}
