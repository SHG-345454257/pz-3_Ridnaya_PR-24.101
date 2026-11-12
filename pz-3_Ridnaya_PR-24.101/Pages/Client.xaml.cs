
using System.Windows.Controls;

namespace pz_3_Ridnaya_PR_24._101.Pages
{
    public partial class Client : Page
    {
        private User currentUser;
        private string currentRole;

        public Client(User user, string role)
        {
            InitializeComponent();

            currentUser = user;
            currentRole = role;

            if (currentUser != null)
            {
                txtWelcome.Text = "Личный кабинет клиента";
                txtUserInfo.Text = "Вы вошли как: " + currentUser.login;
            }
            else
            {
                txtWelcome.Text = "Просмотр в гостевом режиме";
                txtUserInfo.Text = "Вы вошли без авторизации";
            }
        }
    }
}
