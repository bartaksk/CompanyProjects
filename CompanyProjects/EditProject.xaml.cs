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
    /// Interaction logic for EditProject.xaml
    /// </summary>
    public partial class EditProject : Window
    {
        string nameOfProject;
        string pathToXmlFile;

        public EditProject(string nameOfProject)
        {
            InitializeComponent();
            this.nameOfProject = nameOfProject;
            pathToXmlFile = "../../projects.xml";
            //Fullfill all textboxes
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(pathToXmlFile);
            XmlNodeList nodes = xmldoc.SelectNodes("projects/project/name");
            foreach (XmlNode node in nodes)
            {
                if (node.InnerText.Equals(nameOfProject))
                {
                    txtNickName.Text = node.InnerText;
                    txtAbbreviation.Text = node.NextSibling.InnerText;
                    txtCustomer.Text = node.NextSibling.NextSibling.InnerText;
                }                
            }
        }

        private void btnEditProject_Click(object sender, RoutedEventArgs e)
        {
            //Read values in textboxes and insert them to selected node
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(pathToXmlFile);
            XmlNodeList nodes = xmldoc.SelectNodes("projects/project/name");
            foreach (XmlNode node in nodes)
            {
                if (node.InnerText.Equals(nameOfProject))
                {
                    node.InnerText = txtNickName.Text;
                    node.NextSibling.InnerText = txtAbbreviation.Text;
                    node.NextSibling.NextSibling.InnerText = txtCustomer.Text;
                    xmldoc.Save(pathToXmlFile);

                    MessageBox.Show("New values successfully saved");
                    ProjectsWindow projectsWindow = new ProjectsWindow();                   
                    projectsWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
