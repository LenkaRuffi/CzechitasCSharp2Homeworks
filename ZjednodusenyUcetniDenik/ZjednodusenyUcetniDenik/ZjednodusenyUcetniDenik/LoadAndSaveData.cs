using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CsvHelper;

namespace ZjednodusenyUcetniDenik
{
    public class LoadAndSaveData
    {
        string pathToCommonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData); //C:\ProgramData
        string AppName = "ZjednodusenyUcetniDenik";
        string database = "databaze.csv";
        string pathToCsvDatabaseData;
        public AccountingBook workingAccountingBook = new AccountingBook();

        public LoadAndSaveData()
        {
            pathToCsvDatabaseData = System.IO.Path.Combine(pathToCommonAppData, AppName, database);
            //this.workingAccountingBook = workingAccountingBook; 
        }

        private void LoadData()
        {
            CsvHelper.Configuration.CsvConfiguration csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (StreamReader reader = new StreamReader(pathToCsvDatabaseData))
            using (CsvReader csv = new CsvReader(reader, csvConfiguration))
            {
                var records = csv.GetRecords<Item>();
                List<Item> list = records.ToList();

                foreach (Item item in list)
                {
                    workingAccountingBook.AccountingBookItems.Add(item);
                }
            }
        }

        public void CheckAndLoadDataIfDbDirectoryExistElseCreate()
        {
            if (File.Exists(pathToCsvDatabaseData))
            {
                LoadData();
            }
            else
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(pathToCsvDatabaseData));
            }
        }

        public void SaveItemsAsCSVHelper(AccountingBook accountingBook)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToCsvDatabaseData, false, Encoding.UTF8))
                using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(accountingBook.AccountingBookItems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

    }
}
