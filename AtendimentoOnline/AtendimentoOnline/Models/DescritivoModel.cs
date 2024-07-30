using System;
using System.Collections.Generic;
using System.Linq;
using AtendimentoOnline.Models;
using AtendimentoOnline.Business;
using AtendimentoOnline.Entidade;
using AtendimentoOnline.DTO;
using System.Web.Mvc;
using AutoMapper;

namespace AtendimentoOnline.Models
{
    public class DescritivoModel
    {
        public string NomeDescritivo { get; set; }
        public int IdAtendimento { get; set; }
        public AtendimentoDTO Atendimento { get; set; }
    }
}