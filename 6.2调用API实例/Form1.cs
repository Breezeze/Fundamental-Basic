using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GaoDeRegeo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void btnRegeo_Click(object sender, EventArgs e)
        {
            string location = txtLon.Text + "," + txtLat.Text;
            string str = HttpGetHelper.GaoDeAnalysis("key=d8440a22fb3fc04b72a61aa6b51902a2&location=" + location);
            txtPosition.Text = str;

            PositionInfo user = (PositionInfo)JsonConvert.DeserializeObject(str, typeof(PositionInfo));
            txtPosition.Text = user.regeocode.formatted_address;
            txtProvince.Text = user.regeocode.addressComponent.province;
            txtCity.Text = user.regeocode.addressComponent.city;
        }


        public class PositionInfo
        {
            public string status;
            public string info;
            public string infocode;
            public regeocode regeocode;
        }
        public class regeocode
        {
            public string formatted_address;
            public addressComponent addressComponent;
        }
        public class addressComponent
        {
            public string country;
            public string province;
            public string city;
            public string citycode;
            public string district;
            public string adcode;
            public string township;
            public string towncode;
            public building building;
        }
        public class building
        {
            public streetNumber streetNumber;
        }
        public class streetNumber
        {
            public string street;
            public string number;
            public string location;
            public string direction;
            public string distance;
        }



    }
}
