using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAtleta.Models
{
    public enum Tamanho {P,M,G }

    public class Uniforme
    {
        public int UniformeId { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public  Tamanho Tamanho { get; set; }
        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }


    }
}