using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;


namespace WcfService1._0
{
  [DataContract]
  public class Placehoder
  {
    [DataMember]
    public long Longitude
    {
      get { return Longitude;   }
      set { Longitude = value;  }
    }

    [DataMember]
    public long Lattitude
    {
      get { return Lattitude;   }
      set { Lattitude = value;  }
    }
  }
}