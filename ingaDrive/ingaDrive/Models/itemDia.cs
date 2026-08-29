using System;
using System.Collections.Generic;
using System.Text;

namespace ingaDrive.Models
{
    public class vagas
    {
        public string vaga { get; set; } // O número do dia ("1", "2", "3", etc.), ou "" vazio para espaço
        public string carro { get; set; } // Se o dia tem evento
    }
}
