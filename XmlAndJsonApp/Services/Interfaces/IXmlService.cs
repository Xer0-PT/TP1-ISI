using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace XmlAndJsonApp.Services
{
    public interface IXmlService
    {
        Task<bool> Deserialize(string path);
    }
}
