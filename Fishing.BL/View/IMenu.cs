using Fishing.BL.View;
using System;

namespace Fishing.View.Menu
{
    public interface IMenu : IView
    {
        event EventHandler ExitButtonClick;

        event EventHandler MenuLoad;

        string NickNameL { get; set; }

        string lowerLValue { get; set; }
    }
}