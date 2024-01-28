using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miskariskatwo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebRequest req = WebRequest.Create(@"http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=0e9b3eb560433b454f9905f902db78fe");
            req.Method = "POST";

            req.ContentType = "application/x-www-urlencoded";

            string str = "";
            openweather openweather;

            WebResponse resp = req.GetResponse();
            using (Stream stream = resp.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    str = sr.ReadToEnd();
                }
            }
            resp.Close();

            textBox1.Text = str;

            openweather = JsonConvert.DeserializeObject<openweather>(str);
            
            label1.Text = openweather.clouds.all.ToString();
        
        }
         
    }
}
