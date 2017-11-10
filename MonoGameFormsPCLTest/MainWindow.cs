﻿using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using System.Windows.Forms;

namespace MonoGameFormsPCLTest
{
    public partial class MainWindow : Form
    {
        DrawTest drawTest = new DrawTest();
        UpdateTest updateTest = new UpdateTest();

        bool CamButtonMouseDown = false;
        System.Drawing.Point CamButtonFirstMouseDownPosition;

        #region Draw Window

        private void drawWindow_VisibleChanged(object sender, System.EventArgs e)
        {
            if (((DrawWindow)sender).Editor != drawTest) ((DrawWindow)sender).Editor = drawTest;
        }

        private void textBoxTestText_TextChanged(object sender, System.EventArgs e)
        {
            drawTest.WelcomeMessage = textBoxTestText.Text;
        }

        #endregion
        
        #region Update Window

        private void updateWindow_VisibleChanged(object sender, System.EventArgs e)
        {
            if (((UpdateWindow)sender).Editor != updateTest) ((UpdateWindow)sender).Editor = updateTest;
        }

        private void buttonMoveCam_MouseUp(object sender, MouseEventArgs e)
        {
            CamButtonMouseDown = false;
        }

        private void buttonMoveCam_MouseDown(object sender, MouseEventArgs e)
        {
            CamButtonFirstMouseDownPosition = e.Location;
            CamButtonMouseDown = true;
        }

        private void buttonMoveCam_MouseMove(object sender, MouseEventArgs e)
        {
            if (CamButtonMouseDown)
            {
                int xDiff = CamButtonFirstMouseDownPosition.X - e.Location.X;
                int yDiff = CamButtonFirstMouseDownPosition.Y - e.Location.Y;

                updateTest.MoveCam(new Vector2(xDiff, yDiff));

                CamButtonFirstMouseDownPosition.X = e.Location.X;
                CamButtonFirstMouseDownPosition.Y = e.Location.Y;
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();            
        }

        private void buttonResetCam_Click(object sender, System.EventArgs e)
        {
            updateTest.ResetCam();
        }
    }
}
