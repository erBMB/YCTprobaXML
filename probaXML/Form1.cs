using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace probaXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string primaData;
        string oraPrimul ;
        string oraDoilea ;
        string oraTreilea;
        bool fop=false; //fanion ora primul
        bool fod=false;
        bool fot = false;

        Utilitati utix = new Utilitati();

        private void btnPornire_Click(object sender, EventArgs e)
        {
            Utilitati uti=new Utilitati();
            
            if (File.Exists(uti.CautFisier()+"Produse\\"+txtProdus.Text.ToString()+"_OBC.xml"))
            {
                  XElement xElement=XElement.Load(uti.CautFisier() + "Produse\\" + txtProdus.Text.ToString() + "_OBC.xml");
                primaData = (string)xElement.Element("DataAsamblare");

                if (xElement.Element("PCBs").Element("Primul").Value.Length>=1)
                {
                    fop = true;
                    uti.Primul = (string)xElement.Element("PCBs").Element("Primul");
                    oraPrimul = (string)xElement.Element("oraAsamblare").Element("oraPrimul");
                    txt1.Text = uti.Primul;
                    txt1.BackColor = Color.LightGreen;
                    txt1.ReadOnly = true;
                   
                }
                if (xElement.Element("PCBs").Element("Doilea").Value.Length > 1)
                {
                    fod = true;
                    uti.Doilea = (string)xElement.Element("PCBs").Element("Doilea");
                   oraDoilea = (string)xElement.Element("oraAsamblare").Element("oraDoilea");
                    txt2.Text = uti.Doilea;
                    txt2.BackColor = Color.LightGreen;
                    txt2.ReadOnly = true;
                    
                }
                if (xElement.Element("PCBs").Element("Treilea").Value.Length > 1)
                {
                    fot = true;
                    uti.Treilea = (string)xElement.Element("PCBs").Element("Treilea");
                    oraTreilea = (string)xElement.Element("oraAsamblare").Element("oraTreilea");
                    txt3.Text = uti.Treilea;
                    txt3.BackColor = Color.LightGreen;
                    txt3.ReadOnly = true;
                }
            }
            else
            {
                primaData = uti.ReturnezData(1);
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            if (fop==false)
            {
                System.Threading.Thread.Sleep(100);
                if (fop==false)
                {
                    oraPrimul = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraPrimul = oraPrimul.ToString();
                }
            }
        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {
            if (fod==false)
            {
                System.Threading.Thread.Sleep(100);
                if (fod == false)
                {
                    oraDoilea = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraDoilea = oraDoilea.ToString();
                }
            }
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            if (fot==false)
            {
                System.Threading.Thread.Sleep(100);

                if (fot == false)
                {
                    oraTreilea = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraTreilea = oraTreilea.ToString();
                }
            }
        }

        private void GolescText()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
           

            if (oraPrimul == null)
            {
                oraPrimul = "";
            }
            if (oraDoilea == null)
            {
                oraDoilea = "";
            }
            if (oraTreilea == null)
            {
                oraTreilea = "";
            }

            Utilitati uti4 = new Utilitati(int.Parse(txtProdus.Text), primaData, Environment.UserName,
                txt1.Text.ToString(), txt2.Text.ToString(), txt3.Text.ToString(), oraPrimul.ToString(), oraDoilea.ToString(), oraTreilea.ToString());

            uti4.CreezFisier();
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
