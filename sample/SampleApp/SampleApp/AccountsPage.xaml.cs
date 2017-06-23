using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Salesforce.DesignSystem;

namespace SampleApp
{
    public sealed partial class AccountsPage : Page
    {
        private string AccountsIcon => IconConstants.IconStandard.StandardAccount;
        private string FilterIcon => IconConstants.IconUtility.UtilityFilterList;
        private string SortIcon => IconConstants.IconUtility.UtilitySort;
        private string NewIcon => IconConstants.IconUtility.UtilityAdd;

        public AccountsPage()
        {
            this.InitializeComponent();

            PopulateListView();

        }

        private void PopulateListView()
        {
            AccountsListView.ItemsSource = new List<object>()
            {
                new Account()
                {
                    Name = "Burlington Textiles Corp of America",
                    BillingState = "NC",
                    Phone = "(336) 222-7000",
                    Type = "Customer - Direct",
                    Owner = "Joe Green"
                },
                new Account()
                {
                    Name = "Dickenson Plc",
                    BillingState = "NC",
                    Phone = "(336) 222-7000",
                    Type = "Customer - Direct",
                    Owner = "Joe Green"
                },
                new Account()
                {
                    Name = "Burlington Textiles Corp of America",
                    BillingState = "KS",
                    Phone = "(785) 241-6200",
                    Type = "Customer - Channel",
                    Owner = "Joe Green"
                },
                new Account()
                {
                    Name = "Edge Communications",
                    BillingState = "TX",
                    Phone = "(512) 757-6000",
                    Type = "Customer - Direct",
                    Owner = "Joe Green"
                },
                new Account()
                {
                    Name = "Express Logistics and Transport",
                    BillingState = "OR",
                    Phone = "(503) 421-7800",
                    Type = "Customer - Direct",
                    Owner = "Joe Green"
                },
            };
        }
    }

    public class Account
    {
        public string Name { get; set; }
        public string BillingState { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
    }
}
