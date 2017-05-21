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
    private double Longitude_;
    private double Lattitude_;


    [DataMember]
    public double Longitude
    {
      set { Longitude_ = value; }
      get { return Longitude_; }
     
    }

    [DataMember]
    public double Lattitude
    {
      set { Lattitude_ = value; }
      get { return Lattitude_; }
      
    }
  }
}