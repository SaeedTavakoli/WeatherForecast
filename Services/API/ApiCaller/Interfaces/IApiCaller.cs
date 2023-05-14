using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Services.API.Interfaces
{
    public interface IApiCaller
    {
        T CallApi<T>(Method method, string url, ICollection<KeyValuePair<string, string>>? headers = null, ICollection<KeyValuePair<string, string>>? parameters = null, object? data = null);
    }
}