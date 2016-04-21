using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Version_2_C
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsPainting.LoadPaintingForm = new clsPainting.LoadFormPaintingDelegate(frmPainting.Run);
            //this is the where the two agents are joined. The class and the form. now a delegate.
            //this is responsible for the joining of the two.
            clsPhotograph.LoadPhotographForm = new clsPhotograph.LoadFormPhotographDelegate(frmPhotograph.Run);
            clsSculpture.LoadSculptureForm = new clsSculpture.LoadFormSculptureDelegate(frmSculpture.Run);
            Application.Run(frmMain.Instance);
        }
    }
}
