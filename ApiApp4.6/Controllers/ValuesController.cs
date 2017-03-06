using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace ApiApp4._6.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            var uri = Request.RequestUri;
            var props = Request.Properties;
            var result = new
            {
                Method = Request.Method.Method
                , Uri = Request.RequestUri
                , AbsoluteUri = uri.AbsoluteUri
                , AbsolutePath = uri.AbsolutePath
                , Authority = uri.Authority
                , DnsSafeHost = uri.DnsSafeHost
                , Fragment = uri.Fragment
                , Host = uri.Host
                , HostNameType = uri.HostNameType.ToString()
                , IdnHost = uri.IdnHost
                , IsAbsoluteUri = uri.IsAbsoluteUri
                , IsFile = uri.IsFile
                , LocalPath = uri.LocalPath
                , OriginalString = uri.OriginalString
                , PathAndQuery = uri.PathAndQuery
                , Port = uri.Port
                , Query = uri.Query
                , Segments = uri.Segments
                , ParseQueryString = uri.ParseQueryString()
                , Headers = Request.Headers
                , Version = Request.Version
                , Properties = props.Select(kv => $"{kv.Key}: {kv.Value}").ToArray()
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

    }
}
