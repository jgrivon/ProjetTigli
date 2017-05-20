using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClientActionLibrairy
{
    [ServiceContract]
    public interface IUserAction
    {
        [OperationContract]
        string GetTime(float lat_start, float lgt_start, float lat_end, float lgt_end);
    }
}
