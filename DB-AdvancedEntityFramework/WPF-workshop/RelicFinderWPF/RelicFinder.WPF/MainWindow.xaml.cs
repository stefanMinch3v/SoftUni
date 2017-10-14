using RelicFinder.Data.Stores;
using RelicFinder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RelicFinder.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RelicStore store = new RelicStore();
        ObservableCollection<Relic> relics = new ObservableCollection<Relic>();// not with list collection , in order to refresh the UI itself everytime without implementing additional events!

        public MainWindow()
        {
            InitializeComponent();

            //store.Initialize(); init db

            LoadRelics();
        }

        private void LoadRelics()
        {
            this.DataContext = new ObservableCollection<Relic>(store.GetAllRelics());
        }

        private void SaveChangesClick_Click(object sender, RoutedEventArgs e)
        {
            this.store.SaveChanges();
            MessageBox.Show("Successfuly saved!");
        }

        private void AddNewRelic_Click(object sender, RoutedEventArgs e)
        {
            ((ObservableCollection<Relic>)DataContext).Add(this.store.AddNewRelic());
        }
    }
}
