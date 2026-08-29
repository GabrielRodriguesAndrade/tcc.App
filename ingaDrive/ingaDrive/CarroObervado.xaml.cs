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
    public partial class CarroObervado : ContentPage
    {
        private vagas _item;
        private int tempoTotal = 60;
        private int tempoRestante;
        public CarroObervado(vagas item)
        {
            InitializeComponent();
            _item = item;

            lblVaga.Text = $"Vaga: {_item.vaga}";
            lblCarro.Text = $"Carro: {_item.carro}";

            tempoRestante = tempoTotal;
            
        }


        private void StartRelogio()
        {
            double larguraMax = gridBase.Width;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                tempoRestante--;

                if (tempoRestante < 0)
                    return false;

                lblTempo.Text = tempoRestante.ToString();

                // Calcula largura da máscara com base no tempo decorrido
                double perc = 1.0 - (double)tempoRestante / tempoTotal;
                double novaLargura = larguraMax * perc;

                Device.BeginInvokeOnMainThread(() =>
                {
                    mascara.WidthRequest = novaLargura;
                });

                return true;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Espera o layout calcular tamanho para pegar altura real
            gridBase.SizeChanged += (s, e) =>
            {
                StartRelogio();
            };
        }
    }
}