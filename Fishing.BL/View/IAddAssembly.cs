using System;

namespace Fishing.View.Assembly
{
    public interface IAddAssembly
    {
        string AssemblyName { get; set; }

        event EventHandler AddAssemblyClick;
    }
}