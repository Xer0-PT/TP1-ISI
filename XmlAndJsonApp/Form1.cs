using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using TP1.Domain.Models;
using XmlAndJsonApp.Services;

namespace XmlAndJsonApp
{
    public partial class Form1 : Form
    {
        private readonly IJsonService _jsonService;
        private readonly IXmlService _xmlService;


        public Form1()
        {
            InitializeComponent();
            _jsonService = (IJsonService)Program.ServiceProvider.GetService(typeof(IJsonService));
            _xmlService = (IXmlService)Program.ServiceProvider.GetService(typeof(IXmlService));

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog json = new OpenFileDialog();
            json.Filter = "JSON files | *.json";
            json.Multiselect = false;
            if (json.ShowDialog() == DialogResult.OK)
            {
                string path = json.FileName;

                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding()))
                {
                    string content = reader.ReadToEnd();
                    var aux = await _jsonService.Deserialize(content);

                    if (aux == true)
                    {
                        MessageBox.Show("Upload successfull!");
                    }
                    else
                    {
                        MessageBox.Show("Upload error!");
                    }
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog xml = new OpenFileDialog();
            xml.Filter = "XML files | *.xml";
            xml.Multiselect = false;
            if (xml.ShowDialog() == DialogResult.OK)
            {
                string path = xml.FileName;
                var aux = await _xmlService.Deserialize(path);

                if (aux == true)
                {
                    MessageBox.Show("Upload successfull!");
                }
                else
                {
                    MessageBox.Show("Upload error!");
                }


            }
        }

    }
}
