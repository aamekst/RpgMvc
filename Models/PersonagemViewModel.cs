using System.Collections.Generic;
using System.Text.Json.Serialization;
using RpgMvc.Models.Enums;
using System;


namespace RpgMvc.Models


{
    public class PersonagemViewModel
    {
         public int Id { get; set; }

        public string Nome  { get; set; }

        public int Pontosvida { get; set; }

        public int Forca { get; set; }

        public int Defesa { get; set; }

        public int Inteligencia { get; set; }

        public ClassEnum Classe { get; set; }

        public byte[] FotoPersonagem {get; set;}
        
        public int Disputas { get; set;}

        public int Vitorias { get; set;}
        
        public int Derrotas { get; set;}

        public UsuarioViewModel Usuario { get; set; }
        
 
        // public Usuario Usuario { get; set;}

      

       // public Arma Arma { get; set;}

        //public List<PersonagemHabilidade> PersonagemHabilidade { get; set;}

    }
}