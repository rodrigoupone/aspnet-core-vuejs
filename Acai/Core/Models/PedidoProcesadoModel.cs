using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class PedidoProcesadoModel
    {
        public string Tamanho { get; set; }

        public string Sabor { get; set; }

        public string Personalizacoes { get; set; }

        public int TempoTotal { get; set; }

        public decimal ValorTotal { get; set; }

    }
}


