/* CountBox.xaml.cs
 * Author: Sak Lee
 */

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

namespace TheFlyingSaucer.PointOfSale
{
    /// <summary>
    /// CountBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CountBox : UserControl
    {
        /// <summary>
        /// Constructor for count box GUI
        /// </summary>
        public CountBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Property for binding type conversion
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            nameof(Count),
            typeof(uint),
            typeof(CountBox),
            new FrameworkPropertyMetadata(0u, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Property for count
        /// </summary>
        public uint Count
        {
            get { return (uint)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        /// <summary>
        /// Handles Increment of the count
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void HandleIncrement(object sender, RoutedEventArgs e)
        {
            if (Count != uint.MaxValue) Count++;
        }

        /// <summary>
        /// Handles Decrement of the count
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void HandleDecrement(object sender, RoutedEventArgs e)
        {
            if (Count != 0) Count--;
        }
    }
}
