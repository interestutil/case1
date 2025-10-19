using case1.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace case1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (usertext.Text.IsNullOrEmpty() || passtext.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Enter both the name and password.");
                return;
            }
            string user = usertext.Text, pass = passtext.Password;
            var query = (from x in context.Users
                        where x.Name == user && x.Password == pass
                        select x).FirstOrDefault();

            if (query != null)
            {
                MessageBox.Show("Login successful!");
                if (query.role == true)
                {
                    // add manager window
                    Manager manager = new Manager();
                    manager.Show();
                    this.Close();
                }
                else
                {
                    // add employee window
                    Employee employee = new Employee(query.Name);
                    employee.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
        }
    }
}