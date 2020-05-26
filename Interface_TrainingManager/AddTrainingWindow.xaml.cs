using DataLayer;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Interface_TrainingManager
{
    /// <summary>
    /// Interaction logic for AddTrainingWindow.xaml
    /// </summary>
    public partial class AddTrainingWindow : Window
    {
        public AddTrainingWindow()
        {
            InitializeComponent();
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow v = new MainWindow();
            v.Show();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            TimeSpan time = TimeSpan.Zero;
            int distance = 0;
            TimeSpan duration = TimeSpan.Zero;
            float speed = 0;
            String comment = "";
            int watt = 0;
            TrainingType type = TrainingType.Recuperation;
            BikeType bicycle = BikeType.MountainBike;
            try
            {
                date = DateInpt.SelectedDate.Value;
                DateTime t = DateTime.ParseExact(Timeinput.Text, "h:mm tt", CultureInfo.InvariantCulture);
                time = t.TimeOfDay;
                date = date.Add(time);
                distance = Int32.Parse(DISTANCEINPUT.Text);
                duration = TimeSpan.Parse(DURATIONINPUT.Text);

                if (RecoveryR.IsChecked.Equals(true))
                    type = TrainingType.Recuperation;
                else if (EnduranceR.IsChecked.Equals(true))
                    type = TrainingType.Endurance;
                else
                    type = TrainingType.Interval;

                if (Bike1.IsChecked.Equals(true))
                    bicycle = BikeType.MountainBike;
                else if (Bike2.IsChecked.Equals(true))
                    bicycle = BikeType.IndoorBike;
                else
                    bicycle = BikeType.RacingBike;

                if (!string.IsNullOrWhiteSpace(COMMENTINPUT.Text))
                    comment = COMMENTINPUT.Text;

                if (!string.IsNullOrWhiteSpace(WATTINPUT.Text))
                    watt = Int32.Parse(WATTINPUT.Text);

                if (!string.IsNullOrWhiteSpace(SPEEDINPUT.Text))
                    speed = float.Parse(SPEEDINPUT.Text);
            }
            catch
            {
                MessageBox.Show("Give valid Input");
            }


            TrainingManager person = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));

            if (CyclerBox.IsChecked.Equals(true))
                person.AddCyclingTraining(date, distance, time, speed, watt, type, comment, bicycle);
            else
                person.AddRunningTraining(date, distance, time, speed, type, comment);
            MessageBox.Show("Succes!!!");
            //MessageBox.Show(date.ToString() + " | " + distance.ToString() + " | " + duration.ToString() + " | " + speed + " | " + comment + " | " + type.ToString() + " | " + watt.ToString() + " | " + bicycle.ToString());
        }
    }
}
