using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Country : INotifyPropertyChanged
    {
        private string localizedName;
        public string LocalizedName
        {
            get { return localizedName; }
            set
            {
                localizedName = value;
                OnPropertyChanged("LocalizedName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AdministrativeArea : INotifyPropertyChanged
    {
        private string localizedName;
        public string LocalizedName
        {
            get { return localizedName; }
            set
            {
                localizedName = value;
                OnPropertyChanged("LocalizedName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Result : INotifyPropertyChanged
    {
        private string key;
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                OnPropertyChanged("Key");
            }
        }

        private string localizedName;
        public string LocalizedName
        {
            get { return localizedName; }
            set
            {
                localizedName = value;
                OnPropertyChanged("LocalizedName");
            }
        }

        private Country country;
        public Country Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        private AdministrativeArea administrativeArea;
        public AdministrativeArea AdministrativeArea
        {
            get { return administrativeArea; }
            set
            {
                administrativeArea = value;
                OnPropertyChanged("AdministrativeArea");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CityForList : INotifyPropertyChanged
    {
        private string displayLabel;
        public string DisplayLabel
        {
            get { return displayLabel; }
            set
            {
                displayLabel = value;
                OnPropertyChanged("DisplayLabel");
            }
        }

        private string locationCode;
        public string LocationCode
        {
            get { return locationCode; }
            set
            {
                locationCode = value;
                OnPropertyChanged("LocationCode");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class City : INotifyPropertyChanged
    {
        private List<Result> results;
        public List<Result> Results
        {
            get { return results; }
            set { results = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
