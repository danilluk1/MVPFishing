﻿using Fishing.View.Assembly;
using System;

namespace Fishing.Presenter
{
    public class AssemblyPresenter : BasePresenter
    {
        private readonly IAddAssembly view;

        public event EventHandler CloseForm;

        public AssemblyPresenter(IAddAssembly view)
        {
            this.view = view;
            view.AddAssemblyClick += View_AddAssemblyClick;
        }

        private void View_AddAssemblyClick(object sender, EventArgs e)
        {
            string name = view.AssemblyName;
            Player.GetPlayer().Assemblies.Add(new Assembly(name));
            CloseForm?.Invoke(this, EventArgs.Empty);
        }
    }
}