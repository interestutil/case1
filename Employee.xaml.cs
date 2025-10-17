using case1.Data;
using Microsoft.IdentityModel.Tokens;
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
        void refresh()
        {
            var query = from x in context.Tasks
                         where x.Name == emp && x.Status != "Completed"
                         select new Tasks { TaskID = x.TaskID, Title = x.Title, Description = x.Description, Status = x.Status };
            var query2 = from x in context.Tasks
                         where x.Name == emp && x.Status == "Completed"
                         select new Tasks { TaskID = x.TaskID, Title = x.Title, Description = x.Description, Status = x.Status };
            pendingdata.ItemsSource = query.ToList();
            completeddata.ItemsSource = query2.ToList();
        }
        public Employee(string emp_name)
        {
            InitializeComponent();
            emp = emp_name;
            emp_name_label.Content = emp;
            refresh();
        }

        private void pendingdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pendingdata.SelectedItem is Tasks t)
            {
                int taskId = t.TaskID;
                tasklabel.Content = taskId.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = (from x in context.Tasks
                         where x.TaskID.ToString() == tasklabel.Content.ToString()
                         select x).FirstOrDefault();
            if (query != null)
            {
                if (statuscombobox.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("Please select a status.");
                }
                else
                {
                    query.Status = statuscombobox.Text;
                    context.SaveChanges();
                }
                refresh();
            }
        }
    }
}
