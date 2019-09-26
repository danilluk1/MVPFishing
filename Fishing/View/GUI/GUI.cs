﻿using Fishing.Presenter;
using Fishing.View.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing
{
    public partial class GUI : Form, IGUI, IGUIPresenter
    {
        GUIPresenter presenter;
        public static GUI gui;
        public GUI()
        {
            InitializeComponent();
            addDeep();
            presenter = new GUIPresenter(this);
            Sounder sounder = new Sounder(SounderPanel, SounderUpdater);
            try
            {
                BaitsPicture.Image = Player.getPlayer().Assembly.Lure.Pict;
            }
            catch (NullReferenceException) { }
            MoneyLValue = Player.getPlayer().Money;
        }

        public int SpeedValue { get => SpeedBar.Value; set => throw new NotImplementedException(); }
        public Bitmap BaitPicture { get => (Bitmap)BaitsPicture.Image; set => BaitsPicture.Image = value; }
        public int DeepValue { get => Convert.ToInt32(DeepLabel.Text); set => DeepLabel.Text = value.ToString(); }
        public int RoadBarValue { get => ReelBar.Value; set => ReelBar.Value = value; }
        public int FLineBarValue { get => FLineBar.Value; set => FLineBar.Value = value; }
        public int EventBoxItemsCount { get => EventsBox.Items.Count; set => throw new NotImplementedException(); }
        public int MoneyLValue { get => Convert.ToInt32(MoneyLabel.Text); set => MoneyLabel.Text = value.ToString(); }

        public event EventHandler MapButtonClick;
        public event EventHandler InventoryButtonClick;
        public event EventHandler MenuButtonClick;
        public event EventHandler SettingsButtonClick;
        public event EventHandler FPondClick;
        public event EventHandler BaitPicClick;

        private void MapLabel_Click(object sender, EventArgs e)
        {
            MapButtonClick?.Invoke(this, e);
        }

        private void InventoryLabel_Click(object sender, EventArgs e)
        {
            InventoryButtonClick?.Invoke(this, e);
        }

        private void MenuLabel_Click(object sender, EventArgs e)
        {
            MenuButtonClick?.Invoke(this, e);
        }

        private void SettingLabel_Click(object sender, EventArgs e)
        {
            SettingsButtonClick?.Invoke(this, e);
        }

        private void FpondBox_Click(object sender, EventArgs e)
        {
            FPondClick?.Invoke(this, e);
        }

        private void BaitsPicture_Click(object sender, EventArgs e)
        {
            BaitPicClick?.Invoke(this, e);
        }

        private void addDeep()
        {
            for (int x = 0; x < 51; x++)
            {
                for (int y = 0; y < 18; y++)
                {
                    LVL.Deeparr[x, y] = new Label()
                    {
                        Left = 5 + x * 20,
                        Top = 350 + y * 20,
                        Height = 20,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = 20,
                        Visible = false,
                    };
                    Controls.Add(LVL.Deeparr[x, y]);
                }
            }
        }

        public void AddEventToBox(string s)
        {
            EventsBox.Items.Add(s);
        }

        public void ClearEvents()
        {
            EventsBox.Items.Clear();
        }
        private void SounderUpdater_Tick(object sender, EventArgs e)
        {
            ReelBar.Refresh();
            FLineBar.Refresh();
        }

        public void IncrementRoadBarValue(int value)
        {
            ReelBar.Increment(value);
        }

        public void IncrementFLineBarValue(int value)
        {
            FLineBar.Increment(value);
        }
    }
}
