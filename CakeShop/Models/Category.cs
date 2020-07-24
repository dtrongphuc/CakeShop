using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Category:INotifyPropertyChanged
    {
        private string _idCategory;
        public string IdCategory
        {
            get { return _idCategory; }
            set
            {
                _idCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdCategory"));
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CategoryName"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Category()
        {
            this.IdCategory = " ";
            this.CategoryName = " ";
        }
    }
}
