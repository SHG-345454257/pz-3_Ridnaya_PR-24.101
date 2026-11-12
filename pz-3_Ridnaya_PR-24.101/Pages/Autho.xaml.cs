using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using pz_3_Ridnaya_PR_24._101.Services;

namespace pz_3_Ridnaya_PR_24._101.Pages
{
    public partial class Autho : Page
    {
        private int failedAttempts = 0;
        private string currentCaptcha = "";

        public Autho()
        {
            InitializeComponent();
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null, null));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtbLogin.Text.Trim();
            string password = pswbPassword.Password;


            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            if (failedAttempts > 0)
            {
                if (string.IsNullOrWhiteSpace(txtboxCaptcha.Text) || txtboxCaptcha.Text != currentCaptcha)
                {
                    MessageBox.Show("Неверно введена CAPTCHA.");
                    GenerateCaptcha();
                    return;
                }
            }


            try
            {
                using (var db = new furniture_centerEntities())
                {
                    string passwordHash = Hash.GetSha256Hash(password);

                    var user = db.Users
                        .Include("Role")
                        .FirstOrDefault(u => u.login == login && u.password_hash == passwordHash);


                    if (user == null)
                    {
                        failedAttempts++;

                        MessageBox.Show("Неверный логин или пароль.");

                        if (failedAttempts >= 1)
                        {
                            GenerateCaptcha();
                        }

                        return;
                    }


                    if (user.Role.role_name == "Клиент")
                    {
                        NavigationService.Navigate(new Client(user, user.Role.role_name));
                    }
                    else if (user.Role.role_name == "Сотрудник")
                    {
                        NavigationService.Navigate(new Employee(user, user.Role.role_name));
                    }
                    else
                    {
                        MessageBox.Show("Неизвестная роль пользователя.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при авторизации: " + ex.Message);
            }
        }

        private void GenerateCaptcha()
        {
            currentCaptcha = CaptchaGenerator.GenerateCaptchaText(7);

            txtBlockCaptcha.Text = currentCaptcha;
            txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;

            txtBlockCaptcha.Visibility = Visibility.Visible;
            txtboxCaptcha.Visibility = Visibility.Visible;
        }
    }
}

