using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Headline : INotifyPropertyChanged
    {
        private DateTime effectiveDate;
        public DateTime EffectiveDate
        {
            get
            {
                return effectiveDate;
            }

            set
            {
                effectiveDate = value;
                OnPropertyChanged("EffectiveDate");
            }
        }

        private string forecastText;
        public string ForecastText
        {
            get
            {
                return forecastText;
            }

            set
            {
                forecastText = value;
                OnPropertyChanged("ForecastText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DailyForecast : INotifyPropertyChanged
    {
        private string maximumTemperature;
        public string MaximumTemperature
        {
            get { return maximumTemperature; }
            set
            {
                maximumTemperature = value;
                OnPropertyChanged("MaximumTemperature");
            }
        }

        private string minimumTemperature;
        public string MinimumTemperature
        {
            get { return minimumTemperature; }
            set
            {
                minimumTemperature = value;
                OnPropertyChanged("MinimumTemperature");
            }
        }

        private string dayText;
        public string DayText
        {
            get { return dayText; }
            set
            {
                dayText = value;
                OnPropertyChanged("DayText");
            }
        }

        private string nightText;
        public string NightText
        {
            get { return nightText; }
            set
            {
                nightText = value;
                OnPropertyChanged("NightText");
            }
        }

        private Temperature temperature;
        public Temperature Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        private Day day;
        public Day Day
        {
            get
            {
                return day;
            }

            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        private Night night;
        public Night Night
        {
            get
            {
                return night;
            }

            set
            {
                night = value;
                OnPropertyChanged("Night");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Minimum : INotifyPropertyChanged
    {
        private float minValue;
        public float Value
        {
            get
            {
                return minValue;
            }

            set
            {
                minValue = value;
                OnPropertyChanged("Value");
            }
        }

        private string unit;
        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
                OnPropertyChanged("Unit");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Maximum : INotifyPropertyChanged
    {
        private float maxValue;
        public float Value
        {
            get
            {
                return maxValue;
            }

            set
            {
                maxValue = value;
                OnPropertyChanged("Value");
            }
        }

        private string unit;
        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
                OnPropertyChanged("Unit");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Temperature : INotifyPropertyChanged
    {
        private Minimum minimum;
        public Minimum Minimum
        {
            get
            {
                return minimum;
            }

            set
            {
                minimum = value;
                OnPropertyChanged("Minimum");
            }
        }

        private Maximum maximum;
        public Maximum Maximum
        {
            get
            {
                return maximum;
            }

            set
            {
                maximum = value;
                OnPropertyChanged("Maximum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Day : INotifyPropertyChanged
    {
        private string iconPhrase;
        public string IconPhrase
        {
            get
            {
                return iconPhrase;
            }

            set
            {
                iconPhrase = value;
                OnPropertyChanged("IconPhrase");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Night : INotifyPropertyChanged
    {
        private string iconPhrase;
        public string IconPhrase
        {
            get
            {
                return iconPhrase;
            }

            set
            {
                iconPhrase = value;
                OnPropertyChanged("IconPhrase");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AccuWeather : INotifyPropertyChanged
    {
        private Headline headline;
        public Headline Headline
        {
            get
            {
                return headline;
            }

            set
            {
                headline = value;
                OnPropertyChanged("Headline");
            }
        }

        private DailyForecast[] dailyForecasts;
        public DailyForecast[] DailyForecasts
        {
            get
            {
                return dailyForecasts;
            }

            set
            {
                dailyForecasts = value;
                OnPropertyChanged("DailyForecasts");
            }
        }

        private DailyForecast dailyForecastDay1;
        public DailyForecast DailyForecastDay1
        {
            get
            {
                return dailyForecastDay1;
            }

            set
            {
                dailyForecastDay1 = value;
                OnPropertyChanged("DailyForecastDay1");
            }
        }

        public AccuWeather()
        {
            Headline = new Headline()
            {
                EffectiveDate = DateTime.Now.AddDays(1),
                ForecastText = "Sunny and clear"
            };

            DailyForecastDay1 = new DailyForecast()
            {
                MaximumTemperature = "75 °F",

                MinimumTemperature = "60 °F",

                DayText = "Sunny",

                NightText = "Cool and clear",

                Day = new Day()
                {
                    IconPhrase = "Sunny"
                },

                Night = new Night()
                {
                    IconPhrase = "Cool and clear"
                },

                Temperature = new Temperature()
                {
                    Maximum = new Maximum()
                    {
                            Value = 75,
                            Unit = "F"
                    },
                            
                    Minimum = new Minimum()
                    {
                        Value = 60,
                        Unit = "F"
                    }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
