using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZjednodusenyUcetniDenik
{
    public class AccountingBook : INotifyPropertyChanged
    {
       //public List<Item> AccountingBookItems1 = new List<Item>();
       public ObservableCollection<Item> AccountingBookItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AccountingBook()
        {
            AccountingBookItems = new ObservableCollection<Item>();

        }

        public void AddItem(string invoiceNumber, string invoiceDescription, double amount, ItemType itemType)
        {
            if (invoiceDescription.Length < 3)
            {
                throw new ArgumentException("Popis faktury je příliš krátký");
            }
           /* if (narozeniny == null)
            {
                throw new ArgumentException("Nebylo zadáno datum narození");
            }
            if (narozeniny.Value.Date > DateTime.Today)
            {
                throw new ArgumentException("Narozeniny nesmí být v budoucnosti");
            }*/

            Item newItem = new Income(invoiceNumber, invoiceDescription, amount, itemType);
            AccountingBookItems.Add(newItem);
           
        }

        public void RemoveItem(Item removedItem)
        {
            AccountingBookItems.Remove(removedItem);
        }
    }

   
}
