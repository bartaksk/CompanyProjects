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
    /// Interaction logic for ProjectsList.xaml
    /// </summary>
    public partial class ProjectsList : Window
    {
        string pathToXmlFile;

        public ProjectsList()
        {
            InitializeComponent();
            pathToXmlFile = "../../projects.xml";
            FillTextBox();
        }

        private void FillTextBox()
        {
            txtDetailedProjectsList.Clear();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(pathToXmlFile);
            XmlNodeList nodes = xmldoc.SelectNodes("projects/project/name");
            foreach (XmlNode node in nodes)
            {
                txtDetailedProjectsList.AppendText(node.InnerText);
                txtDetailedProjectsList.AppendText("\r\n");                
                txtDetailedProjectsList.AppendText(node.NextSibling.InnerText);
                txtDetailedProjectsList.AppendText("\r\n");
                txtDetailedProjectsList.AppendText(node.NextSibling.NextSibling.InnerText);
                txtDetailedProjectsList.AppendText("\r\n");
                txtDetailedProjectsList.AppendText("\r\n");
            }
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            ProjectsWindow projectsWindow = new ProjectsWindow();
            projectsWindow.Show();
            this.Close();
        }
    }
}
