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
    public class HomeModel
    {
        public int Aberto { get; set; }

        public int Andamento { get; set; }

        public int Resolvido { get; set; }

        public int Fechado { get; set; }

        public List<AtendimentoDTO> ListaAtendimento { get; set; }


    }
}