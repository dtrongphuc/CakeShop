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

namespace CakeShop.Views
{
    /// <summary>
    /// Interaction logic for CreatProductView.xaml
    /// </summary>
    public partial class CreatProductView : UserControl
    {
        public CreatProductView()
        {
            InitializeComponent();

            List<User> users = new List<User>();
            users.Add(new User() { Num = 1, Name = "Nguyen", Local = "nguyen van cu ", Email = "nghiadx@100", Date = new DateTime(2020, 08, 12), Note = "no note", TotalMoney = 2522, TT = "khong có", Id = 1, Name1 = "John Doe", Birthday = new DateTime(1971, 7, 23), ImageUrl = "http://www.wpf-tutorial.com/images/misc/john_doe.jpg" });
            users.Add(new User() { Num = 2, Name = "Nguyen", Local = "nguyen van cu ", Email = "nghiadx@100", Date = new DateTime(2020, 08, 12), Note = "no note", TotalMoney = 2522, TT = "khong có", Id = 1, Name1 = "John Doe", Birthday = new DateTime(1971, 7, 23), ImageUrl = "http://www.wpf-tutorial.com/images/misc/john_doe.jpg" });
            users.Add(new User() { Num = 3, Name = "Nguyen", Local = "nguyen van cu ", Email = "nghiadx@100", Date = new DateTime(2020, 08, 12), Note = "no note", TotalMoney = 2522, TT = "khong có", Id = 1, Name1 = "John Doe", Birthday = new DateTime(1971, 7, 23), ImageUrl = "http://www.wpf-tutorial.com/images/misc/john_doe.jpg" });
            

            //List<test> tests = new List<test>();
            //tests.Add(new test() { Num = 1, Name = "Nguyen", Local = "nguyen van cu ", Email = "nghiadx@100", Date = new DateTime(2020, 08, 12), Note = "no note", TotalMoney = 2522, TT = "khong có"});
            //tests.Add(new test() { Num = 2, Name = "Nguyen", Local = "nguyen van cu ", Email = "nghiadx@100", Date = new DateTime(2020, 08, 12), Note = "no note", TotalMoney = 2522, TT = "khong có"});
            //tests.Add(new test() { Num = 3, Name = "Nguyen", Local = "nguyen van cu ", Email = "nghiadx@100", Date = new DateTime(2020, 08, 12), Note = "no note", TotalMoney = 2522, TT = "khong có"});

            dgUsers.ItemsSource = users;
           
        }
    }
    public class User
    {
        public int Num { get; set; }
        public string Name { get; set; }
        public string Local { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public int TotalMoney { get; set; }
        public string TT { get; set; }
        public int Id { get; set; }

        public string Name1 { get; set; }

        public DateTime Birthday { get; set; }

        public string ImageUrl { get; set; }
    }

    //public class test
    //{
    //    public int Num { get; set; }
    //    public string Name { get; set; }
    //    public string Local { get; set; }
    //    public string Email { get; set; }
    //    public DateTime Date { get; set; }
    //    public string Note { get; set; }
    //    public int TotalMoney { get; set; }
    //    public string TT { get; set; }
    //}
}
