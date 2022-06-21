
using System;
using System.Collections.Generic;

namespace RpgMvc.Models
{
    public class DisputasViewModel
    {
        
        public int Id { get; set;}

        public DateTime? DataDisputa{ get; set;}

        public int AtacanteId { get; set;}

        public int OponenteId{ get; set;}

        public string  HabilidadeId{ get; set;}

        public string Narracao { get; set;}
        
        public List<int> listaPersonagens {get; set;} = new List<int>();
    
        public List<string> Resultados {get; set;} = new List<string>();
    
         
    }
}
     