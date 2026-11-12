
using System.Windows.Controls;

namespace pz_3_Ridnaya_PR_24._101.Pages
{
    public partial class Employee : Page
    {
        private User currentUser;
        private string currentRole;

        public Employee(User user, string role)
        {
            InitializeComponent();

            currentUser = user;
            currentRole = role;

            if (currentUser != null)
            {
                txtWelcome.Text = "Личный кабинет сотрудника";
                txtUserInfo.Text = "Вы вошли как: " + currentUser.login;
            }
        }
    }
}
