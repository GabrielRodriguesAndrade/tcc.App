using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ingaDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ingaDrive
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoAtivo : TabbedPage
    {
        
        public EventoAtivo()
        {
            InitializeComponent();
            List<vagas> vaguinas = new List<vagas>
            {
                new vagas
                {
                    vaga = "A34",
                    carro = "kwid"
                },
                new vagas
                {
                    vaga = "A11",
                    carro = "Fiat500"
                }
            };
            clvGaragem.ItemsSource = vaguinas;
    

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (sender is Frame frame && frame.BindingContext is vagas item)
            {
                // Agora você tem acesso ao item clicado
                string vagaSelecionada = item.vaga;
                string carroSelecionado = item.carro;

                // Exemplo: navegar para outra página passando dados
                Navigation.PushAsync(new NavigationPage(new CarroObervado(item)));
            }
        }
    }
}