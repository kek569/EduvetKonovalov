using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace EduvetKonovalov.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool ret = MBClass.QestionMB("Вы действительно желаете выйти?");
            if (ret == true)
            {
                this.Close();
            }
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
                return;
            }
            else if (CheckTb.Text == "" || CheckTb == null)
            {
                MBClass.ErrorMB("Пройдите капчу");
                CheckTb.Focus();
                return;
            }
            else if (CheckCapcha == true || CheckTb.Text == text)
            {
                LoginSave = LoginTB.Text;
                PasswordSave = PasswordPB.Password;
                if (SaveMeCb.IsChecked == true)
                {
                    SaveMe = true;
                    Login();
                }
                else
                {
                    SaveMe = false;
                    Login();
                }
                CheckCapcha = false;
                return;
            }
            else
            {
                MBClass.ErrorMB("Капча не пройдено");
                CapchaPb.Image = CreateCapcha(CapchaPb.Width, CapchaPb.Height);
                CheckTb.Text = "";
                CheckTb.Focus();
                Fail = Fail + 1;
                if (Fail >= 3 && ActiveTime == false)
                {
                    ActiveTime = true;
                    CopyTime = Time;
                    LogInBtn.IsEnabled = false;
                    Disable = 1;
                    var timer = new DispatcherTimer
                    { Interval = TimeSpan.FromSeconds(Time) };
                    timer.Start();
                    TextTime();
                    timer.Tick += (senders, args) =>
                    {
                        timer.Stop();
                        LogInBtn.Content = "Войти";
                        LogInBtn.IsEnabled = true;
                        Time = Time * 1.5;
                        Fail = 2;
                        Disable = 0;
                        ActiveTime = false;
                    };

                }
                return;
            }
        }

        private string text = String.Empty;
        private int Fail = 0;
        private int Disable = 0;
        private double Time = 10;
        private double CopyTime = 10;
        private bool CheckCapcha = false;
        private bool ActiveTime = false;
        private bool SaveFileNull = true;
        private bool SaveMe = false;
        private string LoginSave;
        private string PasswordSave;


        private Bitmap CreateCapcha(int Width, int Height)
        {
            Random rnd = new Random();
            Bitmap result = new Bitmap(Width, Height);

            int Xpos = rnd.Next(0, Width - 75);
            int Ypos = rnd.Next(15, Height - 25);

            System.Drawing.Brush colors = System.Drawing.Brushes.Black;

            Graphics graphics = Graphics.FromImage((System.Drawing.Image)result);

            graphics.Clear(System.Drawing.Color.Gray);

            this.text = string.Empty;

            string ALF = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";

            for (int i = 0; i < 5; i++)
            {
                this.text += ALF[rnd.Next(ALF.Length)];
            }

            graphics.DrawString(this.text, new Font("Arial", 15),
                colors, new PointF(Xpos, Ypos));

            graphics.DrawLine(Pens.Black,
                new System.Drawing.Point(0, 0),
                new System.Drawing.Point(Width - 1, Height - 1));

            graphics.DrawLine(Pens.Black,
                new System.Drawing.Point(0, Height - 1),
                new System.Drawing.Point(Width - 1, 0));

            for (int y = 0; y < 4; y++)
            {
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        if (rnd.Next() % 20 == 0)
                        {
                            int a = rnd.Next(0, 6);
                            if (a == 0)
                            {
                                result.SetPixel(i, j, System.Drawing.Color.Black);
                            }
                            else if (a == 1)
                            {
                                result.SetPixel(i, j, System.Drawing.Color.Cyan);
                            }
                            else if (a == 2)
                            {
                                result.SetPixel(i, j, System.Drawing.Color.Yellow);
                            }
                            else if (a == 3)
                            {
                                result.SetPixel(i, j, System.Drawing.Color.Green);
                            }
                            else if (a == 4)
                            {
                                result.SetPixel(i, j, System.Drawing.Color.Red);
                            }
                            else if (a == 5)
                            {
                                result.SetPixel(i, j, System.Drawing.Color.Blue);
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void TextTime()
        {
            if (CopyTime > 0.5)
            {
                int a = (int)CopyTime;
                var timer = new DispatcherTimer
                { Interval = TimeSpan.FromSeconds(1) };
                timer.Start();
                LogInBtn.Content = a;
                timer.Tick += (senders, args) =>
                {
                    timer.Stop();
                    CopyTime = CopyTime - 1;
                    TextTime();
                };
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            CapchaPb.Image = CreateCapcha(CapchaPb.Width, CapchaPb.Height);
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(LoginSave))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordSave))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
                return;
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.Login.LoginUser == LoginSave);

                    if (user == null)
                    {
                        MBClass.ErrorMB("Введен не правильный логин");
                        LoginTB.Focus();
                        return;
                    }
                    if (user.Password.PasswordUser != PasswordSave)
                    {
                        MBClass.ErrorMB("Введен не правильный пароль");
                        PasswordPB.Focus();
                        return;
                    }
                    else
                    {
                        if (SaveMe == true)
                        {
                            using (StreamWriter newTask = new StreamWriter("Save.txt", false))
                            {
                                newTask.WriteLine(LoginSave + "\n" + PasswordSave);
                            }
                        }

                        switch (user.IdRole)
                        {
                            case 1:
                                new AdminWindowFolder.AdminWindow().Show();
                                this.Close();
                                break;
                            case 2:
                                (App.Current as App).DeptName = LoginSave;
                                new StaffWindowFolder.StaffWindow().Show();
                                this.Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CapchaPb.Image = CreateCapcha(CapchaPb.Width, CapchaPb.Height);
            bool selected_CheckLogin = (App.Current as App).CheckLogin;
            if (selected_CheckLogin != true) 
            { 
                using (StreamReader newTask = new StreamReader("Save.txt", true))
                {
                    if (newTask == null || newTask.ReadToEnd() == "")
                    {
                        SaveFileNull = true;
                    }
                    else
                    {
                        SaveFileNull = false;
                    }
                }
                if (SaveFileNull == false)
                {
                    using (StreamReader newTask = new StreamReader("Save.txt", false))
                    {
                        LoginSave = newTask.ReadLine();
                        PasswordSave = File.ReadLines("Save.txt").Skip(1).First();
                        Login();
                    }
                }
            }
        }
    }
}
