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

namespace CompanyProjects
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        bool txtNickNameCleared;
        bool txtPasswordACleared;
        bool txtPasswordBCleared;


        public SignUpWindow()
        {
            InitializeComponent();
            txtNickNameCleared = false;
            txtPasswordACleared = false;
            txtPasswordBCleared = false;
        }

        private void txtNickName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtNickNameCleared)
            {
                txtNickName.Text = "";
                txtNickNameCleared = true;
            }
        }

        private void txtPasswordA_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtPasswordACleared)
            {
                txtPasswordA.Text = "";
                txtPasswordACleared = true;
            }
        }

        private void txtPasswordB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!txtPasswordBCleared)
            {
                txtPasswordB.Text = "";
                txtPasswordBCleared = true;
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            //Skontrolovat ci ma meno aspon 3 znaky
            //Skontrolovat ci ma heslo aspon 6 znakov
            //Skontrolovat ci je druhe heslo rovnake ako prve

            //Ulozit noveho uzivatela do suboru loginusersdata.xml
            //Zavriet okno registracie a otvorit okno pre login

        }
    }
}
