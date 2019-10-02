using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saver.BL.Controller
{
    interface IDataSaver
    {
        void Save(string fileName, object item);
        T Load<T>(string fileName);
    }
}
