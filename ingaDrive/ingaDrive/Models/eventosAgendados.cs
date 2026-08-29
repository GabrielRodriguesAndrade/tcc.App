using System;
using System.Collections.Generic;
using System.Text;

namespace ingaDrive.Models
{
    public class eventosAgendados
    {
        public string empresa { get; set; }
        public string local { get; set; }
        public string valor { get; set; }
        public DateTime data { get; set; }
        public TimeSpan inicio { get; set; }
        public TimeSpan fim { get; set; }
        public string dataFinal => $"{data:dd 'de' MMM 'de' yyyy}{inicio:hh\\mm} - {fim:hh\\mm}";
    }
}
