using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Extensions
{
    public class JsonConfiguration
    {
        public string Serialize(object obj)
        {
            var data = new Dictionary<string, object>()
            {
                {"data", obj }
            };

            var jsonObject = JsonConvert.SerializeObject(data, Formatting.Indented, 
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return jsonObject;
        }
    }
}