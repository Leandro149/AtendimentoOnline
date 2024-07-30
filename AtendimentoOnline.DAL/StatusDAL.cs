using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using System.Data.Entity;

namespace AtendimentoOnline.DAL
{
   public class StatusDAL
    {
        public List<Status> ObterStatus()
        {
            Context db = new Context();

            List<Status> listaStatus = new List<Status>();

            var query = (from s in db.Statuss
                         where s.Ativo == true
                         orderby s.id
                         select new { s.id, s.NomeStatus }).ToList();

            foreach (var list in query)
            {
                Status sx = new Status();
                sx.id = list.id;
                sx.NomeStatus = list.NomeStatus;
                listaStatus.Add(sx);
            }
            return listaStatus;
        }
    }
}
