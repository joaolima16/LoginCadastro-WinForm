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
using LoginCadastros.DAO;
namespace LoginCadastros
{
    public partial class Form1 : Form
    {

        SignUp form = new SignUp();
        UserDAO userValidation = new UserDAO();
        public byte[] PictureQuery { get; set; }
        public string PictureLocal { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            form.ShowDialog();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            SelectArchiver();
        }
        private void SelectArchiver()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.ImageLocation = dialog.FileName;
                PictureLocal = dialog.FileName;
            }
            FileStream fsStream = new FileStream(PictureLocal, FileMode.Open, FileAccess.Read);
            BinaryReader dr = new BinaryReader(fsStream);
            PictureQuery = dr.ReadBytes((int)fsStream.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userValidation.Select(txtUser.Text, txtPass.Text,PictureQuery);
            MessageBox.Show(userValidation.Validation);
        }
    }
}
