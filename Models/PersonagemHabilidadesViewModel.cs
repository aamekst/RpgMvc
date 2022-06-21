using System.Collections.Generic;

namespace RpgMvc.Models
{
    public class PersonagemHabilidadesViewModel
    {
        public int PersonagemId {get; set;}
        public PersonagemViewModel Personagem {get; set;}
        public int HabilidadeId {get; set;}
        public HabilidadeViewModel Habilidade {get; set;}

        public List<PersonagemHabilidadesViewModel> PersonagemHabilidades { get; set;}
    }
}