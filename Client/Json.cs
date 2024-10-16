using System;
using Newtonsoft.Json;

namespace ImperialTablet.Client
{
    public static class Json
    {
        public static string Stringify(object data)
        {
            if (data is null)
            {
                return null;
            }

            string json;

            try
            {
                JsonSerializerSettings settings = new()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                };

                json = JsonConvert.SerializeObject(data, settings);
            }
            catch (Exception)
            {
                json = null;
            }

            return json;
        }
    }
}