using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Models.Result
{
    public class TheApiRequest
    {
        public List<Object> RequestParams = new List<Object>();
        public TheApiRequest(params object[] objs)
        {
            if (RequestParams == null)
                RequestParams = new List<object>();
            if (objs != null && objs.Count() > 0)
                foreach (var obj in objs)
                {
                    RequestParams.Add(obj);
                }
        }
        public T GetRequest<T>(int index)
        {
            if ((index >= RequestParams.Count) || (RequestParams[index] == null))
                return default(T);

            if (RequestParams[index].GetType() == typeof(JObject))
                return JObject.FromObject(RequestParams[index]).ToObject<T>(); 

            return RequestParams[index].GetType() != typeof(T) ? default(T) : (T)RequestParams[index];
        }
    }
}
