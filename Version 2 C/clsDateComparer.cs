using System;
using System.Collections.Generic;

namespace Version_2_C
{
    public sealed class clsDateComparer : IComparer<clsWork>    //now this class cannot be subclassed
                                                                //thread safe. 
    {
        public static readonly clsDateComparer Instance = new clsDateComparer();

        private clsDateComparer()
        {
            System.Windows.Forms.MessageBox.Show("creating new clsDateComparer x");
            //testing code.
        }

        public int Compare(clsWork x, clsWork y)
        {
            //DateTime lcDateX = x.Date;
            //DateTime lcDateY = y.Date;

            return x.Date.CompareTo(y.Date);

            //return lcDateX.CompareTo(lcDateY);
        }
    }

    public sealed class clsDDateComparer : IComparer<clsWork>
    {
        public static readonly clsDDateComparer Instance = new clsDDateComparer();

        private clsDDateComparer() { }

        public int Compare(clsWork x, clsWork y)
        {
            //DateTime lcDateX = x.Date;
            //DateTime lcDateY = y.Date;

            return y.Date.CompareTo(x.Date);

            //return lcDateX.CompareTo(lcDateY);
        }
    }
}
