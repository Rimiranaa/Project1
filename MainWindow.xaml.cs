using System;
using System.Collections.Generic;
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
using ChemistryInfo.DB;

namespace ChemistryInfo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ChemistryInfoEntities chemistryinfoEntities = new ChemistryInfoEntities();


        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
            Close();
        }

        internal static void GoBack()
        {
            throw new NotImplementedException();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ChemistryInfoEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p=>p.Reload());
                Table.ItemsSource = ChemistryInfoEntities.GetContext().Themes.ToList();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Show();
            Close();
        }
    }
}
