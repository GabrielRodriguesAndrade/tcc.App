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
    public partial class Cadastrar : ContentPage
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            txtSenha.Text = string.Empty;
            Navigation.PushAsync(new Login());
        }

        private void btnVOLTAR_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();  
        }
    }
}
