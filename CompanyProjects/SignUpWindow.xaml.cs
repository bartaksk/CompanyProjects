using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace CompanyProjects
{    
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        string pathToXmlFile;
        bool txtNickNameCleared;
        bool txtPasswordACleared;
        bool txtPasswordBCleared;


        public SignUpWindow()
        {
            InitializeComponent();
            txtNickNameCleared = false;
            txtPasswordACleared = false;
            txtPasswordBCleared = false;
            pathToXmlFile = "../../loginusersdata.xml";
        }

        private void txtNickName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtNickNameCleared)
            {
                txtNickName.Text = "";
                txtNickNameCleared = true;
            }
        }

        private void txtPasswordA_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtPasswordACleared)
            {
                txtPasswordA.Text = "";
                txtPasswordACleared = true;
            }
        }

        private void txtPasswordB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtPasswordBCleared)
            {
                txtPasswordB.Text = "";
                txtPasswordBCleared = true;
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            //Skontrolovat ci ma meno aspon 3 znaky
            //Skontrolovat ci ma heslo aspon 6 znakov
            //Skontrolovat ci je druhe heslo rovnake ako prve

            //Ulozit noveho uzivatela do suboru loginusersdata.xml
            //Zavriet okno registracie a otvorit okno pre login
            if (!(txtNickName.Text.Length < 3) || !(txtPasswordA.Text.Length < 6) || !(txtPasswordA.Text.Equals(txtPasswordB.Text)))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(pathToXmlFile);
                XmlNode projectNode = xmlDoc.CreateElement("user");
                XmlNode nameNode = xmlDoc.CreateElement("name");
                nameNode.InnerText = txtNickName.Text;
                projectNode.AppendChild(nameNode);
                XmlNode passNode = xmlDoc.CreateElement("pass");
                passNode.InnerText = txtPasswordA.Text;
                projectNode.AppendChild(passNode);
                xmlDoc.DocumentElement.AppendChild(projectNode);
                xmlDoc.Save(pathToXmlFile);

                MessageBox.Show("Registration was successfull");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Name must be at least 3 characters long. Password at least 6 characters long. Passwords must be equal.");            
        }
    }
}
