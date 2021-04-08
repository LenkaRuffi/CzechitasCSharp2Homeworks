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
                double amount;
                bool isNumber = double.TryParse(AmountTextBox.Text, out amount);
                if(isNumber)
                {
                    
                    
                    accountingBook.AddItem(InvoiceNumberTextBox.Text, InvoiceDescriptionTextBox.Text, amount, ItemType.Výdaj);
                    Close();
                }
                else
                {
                    MessageBox.Show("Je chybně zadána částka dokladu.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


        }
    }
}
