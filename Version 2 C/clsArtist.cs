using System;
using System.Collections.Generic;

namespace Version_2_C
{
    [Serializable()]
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;

        //private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;

        private string _ArtistName;

        public clsArtist() { }

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            // EditDetails(); //no longer required
        }

        public bool IsDuplicate(string prArtistName)
        {
            return ArtistList.ContainsKey(prArtistName);
        }

        public void NewArtist()
        {
            if (!string.IsNullOrEmpty(Name))
                ArtistList.Add(Name, this);
            else
                throw new Exception("No artist name entered");
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Speciality
        {
            get { return _Speciality; }
            set { _Speciality = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public decimal TotalValue
        {
            get { return _WorksList.GetTotalValue(); }
        }

        public clsWorksList WorksList
        {
            get { return _WorksList; }
        }

        public clsArtistList ArtistList
        {
            get { return _ArtistList; }
        }
    }
}