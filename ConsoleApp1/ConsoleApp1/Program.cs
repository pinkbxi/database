using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Management;
using System.IO;

namespace NET_Console_base_forms
{
    class Program
    {
        static void Main(string[] args)
        {
            //components created
            Form f = new Form();
            TextBox txtb = new TextBox();
            Button b = new Button();

            //constrols added
            f.Controls.Add(b);
            f.Controls.Add(txtb);

            //button and label texts
            b.Text = "Show save";

            //button and other component locations
            txtb.Location = new Point(89, 70);
            b.Location = new Point(100, 100);

            //click events
            b.Click += B_Click;

            //show components
            txtb.Show();
            b.Show();
            f.ShowDialog();

            //save
            using (StreamWriter sw = new StreamWriter("data.txt"))
            {
                sw.Write(txtb.Text);
            }
        }

        //Show save button click event
        static void B_Click(object sender, EventArgs e)
        {
            string SaveFile;
            using(StreamReader sr = new StreamReader("data.txt"))
            {
                SaveFile = sr.ReadToEnd();
            }
            Label lb = new Label();
            Form f = new Form();

            f.Controls.Add(lb);
            lb.Location = new Point(100, 100);
            lb.Text = SaveFile;

            f.ShowDialog();
        }
    }
}
