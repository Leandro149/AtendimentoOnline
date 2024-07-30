using System;

namespace AtendimentoOnline.DTO
{
   public class DescritivoDTO 
    {
        public string NomeDescritivo { get; set; }
        public Nullable<int> IdAtendimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public AtendimentoDTO Atendimento { get; set; }
    }
}
