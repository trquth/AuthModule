using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Result
{
    public class TheApiResponse
    {
        public long ResponseCode;
        public List<Object> ResponseData = new List<Object>();

        public TheApiResponse(long code, Object data)
        {
            ResponseCode = code;
            AddResponse(data);
        }
        public TheApiResponse(long code)
        {
            ResponseCode = code;
        }

        public void AddResponse(Object obj)
        {
            ResponseData.Add(obj);
        }

    }
}
