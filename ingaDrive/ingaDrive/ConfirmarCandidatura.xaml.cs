using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ingaDrive
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmarCandidatura : TabbedPage
    {
        public class vagas
        {
            public string empresa { get; set; }
            public string local { get; set; }
            public string valor { get; set; }
            public DateTime data { get; set; }
            public TimeSpan inicio { get; set; }
            public TimeSpan fim { get; set; }
            public string dataFinal => $"{data.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("pt-BR"))} {inicio:hh\\:mm} - {fim:hh\\:mm}";
            public int vagasRestantes { get; set; }
        }
        public ConfirmarCandidatura()
        {
            InitializeComponent();
            List<vagas> vaga = new List<vagas>
            {
                new vagas
                {
                    empresa = "Tech Solutions",
                    local = "São Paulo - SP",
                    valor = "R$ 135,00",
                    data = new DateTime(2025, 5, 12),
                    inicio = new TimeSpan(9, 0, 0),
                    fim = new TimeSpan(12, 30, 0),
                    vagasRestantes = 1
                }

            };


            clvCandidatura.ItemsSource = vaga;         
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnConfirmar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventoAtivo());
        }
    }
}