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

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// MenuItemSelectionControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Constructor for menu item selection control
        /// </summary>
        public MenuItemSelectionControl()
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
        /// Click event for the button "Flying Saucer"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void FlyingSaucer_Click(object sender, RoutedEventArgs e)
        {
            FlyingSaucer fs = new();
            
            if (DataContext is Order order)
            {
                order.Add(fs);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new FlyingSaucerControl() { DataContext = fs };
        }

        /// <summary>
        /// Click event for the button "Crashed Saucer"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void CrashedSaucer_Click(object sender, RoutedEventArgs e)
        {
            CrashedSaucer cs = new();

            if (DataContext is Order order)
            {
                order.Add(cs);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new CrashedSaucerControl() { DataContext = cs };
        }

        /// <summary>
        /// Click event for the button "Livestock Mutilation"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void LivestockMutilation_Click(object sender, RoutedEventArgs e)
        {
            LivestockMutilation lm = new();

            if (DataContext is Order order)
            {
                order.Add(lm);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new LivestockMutilationControl() { DataContext = lm };
        }

        /// <summary>
        /// Click event for the button "Outer Omelette"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void OuterOmelette_Click(object sender, RoutedEventArgs e)
        {
            OuterOmelette oo = new();

            if (DataContext is Order order)
            {
                order.Add(oo);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new OuterOmeletteControl() { DataContext = oo };
        }

        /// <summary>
        /// Click event for the button "Crop Circle"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void CropCircle_Click(object sender, RoutedEventArgs e)
        {
            CropCircle cc = new();

            if (DataContext is Order order)
            {
                order.Add(cc);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new CropCircleControl() { DataContext = cc };
        }

        /// <summary>
        /// Click event for the button "Glowing Haystack"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void GlowingHaystack_Click(object sender, RoutedEventArgs e)
        {
            GlowingHaystack gh = new();

            if (DataContext is Order order)
            {
                order.Add(gh);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new GlowingHaystackControl() { DataContext = gh };
        }

        /// <summary>
        /// Click event for the button "Taken Bacon"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void TakenBacon_Click(object sender, RoutedEventArgs e)
        {
            TakenBacon tb = new();

            if (DataContext is Order order)
            {
                order.Add(tb);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new TakenBaconControl() { DataContext = tb };
        }

        /// <summary>
        /// Click event for the button "Missing Links"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void MissingLinks_Click(object sender, RoutedEventArgs e)
        {
            MissingLinks ml = new();

            if (DataContext is Order order)
            {
                order.Add(ml);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new MissingLinksControl() { DataContext = ml };
        }

        /// <summary>
        /// Click event for the button "Eviscerated Eggs"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void EvisceratedEggs_Click(object sender, RoutedEventArgs e)
        {
            EvisceratedEggs ee = new();

            if (DataContext is Order order)
            {
                order.Add(ee);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new EvisceratedEggsControl() { DataContext = ee };
        }

        /// <summary>
        /// Click event for the button "You're Toast"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void YouAreToast_Click(object sender, RoutedEventArgs e)
        {
            YouAreToast yat = new();

            if (DataContext is Order order)
            {
                order.Add(yat);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new YouAreToastControl() { DataContext = yat };
        }

        /// <summary>
        /// Click event for the button "Liquified Vegetation"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void LiquifiedVegetation_Click(object sender, RoutedEventArgs e)
        {
            LiquifiedVegetation lv = new();

            if (DataContext is Order order)
            {
                order.Add(lv);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new LiquifiedVegetationControl() { DataContext = lv };
        }

        /// <summary>
        /// Click event for the button "Saucer Fuel"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void SaucerFuel_Click(object sender, RoutedEventArgs e)
        {
            SaucerFuel sf = new();

            if (DataContext is Order order)
            {
                order.Add(sf);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new SaucerFuelControl() { DataContext = sf };
        }

        /// <summary>
        /// Click event for the button "Inorganic Substance"
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void InorganicSubstance_Click(object sender, RoutedEventArgs e)
        {
            InorganicSubstance ios = new();

            if (DataContext is Order order)
            {
                order.Add(ios);
            }
            MW.BackToMenuBtn.IsEnabled = true;
            MW.Brdr.Child = new InorganicSubstanceControl() { DataContext = ios };
        }
    }
}
