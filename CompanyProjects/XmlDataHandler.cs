using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CompanyProjects
{
    class XmlDataHandler : IDataHandler
    {
        private XmlNodeList localNodes;
        private XmlNodeList localPassNodes;
        private string localInsertedName;
        private string localInsertedPass;
        private string localPathToXmlFile;
        private string selectedItem;
        private string[] stringArray = new string[3];

        public XmlDataHandler(string[] stringArray)
        {
            this.stringArray = stringArray;
        }

        public XmlDataHandler(string pathToXmlFile, string selectedItem)
        {
            localPathToXmlFile = pathToXmlFile;
            this.selectedItem = selectedItem;
        }

        public XmlDataHandler(XmlNodeList nodes, String insertedName, XmlNodeList passNodes, String insertedPass)
        {
            localNodes = nodes;
            localInsertedName = insertedName;
            localPassNodes = passNodes;
            localInsertedPass = insertedPass;
        }

        public string PathToXmlFile { get; set; }        

        public string ReadNameAndPass()
        {
            string nameFound = "";
            string passFound = "";
            int iterPasswords = 0;

            foreach (XmlNode node in localNodes)
            {
                if (node.InnerText.Equals(localInsertedName))
                {
                    nameFound = "NAME_OK";

                    XmlNode passNode = localPassNodes[iterPasswords];

                    if (passNode.InnerText.Equals(localInsertedPass))
                    {
                        passFound = "PASS_OK";
                    }
                }                
                iterPasswords++;
            }
            return nameFound + passFound;
        }

        public bool Read()
        {
            bool passFound = false;

            foreach (XmlNode node in localPassNodes)
            {
                if (node.InnerText.Equals(localInsertedPass))
                {
                    passFound = true;
                }
            }
            return passFound;
        }

        public void AddToProject()
        {
            string newAttributeName = "prj";
            //Ulozi sa text z textBoxov do Xml premennych
            //Vlozi sa resp. appenduje sa nova skupina nodov do xml suboru aj s novym atributom pre projekt prjX                                  

            XmlDocument doc = new XmlDocument();
            doc.Load(PathToXmlFile);
            XmlNodeList nodes = doc.SelectNodes("projects/project/name");
            string attributes = "no";
            foreach (XmlNode node in nodes)
            {
                attributes = node.ParentNode.Attributes.Item(0).Value;
            }
            newAttributeName = newAttributeName + ((Int32.Parse(attributes.Substring(attributes.Length - 1, 1)) + 1).ToString());

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(PathToXmlFile);
            XmlNode projectNode = xmlDoc.CreateElement("project");
            XmlAttribute attribute = xmlDoc.CreateAttribute("id");
            attribute.Value = newAttributeName;
            projectNode.Attributes.Append(attribute);
            XmlNode nameNode = xmlDoc.CreateElement("name");
            nameNode.InnerText = stringArray[0];
            projectNode.AppendChild(nameNode);
            XmlNode abbreviationNode = xmlDoc.CreateElement("abbreviation");
            abbreviationNode.InnerText = stringArray[1];
            projectNode.AppendChild(abbreviationNode);
            XmlNode customerNode = xmlDoc.CreateElement("customer");
            customerNode.InnerText = stringArray[2];
            projectNode.AppendChild(customerNode);
            xmlDoc.DocumentElement.AppendChild(projectNode);
            xmlDoc.Save(PathToXmlFile);

        }

        public void EditProject()
        {

        }

        public void DeleteElement()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(localPathToXmlFile);
            XmlNodeList nodes = xmldoc.SelectNodes("projects/project/name");

            //Vymazat cely node z Xml suboru podla vybraneho projektu v listBoxe
            
            foreach (XmlNode node in nodes)
            {
                if (node.InnerText.Equals(selectedItem))
                {                    
                    node.ParentNode.RemoveAll();
                }
            }
            xmldoc.Save(localPathToXmlFile);            
        }
    }
}
