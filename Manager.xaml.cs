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
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        Context context = new Context();
        void refresh()
        {
            var query = from x in context.Tasks
                        select new Tasks { TaskID = x.TaskID, Title = x.Title, Description = x.Description, Status = x.Status, Name = x.Name };
            managerdata.ItemsSource = query.ToList();
        }
        public Manager()
        {
            InitializeComponent();
            refresh();
            var query = from x in context.Users
                        where x.Name != "admin_user"
                        select x.Name;
            nametextbox.ItemsSource = query.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // add
        {
            if (statuscombo.Text.IsNullOrEmpty() || titletextbox.Text.IsNullOrEmpty() || descriptiontextbox.Text.IsNullOrEmpty() || nametextbox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            string status = statuscombo.Text, title = titletextbox.Text, desc = descriptiontextbox.Text, name = nametextbox.Text;
            
            context.Tasks.Add(new Tasks
            {
                Title = title,
                Description = desc,
                Status = status,
                Name = name
            });
            context.SaveChanges();
            refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //edit
        {
            if (statuscombo.Text.IsNullOrEmpty() || titletextbox.Text.IsNullOrEmpty() || descriptiontextbox.Text.IsNullOrEmpty() || nametextbox.Text.IsNullOrEmpty() || taskidtextbox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            int id = int.Parse(taskidtextbox.Text);
            string status = statuscombo.Text, title = titletextbox.Text, desc = descriptiontextbox.Text, name = nametextbox.Text;
            var query = (from x in context.Tasks
                         where x.TaskID == id
                         select x).FirstOrDefault();
            if (query != null)
            {
                query.Title = title;
                query.Description = desc;
                query.Status = status;
                query.Name = name;
                context.SaveChanges();
                refresh();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // delete
        {
            if (taskidtextbox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please enter a Task ID.");
                return;
            }
            var query = (from x in context.Tasks
                         where x.TaskID.ToString() == taskidtextbox.Text
                         select x).FirstOrDefault();
            if (query != null)
            {
                context.Tasks.Remove(query);
                context.SaveChanges();
                refresh();
            }
            else
            {
                MessageBox.Show("invalid task");
                return;
            }
            
        }
    }
}
