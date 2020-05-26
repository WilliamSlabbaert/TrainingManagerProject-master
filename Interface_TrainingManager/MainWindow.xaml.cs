using DataLayer;
using DataLayer.Repositories;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface_TrainingManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public DataTable Dt;
        public DataTable Dt2;


        public TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddTrainingWindow c = new AddTrainingWindow();
            c.Show();
            this.Close();
        }

        private void LoadTrDATA_Load(object sender, RoutedEventArgs e)
        {
            Dt = new DataTable();
            Dt2 = new DataTable();
            Dt.Columns.Add(new DataColumn("ID", typeof(int)));
            Dt.Columns.Add(new DataColumn("Start", typeof(DateTime)));
            Dt.Columns.Add(new DataColumn("Distance in KM", typeof(int)));
            Dt.Columns.Add(new DataColumn("Duration", typeof(TimeSpan)));
            Dt.Columns.Add(new DataColumn("Speed", typeof(int)));
            Dt.Columns.Add(new DataColumn("Comment", typeof(String)));
            Dt.Columns.Add(new DataColumn("Type", typeof(int)));
            Dt.Columns.Add(new DataColumn("Watt", typeof(String)));
            Dt.Columns.Add(new DataColumn("Bicycle", typeof(String)));


            Dt2.Columns.Add(new DataColumn("ID", typeof(int)));
            Dt2.Columns.Add(new DataColumn("Start", typeof(DateTime)));
            Dt2.Columns.Add(new DataColumn("Distance In M", typeof(int)));
            Dt2.Columns.Add(new DataColumn("Duration", typeof(TimeSpan)));
            Dt2.Columns.Add(new DataColumn("Speed", typeof(int)));
            Dt2.Columns.Add(new DataColumn("Comment", typeof(String)));
            Dt2.Columns.Add(new DataColumn("Type", typeof(int)));

            foreach (var item in m.GetAllCyclingSessions())
            {

                DataRow x = Dt.NewRow();
                if (item.Distance == null)
                    x[2] = 0;
                else
                    x[2] = item.Distance;

                if (item.AverageWatt == null)
                    x[7] = "N/A";
                else
                    x[7] = item.AverageWatt.ToString();

                if (item.AverageSpeed == null)
                    x[4] = 0;
                else
                    x[4] = item.AverageSpeed;

                x[0] = item.Id;
                x[1] = item.When;
                x[3] = item.Time;
                x[5] = item.Comments;
                x[6] = item.TrainingType;
                x[8] = item.BikeType.ToString();
                Dt.Rows.Add(x);
            }
            foreach (var item in m.GetAllRunningSessions())
            {
                DataRow x = Dt2.NewRow();
                if (item.Distance == null)
                    x[2] = 0;
                else
                    x[2] = item.Distance;

                if (item.AverageSpeed == null)
                    x[4] = 0;
                else
                    x[4] = item.AverageSpeed;
                x[0] = item.Id;
                x[1] = item.When;
                x[3] = item.Time;
                x[5] = item.Comments;
                x[6] = item.TrainingType;

                Dt2.Rows.Add(x);
            }
            DtaGrid2.ItemsSource = Dt2.DefaultView;
            TrainingGrid_Overview.ItemsSource = Dt.DefaultView;
        }

        private void DeleteAll_click(object sender, RoutedEventArgs e)
        {
            TrainingManager manager = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            Dt.Clear();
            Dt2.Clear();

            List<int> runningIDs = manager.GetAllRunningSessions().Select(x => x.Id).ToList();
            List<int> cyclingIDs = manager.GetAllCyclingSessions().Select(x => x.Id).ToList();

            TrainingManager manager2 = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            manager2.RemoveTrainings(cyclingIDs, runningIDs);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> RunIDS = new List<int> { };
            List<int> CycleIDS = new List<int> { };
            try
            {
                int item = TrainingGrid_Overview.SelectedItems.Cast<DataRowView>().Select(x => Dt.Rows.IndexOf(x.Row)).ToList().First();
                DataRow r = Dt.Rows[item];
                if (item != null)
                {
                    CycleIDS.Add(((int)r[0]));
                    Dt.Rows.RemoveAt(item);
                }
                TrainingManager manager2 = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
                manager2.RemoveTrainings(CycleIDS, RunIDS);
            }
            catch
            {
                MessageBox.Show("Select Item");
            }

        }

        private void RemoveButton2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<int> RunIDS = new List<int> { };
                List<int> CycleIDS = new List<int> { };

                int item = DtaGrid2.SelectedItems.Cast<DataRowView>().Select(x => Dt2.Rows.IndexOf(x.Row)).ToList().First();
                DataRow r = Dt2.Rows[item];
                if (item != null)
                {
                    RunIDS.Add(((int)r[0]));
                    Dt2.Rows.RemoveAt(item);
                }
                TrainingManager manager2 = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
                manager2.RemoveTrainings(CycleIDS, RunIDS);
            }
            catch
            {
                MessageBox.Show("Select Item");
            }

        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            ReportAll x = new ReportAll();
            x.Show();
            this.Close();
        }
    }
}
