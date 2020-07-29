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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CakeShop.Views
{
    /// <summary>
    /// Interaction logic for DetailProductView.xaml
    /// </summary>
    public partial class DetailProductView : UserControl
    {
        public DetailProductView()
        {
            InitializeComponent();
        }

        private int _currentElement = 0;
        private void AnimateCarousel()
        {
            var carousel = VisualTreeHelpers.FindChild<StackPanel>(ImagesCarousel, "Carousel");
            Storyboard storyboard = (this.Resources["CarouselStoryboard"] as Storyboard);
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            Storyboard.SetTarget(animation, carousel);
            animation.To = -(ImagesCarousel.ActualWidth + 10) * _currentElement;
            storyboard.Begin();
        }

        private void OnPrev_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentElement > 0)
            {
                _currentElement--;
                AnimateCarousel();
            }
        }

        private void OnNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentElement < 10)
            {
                _currentElement++;
                AnimateCarousel();
            }
        }

        /// <summary>
        /// Khi chọn ảnh ở carousel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectedImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border selected = sender as Border;
            ImageSelected.Background = selected.Background as ImageBrush;
        }

        private void Datagrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is DataGrid && !e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is ListView && !e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }
    }
}
