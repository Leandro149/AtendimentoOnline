using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using System.Data.Entity;


namespace AtendimentoOnline.DAL
{
    public class CategoriaDAL
    {
        public List<Categoria> ObterCategoria()
        {
            Context db = new Context();

            List<Categoria> listaCategoria = new List<Categoria>();

            var query = (from s in db.Categorias
                         where s.Ativo == true
                         orderby s.id
                         select new { s.id, s.NomeCategoria }).ToList();

            foreach (var list in query)
            {
                Categoria sx = new Categoria();
                sx.id = list.id;
                sx.NomeCategoria = list.NomeCategoria;
                listaCategoria.Add(sx);
            }
            return listaCategoria;
        }
    }
}
