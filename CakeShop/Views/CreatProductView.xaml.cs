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
        public CreatProductView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentViewModel = Main.DataContext as CreatProductViewModel;
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

        List<SizeProduct> _listSizeProduct = new List<SizeProduct>();

        /// <summary>
        /// Thêm hình
        /// </summary>
        List<FileInfo> ImagesFileList = new List<FileInfo>(); // List lưu thông tin danh sách hình
        private int _ImagesAddCount { get; set; } = 0; // Đếm số hình được add
        private void AddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
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

            if (ImagesFileList.Count > 0)
            {
                // Liên lạc với viewmodel để thêm hình vào binding list
                CurrentViewModel.UpdateImages(ImagesFileList);
            }
        }

        private void Submit_click(object sender, RoutedEventArgs e)
        {
            string avartar = "";
            if (Name.Text.Trim() != string.Empty && price.Text.Trim() != string.Empty && description.Text.Trim() != string.Empty)
            {
                //thêm sản phẩm vào database
                var index = ComboboxCategory.SelectedIndex;
                 avartar = CurrentViewModel.AddProduct(Name.Text,index, price.Text, description.Text, ImagesFileList[0]);
            }
            if (ImagesFileList.Count > 0)
            {
                ///thêm ảnh vào database.
                CurrentViewModel.AddImageProduct(ImagesFileList, avartar);
            }
            if (_listSizeProduct.Count > 0)
            {
                ///thêm kích thước và số lượng vào database.
                CurrentViewModel.AddSizeProduct(_listSizeProduct);
            }
            MessageBox.Show("Thêm Bánh thành Công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

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
            }
            _listSizeProduct.Add(sizeproduct);
            MessageBox.Show("Thêm kích thước Bánh thành Công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
