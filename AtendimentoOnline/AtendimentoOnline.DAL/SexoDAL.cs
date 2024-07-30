using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using System.Data.Entity;

namespace AtendimentoOnline.DAL
{
    public class SexoDAL
    {

        public List<Sexo> ObterSexo()

        {
            Context db = new Context();

            List<Sexo> listaSexo = new List<Sexo>();

                var query = (from s in db.Sexos
                            where s.Ativo == true
                             orderby s.id
                             select new { s.id, s.Nome }).ToList();

            foreach(var list in query)
            {
                Sexo sx = new Sexo();
                sx.id = list.id;
                sx.Nome = list.Nome;
                listaSexo.Add(sx);
            }
            return listaSexo;
        }

    }
}
