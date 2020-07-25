using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Order : INotifyPropertyChanged
    {
        private string _idOrder;
        public string IdOrder
        {
            get { return _idOrder; }
            set
            {
                _idOrder = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IdOrder"));
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustomerName"));
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Address"));
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Note"));
            }
        }

        private string _total;
        public string Total
        {
            get { return _total; }
            set
            {
                _total = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Order()
        {
            this.IdOrder = " ";
            this.Email = " ";
            this.Address = " ";
            this.CustomerName = " ";
            this.Date = " ";
            this.Note = " ";
            this.Status = " ";
            this.Total = " ";
        }

    }
}
