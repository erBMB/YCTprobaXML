using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace probaXML
{
    internal class Utilitati
    {
        public int NrProdus { get; set; }
        public string DataAsamblare { get; set; }
        public string StatieAsamblare { get; set; }
        public string Primul { get; set; }
        public string Doilea { get; set; }
        public string Treilea { get; set; }
        public string oraPrimul { get; set; }
        public string oraDoilea { get; set; }
        public string oraTreilea { get; set; }

        public Utilitati(int nrProdus, string dataAsamblare, string statieAsamblare, string primul, string doilea, string treilea, string oraPrimul, string oraDoilea, string oraTreilea)
        {
            NrProdus = nrProdus;
            DataAsamblare = dataAsamblare;
            StatieAsamblare = statieAsamblare;
            Primul = primul;
            Doilea = doilea;
            Treilea = treilea;
            this.oraPrimul = oraPrimul;
            this.oraDoilea = oraDoilea;
            this.oraTreilea = oraTreilea;
        }

        public Utilitati() 
        { 
        }

        public string ReturnezData(int n)
        {
            string datac;
            switch (n)
            {
                case 1:
                    datac = DateTime.Now.ToString("dd.MM.yyyy@HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
                case 2:
                    datac = DateTime.Now.ToString("HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
                default:
                    datac = DateTime.Now.ToString("dd.MM.yyyy@HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
            }
        }

        public string CautFisier()
        {
            string dir;
            dir=AppDomain.CurrentDomain.BaseDirectory;
            return dir;
        }

        public void IncartDocument()
        {
            XElement xElement = XElement.Load(CautFisier() + "Produse\\" + NrProdus + "_OBC.xml");
        }

        public void CreezFisier()
        {
            if (!Directory.Exists(CautFisier() +"Produse"))
            {
                Directory.CreateDirectory(CautFisier() + "Produse");
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput=true;
            settings.OmitXmlDeclaration=true;
            XmlWriter writer = XmlWriter.Create(CautFisier() + "Produse\\" + NrProdus + "_OBC.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("DetaliiProdus_" + NrProdus.ToString());
            writer.WriteElementString("NumarProdus", NrProdus.ToString());
            writer.WriteElementString("DataAsamblare", DataAsamblare.ToString());
            writer.WriteElementString("StatieAsamblare", Environment.UserName.ToString());
            writer.WriteStartElement("PCBs");
            writer.WriteElementString("Primul", Primul.ToString());
            writer.WriteElementString("Doilea", Doilea.ToString());
            writer.WriteElementString("Treilea", Treilea.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("oraAsamblare");
            writer.WriteElementString("oraPrimul", oraPrimul.ToString());
            writer.WriteElementString("oraDoilea", oraDoilea.ToString());
            writer.WriteElementString("oraTreilea", oraTreilea.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

        }

    }
}
