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
    public partial class SignUp : Form
    {
        public string PictureLocal { get; set; }
        public byte[] PictureByteGlobal { get; set; }
        public SignUp()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDAO QueryUser = new UserDAO();
            QueryUser.Insert(txtUser.Text,txtPass.Text,txtEmail.Text,PictureByteGlobal);
            MessageBox.Show(QueryUser.Error);
        }
        private void SelectArchiver()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.ImageLocation = dialog.FileName;
                PictureLocal = dialog.FileName;
            }
            FileStream fsStream = new FileStream(PictureLocal, FileMode.Open,FileAccess.Read);
            BinaryReader dr = new BinaryReader(fsStream);
            PictureByteGlobal = dr.ReadBytes((int)fsStream.Length);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectArchiver();
  
        }
    }
}
