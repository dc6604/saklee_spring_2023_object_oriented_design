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
    /// ServingSizeBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ServingSizeBox : UserControl
    {
        public ServingSizeBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Property for setting dependency property
        /// </summary>
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(
            nameof(Size),
            typeof(ServingSize),
            typeof(ServingSizeBox),
            new FrameworkPropertyMetadata(ServingSize.Small, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Property for the serving size
        /// </summary>
        public ServingSize Size
        {
            get { return (ServingSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
    }
}
