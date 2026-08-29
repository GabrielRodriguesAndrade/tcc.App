using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfCalendar.XForms;
using System.Collections.ObjectModel;
using System.Globalization;
using ingaDrive.Models;

namespace ingaDrive
{
    public partial class MainPage : TabbedPage
    {
        public class eventosAgendados
        {
            public string empresa { get; set; }
            public string local { get; set; }
            public string valor { get; set; }
            public DateTime data { get; set; }
            public TimeSpan inicio { get; set; }
            public TimeSpan fim { get; set; }
            public string dataFinal => $"{data.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("pt-BR"))} {inicio:hh\\:mm} - {fim:hh\\:mm}";
        }
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
        public class itemDia
        {
            public string diaNumero { get; set; } // O número do dia ("1", "2", "3", etc.), ou "" vazio para espaço
            public bool temEvento { get; set; } // Se o dia tem evento
        }
        public class diasDoMes
        {
            public int ano { get; set; }
            public int mes { get; set; }
            public List<itemDia> dias { get; set; }
            public string nomeMes => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                                        new DateTime(ano, mes, 1).ToString("MMMM yyyy", new CultureInfo("pt-BR")));
        }
        public ObservableCollection<diasDoMes> meses { get; set; } = new ObservableCollection<diasDoMes>();
        
        
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            int anoAtual = DateTime.Now.Year;
            int anosTotal = 5;

            for (int ano = anoAtual; ano < anoAtual + anosTotal; ano++)
            {
                for (int mes = 1; mes <= 12; mes++)
                {
                    meses.Add(new diasDoMes
                    {
                        ano = ano,
                        mes = mes,
                        dias = gerarDias(ano, mes)
                    });
                }
            }

            crsView.ItemsSource = meses;


            List<eventosAgendados> listaEventos = new List<eventosAgendados>
            {
                new eventosAgendados
                {
                    empresa = "Tech Solutions",
                    local = "São Paulo - SP",
                    valor = "R$ 135,00",
                    data = new DateTime(2025, 5, 12),
                    inicio = new TimeSpan(9, 0, 0),
                    fim = new TimeSpan(12, 30, 0)
                },
                new eventosAgendados
                {
                    empresa = "Alfa Engenharia",
                    local = "Belo Horizonte - MG",
                    valor = "R$ 100,00",
                    data = new DateTime(2025, 5, 7),
                    inicio = new TimeSpan(18, 30, 0),
                    fim = new TimeSpan(23, 0, 0)
                },
                new eventosAgendados
                {
                    empresa = "Mega Eventos",
                    local = "Curitiba - PR",
                    valor = "R$ 150,00",
                    data = new DateTime(2025, 6, 3),
                    inicio = new TimeSpan(14, 15, 0),
                    fim = new TimeSpan(17, 0, 0)
                },
                new eventosAgendados
                {
                    empresa = "ConsultCorp",
                    local = "Rio de Janeiro - RJ",
                    valor = "R$ 100,00",
                    data = new DateTime(2025, 6, 18),
                    inicio = new TimeSpan(19, 0, 0),
                    fim = new TimeSpan(22, 45, 0)
                }
            };

            clvEventos.ItemsSource = listaEventos;

            List<vagas> listaVagas = new List<vagas>
            {
                new vagas
                {
                    empresa = "InovaTech",
                    local = "Florianópolis - SC",
                    valor = "R$ 120,00",
                    data = new DateTime(2025, 5, 15),
                    inicio = new TimeSpan(10, 0, 0),
                    fim = new TimeSpan(13, 30, 0),
                    vagasRestantes = 35
                },
                new vagas
                {
                    empresa = "GreenData",
                    local = "Porto Alegre - RS",
                    valor = "R$ 90,00",
                    data = new DateTime(2025, 5, 10),
                    inicio = new TimeSpan(17, 0, 0),
                    fim = new TimeSpan(21, 15, 0),
                    vagasRestantes = 28
                },
                new vagas
                {
                    empresa = "Eventos Brasil",
                    local = "Recife - PE",
                    valor = "R$ 160,00",
                    data = new DateTime(2025, 6, 8),
                    inicio = new TimeSpan(13, 0, 0),
                    fim = new TimeSpan(16, 30, 0),
                    vagasRestantes = 42
                },
                new vagas
                {
                    empresa = "Nova Ideia",
                    local = "Brasília - DF",
                    valor = "R$ 110,00",
                    data = new DateTime(2025, 6, 20),
                    inicio = new TimeSpan(18, 45, 0),
                    fim = new TimeSpan(22, 0, 0),
                    vagasRestantes = 31
                }
            };
            clvVagas.ItemsSource = listaVagas;

        }

        private void CarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            // Pode deixar vazio se quiser
        }

        public List<itemDia> gerarDias(int ano, int mes)
        {
            List<itemDia> dias = new List<itemDia>();

            int diasNoMes = DateTime.DaysInMonth(ano, mes);
            DateTime primeiroDiaMes = new DateTime(ano, mes, 1);

            int diaInicialSemana = (int)primeiroDiaMes.DayOfWeek;//dia da semana

            for (int i = 0; i < diaInicialSemana; i++)
            {
                dias.Add(new itemDia { diaNumero = "", temEvento = false }); // espaços vazios no começo
            }

            for (int dia = 1; dia <= diasNoMes; dia++)
            {
                bool hasEvent = checaEvento(ano, mes, dia);
                dias.Add(new itemDia
                {
                    diaNumero = dia.ToString(),
                    temEvento = hasEvent
                });
            }

            return dias;
        }
        private bool checaEvento(int ano, int mes, int dia)
        {
       
            if ((dia == 5 || dia == 15) && mes == 4 && ano == 2025)
                return true;//com evento

            return false;//sem evento
        }

        private void btnCandidatar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConfirmarCandidatura());
        }
    }
} 


      
          
                

