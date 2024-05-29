using ChemistryInfo.DB;
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
using System.Windows.Shapes;

namespace ChemistryInfo
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            ChemistryInfoEntities chemistryinfoEntities = new ChemistryInfoEntities();
            Element.ItemsSource = chemistryinfoEntities.Elements.ToList();
        }



        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ChemistryInfoEntities chemistryinfoEntities = new ChemistryInfoEntities();
                Element.ItemsSource = chemistryinfoEntities.Elements.Where(p => p.Name == TBoxSearch.Text|| p.Name.Contains(TBoxSearch.Text)).ToList();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
