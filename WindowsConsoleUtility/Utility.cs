using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace WindowsConsoleUtility
{
    public class Utility
    {
        public static string Serialize<T>(T data)
        {
            TextWriter tw = new StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;
            XmlWriter writer = XmlWriter.Create(tw, settings);
            XmlSerializer js = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            js.Serialize(writer, data, namespaces);
            return tw.ToString();
        }
    }
}
