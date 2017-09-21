using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.CommonLogging.Serializers
{
    /* 
     Licensed under the Apache License, Version 2.0

     http://www.apache.org/licenses/LICENSE-2.0
     */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
        [XmlRoot(ElementName = "param")]
        public class Param
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "conversionPattern")]
        public class ConversionPattern
        {
        }

        [XmlRoot(ElementName = "layout")]
        public class Layout
        {
        }

        [XmlRoot(ElementName = "appender")]
        public class Appender
        {
        }


        [XmlRoot(ElementName = "root")]
        public class Root
        {
        }

        [XmlRoot(ElementName = "logger")]
        public class Logger
        {
        }

        [XmlRoot(ElementName = "log4net")]
        public class Log4NetConfig
        {
            [XmlElement(ElementName = "param")]
            public List<Param> Param { get; set; }
            [XmlIgnore, XmlElement(ElementName = "appender")]
            public List<Appender> Appender { get; set; }
            [XmlIgnore, XmlElement(ElementName = "root")]
            public Root Root { get; set; }
            [XmlIgnore, XmlElement(ElementName = "logger")]
            public List<Logger> Logger { get; set; }
            [XmlIgnore, XmlAttribute(AttributeName = "debug")]
            public string Debug { get; set; }
        }
    }
}
