

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using TP1.Domain.Models.DTO;
using XmlAndJsonApp.Repositories;

namespace XmlAndJsonApp.Services
{
    public class XmlService : IXmlService
    {
        private readonly IFileRepository _fileRepository;

        public XmlService(IFileRepository fileRepository)
        {

            _fileRepository = fileRepository;
        }


        public async Task<bool> Deserialize(string path)
        {
           

            XmlReaderSettings options = new XmlReaderSettings();

            options.XmlResolver = new XmlUrlResolver();
            options.ValidationType = ValidationType.DTD;
            options.DtdProcessing = DtdProcessing.Parse;
            options.IgnoreComments = true;
            options.IgnoreWhitespace = true;
            options.ValidationEventHandler += Settings_ValidationEventHandler;

            XmlReader reader = XmlReader.Create(path, options);

            var docNavigator = new XPathDocument(reader);
            var nav = docNavigator.CreateNavigator();


            foreach (XPathNavigator item in nav.Select("//visit"))
            {
                var transgressions = item.SelectSingleNode("@transgressions").ValueAsInt;
                var personId = item.SelectSingleNode("personId").ValueAsInt;
                var policeId = item.SelectSingleNode("policeId").Value;
                var dateOfVisit = item.SelectSingleNode("dateOfVisit").ValueAsDateTime;

                var aux = new VisitDTO
                {
                    Transgressions = transgressions,
                    PersonId = personId,
                    PoliceId = policeId,
                    DateOfVisit = dateOfVisit
                };

                if (aux.PersonId != 0 || aux.PoliceId != string.Empty || aux.DateOfVisit != DateTime.MinValue)
                {
                    await _fileRepository.InsertIntoDB(aux);
                }
                else
                {
                    return false;
                }

            }


             static void Settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
            {
                MessageBox.Show($"\nERROR: {e.Message} \r EX: {e.Exception}");
            }



            return true;
        }
    }
}
