using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    class PaginationProduct : INotifyPropertyChanged
    {

        public static int Sum_record { get; set; }
        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        private int _record1page = 8;
        public int record1page
        {
            get { return _record1page; }
            set
            {
                _record1page = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("recod1page"));
            }
        }

        private int _totalpage = 0;
        public int ToltalPage
        {
            get { return _totalpage; }
            set
            {
                _totalpage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TotalPage"));
            }
        }

        private BindableCollection<Product> _listProduct;

        public BindableCollection<Product> ListProduct
        {
            get { return _listProduct; }
            set
            {
                _listProduct = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListProduct"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PaginationProduct()
        {
            Sum_record = 0;
            CurrentPage = 1;
            ListProduct = new BindableCollection<Product>();
        }

        GetListObject GetCtrl = new GetListObject();
        public BindableCollection<Product> GetProductPagination(int _curr)
        {
            CurrentPage = _curr;
            Sum_record = GetListObject.Get_CountALLProduct();
            //CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * record1page;
            ListProduct = GetCtrl.Get_AllProduct(sotranghienhanh, record1page);
            return ListProduct;
        }
    }
}
