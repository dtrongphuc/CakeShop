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
        public UpdateProductViewModel CurrentViewModel { get; set; } = null;

        private int _currentElement { get; set; } = 0;
        private int _maximumImagesCount { get; set; } = 0;
        public UpdateProductView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as UpdateProductViewModel;
            GetCarouselCount();
        }

        private void GetCarouselCount()
        {
            _maximumImagesCount = CurrentViewModel.ImagesCarousel.Count;
            _currentElement = _maximumImagesCount >= 4 ? 4 : _maximumImagesCount;
        }

        private void AnimateCarousel()
        {
            var carousel = VisualTreeHelpers.FindChild<StackPanel>(ImagesCarousel, "Carousel");
            Storyboard storyboard = (this.Resources["CarouselStoryboard"] as Storyboard);
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            Storyboard.SetTarget(animation, carousel);
            animation.To = -(ImagesCarousel.ActualWidth / 4.0 + 2) * (_currentElement - 4);
            storyboard.Begin();
        }

        private void OnPrev_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentElement > 4)
            {
                _currentElement--;
                AnimateCarousel();
            }
        }

        private void OnNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentElement < _maximumImagesCount)
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

        List<FileInfo> ImagesFileList = new List<FileInfo>(); // List tạm lưu thông tin danh sách file hình mới

        /// <summary>
        /// Thêm hình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImagesFileList.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
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

            GetCarouselCount();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //string avartar = CurrentViewModel.UpdateProduct(ImagesFileList[0], NameProduct.Text, PriceProduct.Text, Description.Text);
            //CurrentViewModel.UpdateImageProduct(ImagesFileList, avartar);
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
    }
}
