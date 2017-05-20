using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VelibLibrairy
{
  [DataContract]
  public class Coordinates
  {
    [DataMember]
    public long Longitude
    {
      get { return Longitude; }
      set { Longitude = value; }
    }

    [DataMember]
    public long Lattitude
    {
      get { return Lattitude; }
      set { Lattitude = value; }
    }
  }
}