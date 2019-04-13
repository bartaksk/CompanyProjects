using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjects
{
    interface IDataHandler
    {
        string ReadNameAndPass();

        bool ReadPass();

        void SaveProject();

        void EditProject();

        void DeleteProject();
        
            
        
    }
}
