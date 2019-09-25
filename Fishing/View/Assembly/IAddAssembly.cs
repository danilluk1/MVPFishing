using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing.View.Assembly
{
    interface IAddAssembly
    {
        string AssemblyName { get; set; }
        event EventHandler AddAssemblyClick;
    }
}
