using case1.Data;
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
using System.Windows.Shapes;

namespace case1
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        string emp;
        Context context = new Context();
        public Employee(string emp_name)
        {
            InitializeComponent();
            emp = emp_name;
            emp_name_label.Content = emp;
            var query = (from x in context.Tasks
                         where x.Name == emp && x.Status != "Completed"
                         select x).Select(t => new { t.TaskID, t.Title, t.Description, t.Status });
            pendingdata.ItemsSource = query.ToList();
        }
    }
}
