using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using AtendimentoOnline.DTO;
using System.Data.Entity;
using AutoMapper;


namespace AtendimentoOnline.DAL
{
    public class AtendimentoDAL
    {
        public List<AtendimentoDTO> BuscaAtendimento(int? idAtendimento, int? numAtendimento, string nome)

        {
            Context db = new Context();

            List<AtendimentoDTO> listaAtendimento = new List<AtendimentoDTO>();

            if (idAtendimento != null)
            {
                var query = (from id in db.Atendimentos
                             where id.id == idAtendimento
                             orderby id.Codigo
                             select new { id.id, id.Pessoa.Nome, id.Categoria.NomeCategoria, id.Codigo, id.TipoAtendimento.NomeTipoAtendimento, id.Status.NomeStatus, id.DataCadastro }).ToList();

                foreach (var list in query)
                {
                    AtendimentoDTO at = new AtendimentoDTO();
                    at.Id = list.id;
                    at.Pessoa = list.Nome;
                    at.Categoria = list.NomeCategoria;
                    at.Codigo = list.Codigo;
                    at.TipoAtendimento = list.NomeTipoAtendimento;
                    at.Status = list.NomeStatus;
                    at.DataCadastro = list.DataCadastro;
                    listaAtendimento.Add(at);
                }
            }
            else if (numAtendimento != null)
            {
                var document = (from id in db.Atendimentos
                                where id.Codigo == numAtendimento
                                orderby id.Codigo
                                select new { id.id, id.Pessoa.Nome, id.Categoria.NomeCategoria, id.Codigo, id.TipoAtendimento.NomeTipoAtendimento, id.Status.NomeStatus, id.DataCadastro }).ToList();

                foreach (var list in document)
                {
                    AtendimentoDTO at = new AtendimentoDTO();
                    at.Id = list.id;
                    at.Pessoa = list.Nome;
                    at.Categoria = list.NomeCategoria;
                    at.Codigo = list.Codigo;
                    at.TipoAtendimento = list.NomeTipoAtendimento;
                    at.Status = list.NomeStatus;
                    at.DataCadastro = list.DataCadastro;
                    listaAtendimento.Add(at);
                }
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                var nom = (from id in db.Atendimentos
                           where id.Pessoa.Nome.Contains(nome)
                           orderby id.Codigo
                           select new { id.id, id.Pessoa.Nome, id.Categoria.NomeCategoria, id.Codigo, id.TipoAtendimento.NomeTipoAtendimento, id.Status.NomeStatus, id.DataCadastro }).ToList();

                foreach (var list in nom)
                {
                    AtendimentoDTO at = new AtendimentoDTO();
                    at.Id = list.id;
                    at.Pessoa = list.Nome;
                    at.Categoria = list.NomeCategoria;
                    at.Codigo = list.Codigo;
                    at.TipoAtendimento = list.NomeTipoAtendimento;
                    at.Status = list.NomeStatus;
                    at.DataCadastro = list.DataCadastro;
                    listaAtendimento.Add(at);
                }
            }

            return listaAtendimento;
        }

        public int IncluirAtendimento(Atendimento _atendimento)
        {
            Context db = new Context();
            Atendimento atendimento = new Atendimento();

            try
            {
                if (_atendimento.id > 0)
                {

                    atendimento = db.Atendimentos.First(x => x.id == _atendimento.id);

                    atendimento.id = _atendimento.id;
                    atendimento.Descricao = string.Empty;                   
                    atendimento.IdTipoAtendimento = _atendimento.IdTipoAtendimento;
                    atendimento.IdStatus = _atendimento.IdStatus;
                    atendimento.IdCategoria = _atendimento.IdCategoria;
                    atendimento.Descricao = _atendimento.Descricao;
                    atendimento.DataAlteracao = DateTime.Now;
                    atendimento.idUsuarioAlteracao = 1;

                    Endereco e = db.Enderecos.Find(_atendimento.Endereco.id);

                    e.CEP = _atendimento.Endereco.CEP.Replace("-", "");
                    e.Logradouro = _atendimento.Endereco.Logradouro;
                    e.Numero = _atendimento.Endereco.Numero;
                    e.Complemento = _atendimento.Endereco.Complemento;
                    e.Bairro = _atendimento.Endereco.Bairro;
                    e.Cidade = _atendimento.Endereco.Cidade;
                    e.UF = _atendimento.Endereco.UF;


                    db.Entry<Endereco>(e).State = EntityState.Modified;


                    db.Entry(atendimento).State = EntityState.Modified;

                    db.SaveChanges();

                }
                else
                {

                    Random ran = new Random();

                    var num = ran.Next(1000000000);

                    _atendimento.Ativo = true;
                    _atendimento.DataAlteracao = DateTime.Now;
                    _atendimento.DataCadastro = DateTime.Now;
                    _atendimento.idUsuarioCadastro = 1;
                    _atendimento.idUsuarioAlteracao = 1;
                    _atendimento.Codigo = num;

                    _atendimento.Endereco.Ativo = true;
                    _atendimento.Endereco.DataAlteracao = DateTime.Now;
                    _atendimento.Endereco.DataCadastro = DateTime.Now;
                    _atendimento.Endereco.idUsuarioCadastro = 1;
                    _atendimento.Endereco.idUsuarioAlteracao = 1;
                    _atendimento.Endereco.CEP = _atendimento.Endereco.CEP.Replace("-", "");                                        

                    db.Atendimentos.Add(_atendimento);

                    db.SaveChanges();

                    if (_atendimento.id > 0)
                    {
                        IncluirDescritivo(_atendimento.Descricao, _atendimento.id);
                    }

                }

                var retorno = _atendimento.id;
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int IncluirDescritivo(string _descritivo, int _idAtendimento)
        {
            Context db = new Context();
            Descritivo descritivo = new Descritivo();

            try
            {
                descritivo.Ativo = true;
                descritivo.DataAlteracao = DateTime.Now;
                descritivo.DataCadastro = DateTime.Now;
                descritivo.idUsuarioCadastro = 1;
                descritivo.idUsuarioAlteracao = 1;
                descritivo.IdAtendimento = _idAtendimento;
                descritivo.NomeDescritivo = _descritivo;

                db.Descritivos.Add(descritivo);

                db.SaveChanges();

                var retorno = descritivo.id;
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Descritivo> ObterDescritivo(int idAtendimento)
        {
            Context db = new Context();
            return db.Descritivos.Where(w => w.IdAtendimento == idAtendimento && w.Ativo == true)
                                 .OrderByDescending(o => o.DataCadastro).ToList();
        }

        public Atendimento ObterAtendimento(int idAtendimento)
        {
            using (var context = new Context())
            {
                return context.Atendimentos.Include("Endereco")
                    .FirstOrDefault(f => f.id == idAtendimento);
            }
        }

        public List<Atendimento> ObterAtendimentoPorStatus(int status)
        {
            using (var context = new Context())
            {
                return context.Atendimentos
                              .Include("Endereco")
                              .Include("Pessoa")
                              .Include("Status")
                              .Include("Categoria")
                              .Include("TipoAtendimento")
                              .Where(w => w.IdStatus == status).ToList();
            }
        }
    }
}
