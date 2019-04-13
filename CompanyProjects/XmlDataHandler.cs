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
        private String localInsertedName;
        private String localInsertedPass;

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

        public bool ReadPass()
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

        public void DeleteProject()
        {

        }
    }
}
