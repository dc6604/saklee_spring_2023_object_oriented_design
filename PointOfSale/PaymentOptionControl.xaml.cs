using RoundRegister;
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
using TheFlyingSaucer.Data;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// PaymentOptionControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PaymentOptionControl : UserControl
    {
        /// <summary>
        /// Constructor for PaymentOptionControl
        /// </summary>
        public PaymentOptionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Property for the main window
        /// </summary>
        public MainWindow MW
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                }
                while (!(parent is null || parent is MainWindow));
                return (MainWindow)parent;
            }
        }

        /// <summary>
        /// Property for the current order
        /// </summary>
        public Order CurrentOrder { get; init; }

        /// <summary>
        /// Click event for Cash button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CashBtn_Click(object sender, RoutedEventArgs e)
        {
            MW.Brdr.Child = new CashRegisterControl()
            {
                DataContext = new CashRegister(CurrentOrder)
            };
        }

        /// <summary>
        /// Click event for Card button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CardBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = RoundRegister.CardReader.RunCard((double)CurrentOrder.Total);
            if (result == CardTransactionResult.Approved)
            {
                string temp = ("Order #" + CurrentOrder.Number.ToString());
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                temp = CurrentOrder.PlacedAt.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                foreach (IMenuItem item in CurrentOrder)
                {
                    temp = item.Name + ": $" + item.Price;
                    RoundRegister.ReceiptPrinter.PrintLine(temp);
                }
                temp = "Subtotal: $" + CurrentOrder.Subtotal.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                temp = "Tax: $" + CurrentOrder.Tax.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                temp = "Total: $" + CurrentOrder.Total.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                RoundRegister.ReceiptPrinter.PrintLine("Payment Method: Card");
                RoundRegister.ReceiptPrinter.PrintLine("Change: $0.00");
                ReceiptPrinter.CutTape();

                MW.CurrentOrder.Clear();
                MW.Brdr.Child = new MenuItemSelectionControl();
            }
            
        }

    }
}
