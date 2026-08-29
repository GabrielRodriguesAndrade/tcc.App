using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ingaDrive
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            txtSenha.Text = string.Empty;
            Navigation.PushAsync(new MainPage());
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();  
        }
    }
}
