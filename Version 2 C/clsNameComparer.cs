using System;
using System.Collections.Generic;

namespace Version_2_C
{
    //http://www.dofactory.com/net/singleton-design-pattern for reference
    public sealed class clsNameComparer : IComparer<clsWork>
    {
        public static readonly clsNameComparer Instance = new clsNameComparer();

        private clsNameComparer()
        {
            System.Windows.Forms.MessageBox.Show("creating n c .");
        }

        public int Compare(clsWork x, clsWork y)
        {
            string lcNameX = x.Name;
            string lcNameY = y.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
