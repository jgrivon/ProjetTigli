using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientActionLibrairy
{
   public class GoogleModel : ApiModel
    {
        public int distance { get; set; }
        public int duree { get; set; }
        public string adresse_start { get; set; }
        public string adresse_end { get; set; }
        public string status { get; set; }

        public GoogleModel(int distance, int duree, string start, string end)
        {
            this.distance = distance;
            this.duree = duree;
            this.adresse_start = start;
            this.adresse_end = end;
        }
    }
}
