using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppAtleta.Models
{
    public enum Classificacao {Infantil,Juvenil,Adulto};
    public class Atleta
    {
        public int AtletaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Classificacao Classificacao { get; set; }
        public virtual ICollection<Uniforme> Uniforme{ get; set; }

        public void classifica()
        {
            if(Idade < 12)
            {
                Classificacao = Classificacao.Infantil;
            }
            else if(Idade> 12 && Idade <= 18)
            {
                Classificacao = Classificacao.Juvenil;
            }
            else
            {
                Classificacao = Classificacao.Adulto;
            }
        }

    }
}