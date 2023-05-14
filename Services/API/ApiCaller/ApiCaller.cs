using Common.Api;
using Common.Exceptions;
using Common.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Services.API.Exceptions;
using Services.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Services.API
{
    public class ApiCaller : IApiCaller
    {
        public T CallApi<T>(Method method, string url, ICollection<KeyValuePair<string, string>>? headers = null, ICollection<KeyValuePair<string, string>>? parameters = null, object? data = null)
        {
            T result = (T)Activator.CreateInstance(typeof(T));

            try
            {
                var client = new RestClient(url)
                {
                    Timeout = -1
                };
                var request = new RestRequest(method);

                if (headers != null)
                {
                    request.AddHeaders(headers);
                }

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        request.AddQueryParameter(parameter.Key, parameter.Value);
                    }
                }

                if (data != null)
                {
                    request.AddJsonBody(data);
                }

                IRestResponse response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new BadRequestException(Messages.GetMessage(Messages.MessageType.IsNotResponsive), response.Content.ToString());
                }

                result = JsonConvert.DeserializeObject<T>(response.Content);
                if (result == null)
                {
                    throw new BadRequestException(Messages.GetMessage(Messages.MessageType.IsNotResponsive));
                }
                return result;
            }
            catch (Exception e)
            {
                throw new LogicException(Messages.GetMessage(Messages.MessageType.IsNotResponsive),e,result);
            }
        }
    }
}