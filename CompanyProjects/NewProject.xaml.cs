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
    /// Interaction logic for NewProject.xaml
    /// </summary>
    public partial class NewProject : Window
    {
        bool txtNickNameCleared;
        bool txtAbbreviationCleared;
        bool txtCustomerCleared;
        string pathToXmlFile;

        public NewProject()
        {
            InitializeComponent();
            txtNickNameCleared = false;
            txtAbbreviationCleared = false;
            txtCustomerCleared = false;
            pathToXmlFile = "../../projects.xml";
        }

        private void txtNickName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtNickNameCleared)
            {
                txtNickName.Text = "";
                txtNickNameCleared = true;
            }
        }

        private void txtAbbreviation_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtAbbreviationCleared)
            {
                txtAbbreviation.Text = "";
                txtAbbreviationCleared = true;
            }
        }

        private void txtCustomer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtCustomerCleared)
            {
                txtCustomer.Text = "";
                txtCustomerCleared = true;
            }
        }

        private void btnNewProject_Click(object sender, RoutedEventArgs e)
        {
            string[] txtBoxesContent = new string[3];
            txtBoxesContent[0] = txtNickName.Text;
            txtBoxesContent[1] = txtAbbreviation.Text;
            txtBoxesContent[2] = txtCustomer.Text;

            XmlDataHandler xdh = new XmlDataHandler(txtBoxesContent);
            xdh.PathToXmlFile = pathToXmlFile;                        
            xdh.AddToProject();

            MessageBox.Show("New values successfully saved");
            ProjectsWindow projectsWindow = new ProjectsWindow();
            projectsWindow.Show();
            this.Close();
            
        }
    }
}
