using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjects
{
    interface IDataHandler
    {
        string ReadProject();

        void SaveProject();

        void EditProject();

        void DeleteProject();
        
            
        
    }
}
