using System;
using System.Collections.ObjectModel;
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
using System.ComponentModel;

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Property for the data context
        /// </summary>
        public Order CurrentOrder { get; set; } = new Order();

        /// <summary>
        /// Constructor for the GUI's Main Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = CurrentOrder;
        }

        /// <summary>
        /// Click event for the button "Cancel Order"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            CurrentOrder.Clear();
            Brdr.Child = new MenuItemSelectionControl();
        }

        /// <summary>
        /// Click event for the button "Back to Menu"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            Brdr.Child = new MenuItemSelectionControl();
            BackToMenuBtn.IsEnabled = false;
        }

        /// <summary>
        /// Click event for the buttons on the listview
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void OSC_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button button)
            {
                e.Handled = true;
                BackToMenuBtn.IsEnabled = true;
                if (button.Name == "Edit")
                {
                    var item = button.DataContext as IMenuItem;
                    switch (item) 
                    {
                        case FlyingSaucer:
                            Brdr.Child = new FlyingSaucerControl() { DataContext = item };
                            break;
                        case CrashedSaucer:
                            Brdr.Child = new CrashedSaucerControl() { DataContext = item };
                            break;
                        case LivestockMutilation:
                            Brdr.Child = new LivestockMutilationControl() { DataContext = item };
                            break;
                        case OuterOmelette:
                            Brdr.Child = new OuterOmeletteControl() { DataContext = item };
                            break;
                        case CropCircle:
                            Brdr.Child = new CropCircleControl() { DataContext = item };
                            break;
                        case GlowingHaystack:
                            Brdr.Child = new GlowingHaystackControl() { DataContext = item };
                            break;
                        case TakenBacon:
                            Brdr.Child = new TakenBaconControl() { DataContext = item };
                            break;
                        case MissingLinks:
                            Brdr.Child = new MissingLinksControl() { DataContext = item };
                            break;
                        case EvisceratedEggs:
                            Brdr.Child = new EvisceratedEggsControl() { DataContext = item };
                            break;
                        case YouAreToast:
                            Brdr.Child = new YouAreToastControl() { DataContext = item };
                            break;
                        case LiquifiedVegetation:
                            Brdr.Child = new LiquifiedVegetationControl() { DataContext = item };
                            break;
                        case SaucerFuel:
                            Brdr.Child = new SaucerFuelControl() { DataContext = item };
                            break;
                        case InorganicSubstance:
                            Brdr.Child = new InorganicSubstanceControl() { DataContext = item };
                            break;
                    }
                }
                if (button.Name == "Remove")
                {
                    var item = button.DataContext as IMenuItem;
                    CurrentOrder.Remove(item);
                    Brdr.Child = new MenuItemSelectionControl();
                }
            }
        }

        /// <summary>
        /// Click event for the button "Complete Order"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CompleteOrder_Click(object sender, RoutedEventArgs e)
        {
            Brdr.Child = new PaymentOptionControl() { CurrentOrder = CurrentOrder };
        }


    }
}
