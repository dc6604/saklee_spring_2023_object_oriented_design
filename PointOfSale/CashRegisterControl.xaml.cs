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
    /// CashRegisterControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CashRegisterControl : UserControl
    {
        /// <summary>
        /// Constructor for the CashRegisterControl
        /// </summary>
        public CashRegisterControl()
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
        /// Click event for return to order button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void Return_Click(object sender, RoutedEventArgs e)
        {
            MW.Brdr.Child = new MenuItemSelectionControl();
        }

        /// <summary>
        /// Click event for finalize sale button
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void Finalize_Click(object sender, RoutedEventArgs e)
        {
            if (((CashRegister)DataContext).AmountDue <= 0 )
            {
                RoundRegister.CashDrawer.Open();
                ((CashRegister)DataContext).FinalizeChange();

                string temp = ("Order #" + MW.CurrentOrder.Number.ToString());
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                temp = MW.CurrentOrder.PlacedAt.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                foreach (IMenuItem item in MW.CurrentOrder)
                {
                    temp = item.Name + ": $" + item.Price;
                    RoundRegister.ReceiptPrinter.PrintLine(temp);
                }
                temp = "Subtotal: $" + MW.CurrentOrder.Subtotal.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                temp = "Tax: $" + MW.CurrentOrder.Tax.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                temp = "Total: $" + MW.CurrentOrder.Total.ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                RoundRegister.ReceiptPrinter.PrintLine("Payment Method: Cash");
                temp = "Change: $" + (((CashRegister)DataContext).Change).ToString();
                RoundRegister.ReceiptPrinter.PrintLine(temp);
                RoundRegister.ReceiptPrinter.CutTape();

                MW.CurrentOrder.Clear();

                MW.Brdr.Child = new MenuItemSelectionControl();

            }
        }
    }
}
