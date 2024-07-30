using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using System.Data.Entity;

namespace AtendimentoOnline.DAL
{
    public class TipoAtendimentoDAL
    {
        public List<TipoAtendimento> ObterTipoAtendimento()
        {
            Context db = new Context();

            List<TipoAtendimento> listaTipoAtendimento = new List<TipoAtendimento>();

            var query = (from s in db.TipoAtendimentos
                         where s.Ativo == true
                         orderby s.id
                         select new { s.id, s.NomeTipoAtendimento }).ToList();

            foreach (var list in query)
            {
                TipoAtendimento sx = new TipoAtendimento();
                sx.id = list.id;
                sx.NomeTipoAtendimento = list.NomeTipoAtendimento;
                listaTipoAtendimento.Add(sx);
            }
            return listaTipoAtendimento;
        }
    }
}
