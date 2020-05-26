using DataLayer;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ReportAll.xaml
    /// </summary>
    public partial class ReportAll : Window
    {
        public DataTable Dt= new DataTable();
        public ReportAll()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow c = new MainWindow();
            c.Show();
            this.Close();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            int month = Int32.Parse(monthinput.Text);
            int year = Int32.Parse(yearinput.Text);
            TrainingManager manager = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            if (AllRadio.IsChecked.Equals(true))
            {
                Report v = manager.GenerateMonthlyTrainingsReport(year, month);
                testlabel.Content = "TotalSessions: "+ v.TotalSessions.ToString();
                CycleSess.Content = "CycleSessions: " + v.CyclingSessions.ToString();
                RunSess.Content = "RunSessions: " + v.RunningSessions.ToString();
                TotalTime.Content = "TotalTime: " + v.TotalTrainingTime.ToString();
                RunDis.Content = "TotalRunningDistance: " + v.TotalRunningDistance.ToString();
                RuntIme.Content = "TotalRunTime: " + v.TotalRunningTrainingTime.ToString();
                CycleDis.Content = "TotalCycleDistance: " + v.TotalCyclingDistance.ToString();
                CycleTime.Content = "TotalCycleTime: " + v.TotalCyclingTrainingTime.ToString();
                Dt.Rows.Clear();

                DataRow x = Dt.NewRow();
                x[0] = "MaxDistanceCycling";
                x[1] = v.MaxDistanceSessionCycling.Id;
                x[2] = v.MaxDistanceSessionCycling.When;
                x[3] = v.MaxDistanceSessionCycling.Distance.ToString() + " KM";
                x[4] = v.MaxDistanceSessionCycling.Time;
                x[5] = v.MaxDistanceSessionCycling.AverageSpeed;
                x[6] = v.MaxDistanceSessionCycling.Comments;
                x[7] = v.MaxDistanceSessionCycling.TrainingType;
                x[8] = v.MaxDistanceSessionCycling.AverageWatt;
                x[9] = v.MaxDistanceSessionCycling.BikeType;
                Dt.Rows.Add(x);

                DataRow xt = Dt.NewRow();
                xt[0] = "MaxDistanceRunner";
                xt[1] = v.MaxDistanceSessionRunning.Id;
                xt[2] = v.MaxDistanceSessionRunning.When;
                xt[3] = v.MaxDistanceSessionRunning.Distance.ToString() + " M";
                xt[4] = v.MaxDistanceSessionRunning.Time;
                xt[5] = v.MaxDistanceSessionRunning.AverageSpeed;
                xt[6] = v.MaxDistanceSessionRunning.Comments;
                xt[7] = v.MaxDistanceSessionRunning.TrainingType;
                Dt.Rows.Add(xt);

                DataRow xv = Dt.NewRow();
                xv[0] = "MaxSpeedRunner";
                xv[1] = v.MaxSpeedSessionRunning.Id;
                xv[2] = v.MaxSpeedSessionRunning.When;
                xv[3] = v.MaxSpeedSessionRunning.Distance.ToString() + " M";
                xv[4] = v.MaxSpeedSessionRunning.Time;
                xv[5] = v.MaxSpeedSessionRunning.AverageSpeed;
                xv[6] = v.MaxSpeedSessionRunning.Comments;
                xv[7] = v.MaxSpeedSessionRunning.TrainingType;
                Dt.Rows.Add(xv);

                DataRow xf = Dt.NewRow();
                xf[0] = "MaxSpeedCycling";
                xf[1] = v.MaxSpeedSessionCycling.Id;
                xf[2] = v.MaxSpeedSessionCycling.When;
                xf[3] = v.MaxSpeedSessionCycling.Distance.ToString() + " KM";
                xf[4] = v.MaxSpeedSessionCycling.Time;
                xf[5] = v.MaxSpeedSessionCycling.AverageSpeed;
                xf[6] = v.MaxSpeedSessionCycling.Comments;
                xf[7] = v.MaxSpeedSessionCycling.TrainingType;
                xf[8] = v.MaxSpeedSessionCycling.AverageWatt;
                xf[9] = v.MaxSpeedSessionCycling.BikeType;
                Dt.Rows.Add(xf);

                DataRow xq = Dt.NewRow();
                xq[0] = "MaxWattCycling";
                xq[1] = v.MaxWattSessionCycling.Id;
                xq[2] = v.MaxWattSessionCycling.When;
                xq[3] = v.MaxWattSessionCycling.Distance.ToString() + " KM";
                xq[4] = v.MaxWattSessionCycling.Time;
                if (v.MaxWattSessionCycling.AverageSpeed.Equals(null))
                    v.MaxWattSessionCycling.AverageSpeed = 0;
                xq[5] = v.MaxWattSessionCycling.AverageSpeed;
                xq[6] = v.MaxWattSessionCycling.Comments;
                xq[7] = v.MaxWattSessionCycling.TrainingType;
                xq[8] = v.MaxWattSessionCycling.AverageWatt;
                xq[9] = v.MaxWattSessionCycling.BikeType;
                Dt.Rows.Add(xq);

            }
            else if (CyclerRadio.IsChecked.Equals(true))
            {
                Report v = manager.GenerateMonthlyTrainingsReport(year, month);
                testlabel.Content = "TotalSessions: " + v.TotalSessions.ToString();
                CycleSess.Content = "CycleSessions: " + v.CyclingSessions.ToString();
                RunSess.Content = "N/A";
                TotalTime.Content = "TotalTime: " + v.TotalTrainingTime.ToString();
                RunDis.Content = "N/A";
                RuntIme.Content = "N/A";
                CycleDis.Content = "TotalCycleDistance: " + v.TotalCyclingDistance.ToString();
                CycleTime.Content = "TotalCycleTime: " + v.TotalCyclingTrainingTime.ToString();
                Dt.Rows.Clear();

                DataRow xf = Dt.NewRow();
                xf[0] = "MaxSpeedCycling";
                xf[1] = v.MaxSpeedSessionCycling.Id;
                xf[2] = v.MaxSpeedSessionCycling.When;
                xf[3] = v.MaxSpeedSessionCycling.Distance.ToString() + " KM";
                xf[4] = v.MaxSpeedSessionCycling.Time;
                xf[5] = v.MaxSpeedSessionCycling.AverageSpeed;
                xf[6] = v.MaxSpeedSessionCycling.Comments;
                xf[7] = v.MaxSpeedSessionCycling.TrainingType;
                xf[8] = v.MaxSpeedSessionCycling.AverageWatt;
                xf[9] = v.MaxSpeedSessionCycling.BikeType;
                Dt.Rows.Add(xf);

                DataRow xq = Dt.NewRow();
                xq[0] = "MaxWattCycling";
                xq[1] = v.MaxWattSessionCycling.Id;
                xq[2] = v.MaxWattSessionCycling.When;
                xq[3] = v.MaxWattSessionCycling.Distance.ToString() + " KM";
                xq[4] = v.MaxWattSessionCycling.Time;
                if (v.MaxWattSessionCycling.AverageSpeed.Equals(null))
                    v.MaxWattSessionCycling.AverageSpeed = 0;
                xq[5] = v.MaxWattSessionCycling.AverageSpeed;
                xq[6] = v.MaxWattSessionCycling.Comments;
                xq[7] = v.MaxWattSessionCycling.TrainingType;
                xq[8] = v.MaxWattSessionCycling.AverageWatt;
                xq[9] = v.MaxWattSessionCycling.BikeType;
                Dt.Rows.Add(xq);

                DataRow x = Dt.NewRow();
                x[0] = "MaxDistanceCycling";
                x[1] = v.MaxDistanceSessionCycling.Id;
                x[2] = v.MaxDistanceSessionCycling.When;
                x[3] = v.MaxDistanceSessionCycling.Distance.ToString() + " KM";
                x[4] = v.MaxDistanceSessionCycling.Time;
                x[5] = v.MaxDistanceSessionCycling.AverageSpeed;
                x[6] = v.MaxDistanceSessionCycling.Comments;
                x[7] = v.MaxDistanceSessionCycling.TrainingType;
                x[8] = v.MaxDistanceSessionCycling.AverageWatt;
                x[9] = v.MaxDistanceSessionCycling.BikeType;
                Dt.Rows.Add(x);

            }
            else if (RunRadio.IsChecked.Equals(true))
            {
                Report v = manager.GenerateMonthlyTrainingsReport(year, month);
                testlabel.Content = "TotalSessions: " + v.TotalSessions.ToString();
                CycleSess.Content = "N/A ";
                RunSess.Content = "RunSessions: " + v.RunningSessions.ToString();
                TotalTime.Content = "TotalTime: " + v.TotalTrainingTime.ToString();
                RunDis.Content = "TotalRunningDistance: " + v.TotalRunningDistance.ToString();
                RuntIme.Content = "TotalRuntIme: " + v.TotalRunningTrainingTime.ToString();
                CycleDis.Content = "N/A " ;
                CycleTime.Content = "N/A " ;
                Dt.Rows.Clear();

                DataRow xt = Dt.NewRow();
                xt[0] = "MaxDistanceRunner";
                xt[1] = v.MaxDistanceSessionRunning.Id;
                xt[2] = v.MaxDistanceSessionRunning.When;
                xt[3] = v.MaxDistanceSessionRunning.Distance.ToString() + " M";
                xt[4] = v.MaxDistanceSessionRunning.Time;
                xt[5] = v.MaxDistanceSessionRunning.AverageSpeed;
                xt[6] = v.MaxDistanceSessionRunning.Comments;
                xt[7] = v.MaxDistanceSessionRunning.TrainingType;
                Dt.Rows.Add(xt);

                DataRow xv = Dt.NewRow();
                xv[0] = "MaxSpeedRunner";
                xv[1] = v.MaxSpeedSessionRunning.Id;
                xv[2] = v.MaxSpeedSessionRunning.When;
                xv[3] = v.MaxSpeedSessionRunning.Distance.ToString() + " M";
                xv[4] = v.MaxSpeedSessionRunning.Time;
                xv[5] = v.MaxSpeedSessionRunning.AverageSpeed;
                xv[6] = v.MaxSpeedSessionRunning.Comments;
                xv[7] = v.MaxSpeedSessionRunning.TrainingType;
                Dt.Rows.Add(xv);

            }
        }

        private void gridview_Loaded(object sender, RoutedEventArgs e)
        {
            Dt.Columns.Add(new DataColumn("Max", typeof(String)));
            Dt.Columns.Add(new DataColumn("ID", typeof(int)));
            Dt.Columns.Add(new DataColumn("Start", typeof(DateTime)));
            Dt.Columns.Add(new DataColumn("Distance", typeof(String)));
            Dt.Columns.Add(new DataColumn("Duration", typeof(TimeSpan)));
            Dt.Columns.Add(new DataColumn("Speed", typeof(int)));
            Dt.Columns.Add(new DataColumn("Comment", typeof(String)));
            Dt.Columns.Add(new DataColumn("Type", typeof(int)));
            Dt.Columns.Add(new DataColumn("Watt", typeof(String)));
            Dt.Columns.Add(new DataColumn("Bicycle", typeof(String)));

            gridview.ItemsSource = Dt.DefaultView;
        }
    }
}
