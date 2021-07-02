using App;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTable dt = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            Program.FormHotel();
            //Program.ExcelWriter();
            //SqlExecuter.Clear();
            //Program.Main();

            //for (int i = 0; i < 10; i++)
            //    grid.ColumnDefinitions.Add(new ColumnDefinition { });
            //grid.RowDefinitions.Add(new RowDefinition { Name = "blya" });
            //for (int i = 0; i < 10; i++)
            //    grid.RowDefinitions.Add(new RowDefinition { });
            //var c = new ColumnDefinition();
            //grid.RowDefinitions[1] = new ColumnDefinition();

            //var column = new DataColumn();
            //column.DataType = typeof(string);
            //column.ColumnName = "Номера";
            //dt.Columns.Add(column);

            //dataGrid.ItemsSource = SqlExecuter.Select("Hotel").DefaultView;
        }

        private void Reload()
        {

            foreach (DataRow row in dt.Rows)
            {
                var room = Hotel.Rooms
                    .Where(x => (x.Number + " " + x.GetType().Name) == (string)row["Номера"])
                    .ToArray()[0];
                
            }
            dataGrid.ItemsSource = dt.DefaultView;
        }
        ~MainWindow()
        {
            SqlExecuter.Clear();
        }
    }
}
