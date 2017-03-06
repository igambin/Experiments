using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CommonLogging.Attributes;
using IG.Extensions;
using log4net.ObjectRenderer;

namespace CommonLogging.Renderers
{
    [Renders(typeof(HttpRequestMessage))]
    public class HttpRequestMessageRenderer : IObjectRenderer
    {
        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            var message = obj as HttpRequestMessage;
            if (message == null)
            {
                return;
            }
            var renderedMessage = FormatMessage(message);
            writer.WriteLine(renderedMessage);
        }

        private static string FormatMessage(HttpRequestMessage message)
            => $"[{message.Method.Method}|{message.RequestUri.AbsoluteUri}]" +
               $"{message.GetRequestId()}" +
               $"{message.GetClient()}" +
               $"{message.GetContentType()}" +
               $"{message.GetAccept()}";
    }
}
