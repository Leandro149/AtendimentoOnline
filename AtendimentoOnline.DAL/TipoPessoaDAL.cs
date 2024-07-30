using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using System.Data.Entity;

namespace AtendimentoOnline.DAL
{
    public class TipoPessoaDAL
    {
        public List<TipoPessoa> ObterTipoPessoa()

        {
            Context db = new Context();

            List<TipoPessoa> listaTipoPessoa = new List<TipoPessoa>();

            var query = (from s in db.TipoPessoas
                         where s.Ativo == true
                         orderby s.id
                         select new { s.id, s.Nome }).ToList();

            foreach (var list in query)
            {
                TipoPessoa sx = new TipoPessoa();
                sx.id = list.id;
                sx.Nome = list.Nome;
                listaTipoPessoa.Add(sx);
            }
            return listaTipoPessoa;
        }
    }
}
