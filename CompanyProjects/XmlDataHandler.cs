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

        public void SaveProject()
        {

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
