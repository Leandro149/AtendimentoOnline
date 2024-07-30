using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using System.Data.Entity;

namespace AtendimentoOnline.DAL
{
    public class MunicipioDAL
    {
        public List<Municipio>obterMunicipio()

        {
            Context db = new Context();

            List<Municipio> listaMunicipio = new List<Municipio>();

            var query = (from s in db.Municipios
                         orderby s.id
                         select new { s.id, s.Nome }).ToList();

            foreach (var list in query)
            {
                Municipio sx = new Municipio();
                sx.id = list.id;
                sx.Nome = list.Nome;
                listaMunicipio.Add(sx);
            }
            return listaMunicipio;
        }
    }
}
