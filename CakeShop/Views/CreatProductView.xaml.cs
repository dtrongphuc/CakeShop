using CakeShop.Models;
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
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CakeShop.Views
{
    /// <summary>
    /// Interaction logic for CreatProductView.xaml
    /// </summary>
    public partial class CreatProductView : UserControl
    {
        CreatProductViewModel CurrentViewModel = null;
        private int _currentElement { get; set; } = 0;
        private int _maximumImagesCount { get; set; } = 0;

        public CreatProductView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as CreatProductViewModel;
            _maximumImagesCount = CurrentViewModel.ImagesCarousel.Count;
            _currentElement = _maximumImagesCount >= 4 ? 4 : _maximumImagesCount;
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

        private void AnimateCarousel()
        {
            var carousel = VisualTreeHelpers.FindChild<StackPanel>(ImagesCarousel, "Carousel");
            Storyboard storyboard = (this.Resources["CarouselStoryboard"] as Storyboard);
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            Storyboard.SetTarget(animation, carousel);
            animation.To = -(ImagesCarousel.ActualWidth / 4.0 + 1) * (_currentElement - 4);
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

        List<SizeProduct> _listSizeProduct = new List<SizeProduct>();

        /// <summary>
        /// Thêm hình
        /// </summary>
        List<FileInfo> ImagesFileList = new List<FileInfo>(); // List lưu thông tin danh sách hình
        private void AddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<FileInfo> ImagesFile = new List<FileInfo>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    var info = new FileInfo(filename);
                    ImagesFile.Add(info);
                }
            }

            if (ImagesFile.Count > 0)
            {
                // Liên lạc với viewmodel để thêm hình vào binding list
                CurrentViewModel.UpdateImages(ImagesFile);
                foreach(var image in ImagesFile)
                {
                    ImagesFileList.Add(image);
                }
                _maximumImagesCount = CurrentViewModel.ImagesCarousel.Count;
                _currentElement = _maximumImagesCount >= 4 ? 4 : _maximumImagesCount;
            }
        }

        private void Submit_click(object sender, RoutedEventArgs e)
        {
            string avartar = "";
            var index = ComboboxCategory.SelectedIndex;
            if (ProductName.Text.Trim() != string.Empty && price.Text.Trim() != string.Empty &&
                description.Text.Trim() != string.Empty && ImagesFileList.Count > 0 &&
                _listSizeProduct.Count > 0 && index != -1)
            {
                //thêm sản phẩm vào database
                 avartar = CurrentViewModel.AddProduct(ProductName.Text,index, price.Text, description.Text, ImagesFileList[0]);
                ///thêm ảnh vào database.
                CurrentViewModel.AddImageProduct(ImagesFileList, avartar);
                ///thêm kích thước và số lượng vào database.
                CurrentViewModel.AddSizeProduct(_listSizeProduct);
                MessageBox.Show("Thêm bánh thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                CurrentViewModel.ShowHome();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddSize_Click(object sender, RoutedEventArgs e)
        {
            SizeProduct sizeproduct = new SizeProduct();
            ComboBoxItem selected = ComboboxSize.SelectedValue as ComboBoxItem;
            TextBlock selectedTextBlock = selected.Content as TextBlock;
            sizeproduct.Size = selectedTextBlock.Text;
            if(quantity.Text.Trim() != string.Empty)
            {
                sizeproduct.Quantity = quantity.Text.Trim();
                _listSizeProduct.Add(sizeproduct);
                MessageBox.Show("Thêm kích thước bánh thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ kích thước bánh", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
