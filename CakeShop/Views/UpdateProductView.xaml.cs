using CakeShop.ViewModels;
using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UpdateProductView.xaml
    /// </summary>
    public partial class UpdateProductView : UserControl
    {
        UpdateProductViewModel CurrentViewModel = null;

        public UpdateProductView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as UpdateProductViewModel;
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
        
        /// <summary>
        /// Thêm hình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<FileInfo> ImagesFileList = new List<FileInfo>(); // List tạm lưu thông tin danh sách file hình mới
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    var info = new FileInfo(filename);
                    ImagesFileList.Add(info);
                }
            }

            if(ImagesFileList.Count > 0)
            {
                // Liên lạc với viewmodel để thêm hình vào binding list
                CurrentViewModel.UpdateImages(ImagesFileList);
            }
        }

        private void OnSelectedImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
