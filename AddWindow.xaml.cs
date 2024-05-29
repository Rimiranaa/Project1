using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using ChemistryInfo.DB;


namespace ChemistryInfo
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        public AddWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Themes themes = new Themes();
            
            themes.id = idBox.TabIndex;
            themes.Name = nameBox.Text;
            themes.Description = desBox.Text;

            ChemistryInfoEntities.GetContext().Themes.Add(themes);
            ChemistryInfoEntities.GetContext().SaveChanges();
            MessageBox.Show("Тема успешно добавлена");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
