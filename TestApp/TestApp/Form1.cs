using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"c:\Work\results\52106\";
            string commnet = "Testovaci data 16.10.2022";
            string tempfile = Path.GetTempFileName();
            Directory.SetCurrentDirectory(path);
            string ActualDir = Directory.GetCurrentDirectory();
            //string[] filePaths = Directory.GetFiles(@"c:\Work\results\52106\", "*.log");
            string[] filePaths = Directory.GetFiles(@ActualDir, "*.log");
            for (int j = 0; j < filePaths.Length; j++)
            {
                using (var writer = new FileStream(tempfile, FileMode.Create))
                using (var reader = new FileStream(filePaths[j], FileMode.Open))
                {

                    var stringBytes = Encoding.UTF8.GetBytes(commnet + Environment.NewLine);
                    writer.Write(stringBytes, 0, stringBytes.Length);

                    reader.CopyTo(writer);
                }
                File.Copy(tempfile, filePaths[j], true);
                File.Delete(tempfile);
            }


        }
    }
}
