using System;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;

namespace CompanyProjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool txtNickNameCleared;
        bool txtPasswordCleared;
        string pathToXmlFile;
        string whatFound;
        private string insertedName;
        private string insertedPass;

        public MainWindow()
        {
            InitializeComponent();
            txtNickNameCleared = false;
            txtPasswordCleared = false;
            pathToXmlFile = "../../loginusersdata.xml";
            whatFound = "";
        }

        private void txtNickName_GotFocus(object sender, RoutedEventArgs e)
        {
            if(!txtNickNameCleared)
            {
                txtNickName.Text = "";
                txtNickNameCleared = true;                
            }
            
        }

        private void txtPasswordA_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtPasswordCleared)
            {
                txtPasswordA.Text = "";
                txtPasswordCleared = true;
            }
        }

        private void btnGotoRegistration_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Porovnat meno so ziskanymi menami zo suboru
            //Ak sa meno nachadza v subore, tak porovnat hesla
            //Ak je heslo rovnake ako to zo suboru, tak prepnut okno na ProjectsWindow
            insertedName = txtNickName.Text;
            insertedPass = txtPasswordA.Text;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(pathToXmlFile);
            XmlNodeList nodes = xmldoc.SelectNodes("users/user/name");
            XmlNodeList passNodes = xmldoc.SelectNodes("users/user/pass");
            XmlDataHandler xmlDataHandler = new XmlDataHandler(nodes, insertedName, passNodes, insertedPass);
            whatFound = xmlDataHandler.ReadNameAndPass();
            if (!(whatFound.Equals("NAME_OK") || whatFound.Equals("NAME_OKPASS_OK")))
            {
                MessageBox.Show("Inserted name does not exist");
            }
            else if(whatFound.Equals("NAME_OK"))
            {
                MessageBox.Show("Inserted password was incorrect");
            }
            else
            {
                //Ak je heslo rovnake ako to zo suboru, tak prepnut okno na ProjectsWindow                
                ProjectsWindow projectsWindow = new ProjectsWindow();
                projectsWindow.Show();
                this.Close();
            }            
        }
    }
}
