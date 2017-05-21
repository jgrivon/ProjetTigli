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
    private long Longitude_;
    private long Lattitude_;


    [DataMember]
    public long Longitude
    {
      set { Longitude_ = value; }
      get { return Longitude_; }
     
    }

    [DataMember]
    public long Lattitude
    {
      set { Lattitude_ = value; }
      get { return Lattitude_; }
      
    }
  }
}