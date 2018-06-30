using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Kagamiisbad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            string checkForFile = System.IO.File.Exists("imageSaved.txt") ? System.IO.File.ReadAllText("imageSaved.txt") : null;
            if(checkForFile != null)
            {
                Bitmap backgroundImage = (Bitmap)Image.FromFile(checkForFile);
                this.BackgroundImage = backgroundImage;
            }

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                Bitmap backgroundImage = (Bitmap)Image.FromFile(file);

                this.BackgroundImage = backgroundImage;

                System.IO.File.WriteAllText("imageSaved.txt", file);
            }
        }
    }
}
