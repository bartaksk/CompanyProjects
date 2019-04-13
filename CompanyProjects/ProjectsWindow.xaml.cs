using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ProjectsWindow.xaml
    /// </summary>
    public partial class ProjectsWindow : Window
    {

        string pathToXmlFile;

        public ProjectsWindow()
        {
            InitializeComponent();
            pathToXmlFile = "../../projects.xml";
            FillListBox();
        }

        private void FillListBox()
        {
            lboxZoznamProjektov.Items.Clear();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(pathToXmlFile);
            XmlNodeList nodes = xmldoc.SelectNodes("projects/project/name");
            foreach (XmlNode node in nodes)
            {
                lboxZoznamProjektov.Items.Add(node.InnerText);
            }
        }

        private void btnZoznamProjektov_Click(object sender, RoutedEventArgs e)
        {
            //Zavrie toto okno a otvori ProjectsList
            ProjectsList projectsList = new ProjectsList();            
            projectsList.Show();
            this.Close();
            /*Uz v ProjectsList na zaciatku, respektive v konstruktore iterovanim precita vsetky nody z Xml suboru a vsetky
            data nahadze do listBoxu a oddeli medzerou */
        }

        private void btnNovyProjekt_Click(object sender, RoutedEventArgs e)
        {
            NewProject newProject = new NewProject();
            newProject.Show();
            this.Close();
        }

        private void btnEditProjekt_Click(object sender, RoutedEventArgs e)
        {
            if (lboxZoznamProjektov.SelectedItem != null)
            {
                EditProject editProject = new EditProject(lboxZoznamProjektov.SelectedItem.ToString());
                editProject.Show();
                this.Close();
            }
            else MessageBox.Show("Select one project");
        }

        private void btnZmazProjekt_Click(object sender, RoutedEventArgs e)
        {                 
            //Vymazat cely node z Xml suboru podla vybraneho projektu v listBoxe
            if (lboxZoznamProjektov.SelectedItem != null)
            {
                XmlDataHandler xmlDataHandler = new XmlDataHandler(pathToXmlFile, lboxZoznamProjektov.SelectedItem.ToString());
                xmlDataHandler.DeleteElement();
            }
            else MessageBox.Show("Select one project");            
            //Vycistit listBox a natiahnut zoznam nanovo
            FillListBox();
        }
    }
}
