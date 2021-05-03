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
      
        public ObservableCollection<Item> AccountingBookItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AccountingBook()
        {
            AccountingBookItems = new ObservableCollection<Item>();
        }
               

        public double? SumIncome
        {
            get
            {
                return AccountingBookItems.Where(a => a.ItemType == ItemType.Příjem).Sum(a => a.Amount); 
            }

            set
            {

            }
        }

        public double? SumCost
        {
            get
            {
                return AccountingBookItems.Where(a => a.ItemType == ItemType.Výdaj).Sum(a => a.Amount); 
            }

            set
            {

            }
        }

        public void AddItem(string invoiceNumber, string invoiceDescription, string counterPartyName, Address counterPartyAddress, string counterpartyIdentificateNumber, string counterpartyTaxIdentityNumber, DateTime? invoiceDate, DateTime? dueDate, DateTime? paymentDate, string itemCategory, ItemType itemType, double? amount, int? year)
        {
            if (invoiceDescription.Length < 3)
            {
                throw new ArgumentException("Popis faktury je příliš krátký");
            }
          
            Item newItem = new Item(invoiceNumber, invoiceDescription, counterPartyName, counterPartyAddress, counterpartyIdentificateNumber, counterpartyTaxIdentityNumber, invoiceDate, dueDate, paymentDate, itemCategory, itemType, amount, year);
            AccountingBookItems.Add(newItem);         
           
        }

        public void RemoveItem(Item removedItem)
        {
            AccountingBookItems.Remove(removedItem);
        }
    }

   
}
