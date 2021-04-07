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

namespace ZjednodusenyUcetniDenik
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        private AccountingBook accountingBook;
        
        public AddItemWindow(AccountingBook accountingBook)
        {
            InitializeComponent();
            this.accountingBook = accountingBook;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                accountingBook.AddItem(InvoiceNumberTextBox.Text, InvoiceDescriptionTextBox.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


        }
    }
}
