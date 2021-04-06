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

namespace ZjednodusenyUcetniDenik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonFiltering_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow();
            addItemWindow.ShowDialog();
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            EditItemWindow editItemWindow = new EditItemWindow();
            editItemWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu si přejete ukončit aplikaci?", "Ukončení aplikace", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.MainWindow.Close();
            }

        }

        private void MainWindowAccountingBook_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Opravdu si přejete ukončit aplikaci?", "Ukončení aplikace", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

        }

        private void ExportItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opravdu si přejete exportovat položky do csv?", "Export do csv", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Opravdu si přejete smazat vybranou položku? Smazání položky je nevratné.", "Upozornění", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
        }
    }
}
