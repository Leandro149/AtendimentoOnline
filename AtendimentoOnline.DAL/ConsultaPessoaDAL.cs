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
    public class ConsultaPessoaDAL
    {

        public List<PessoaDTO> BuscaPessoa(int? idPessoa, string documento, string nome)

        {
            Context db = new Context();

            List<PessoaDTO> listaPessoa = new List<PessoaDTO>();

            if (idPessoa != null)
            {
                var query = (from id in db.Pessoas
                             where id.id == idPessoa
                             orderby id.Nome
                             select new { id.id, id.Nome, id.Documento, id.DataNascimento, id.Endereco.Bairro, id.Endereco.Cidade, id.Endereco.Numero, id.Endereco.Complemento}).ToList();

                foreach (var list in query)
                {
                    PessoaDTO ps = new PessoaDTO();
                    ps.Id = list.id;
                    ps.Nome = list.Nome;
                    ps.Documento = list.Documento;
                    ps.DataNascimento = list.DataNascimento;
                    ps.Bairro = list.Bairro;
                    ps.Cidade = list.Cidade;
                    ps.Numero = list.Numero;
                    ps.Complemento = list.Complemento;
                    listaPessoa.Add(ps);
                }
            }else if(!string.IsNullOrEmpty(documento))
            {
                var document = (from id in db.Pessoas
                             where id.Documento == documento
                             orderby id.Nome
                             select new { id.id, id.Nome, id.Documento, id.DataNascimento, id.Endereco.Bairro, id.Endereco.Cidade }).ToList();

                foreach (var list in document)
                {
                    PessoaDTO ps = new PessoaDTO();
                    ps.Id = list.id;
                    ps.Nome = list.Nome;
                    ps.Documento = list.Documento;
                    ps.DataNascimento = list.DataNascimento;
                    ps.Bairro = list.Bairro;
                    ps.Cidade = list.Cidade;
                    listaPessoa.Add(ps);
                }
            }
            else if(!string.IsNullOrEmpty(nome))
            {
                var nom = (from id in db.Pessoas
                           where id.Nome.Contains(nome)
                                orderby id.Nome
                                select new { id.id, id.Nome, id.Documento, id.DataNascimento, id.Endereco.Bairro, id.Endereco.Cidade }).ToList();

                foreach (var list in nom)
                {
                    PessoaDTO ps = new PessoaDTO();
                    ps.Id = list.id;
                    ps.Nome = list.Nome;
                    ps.Documento = list.Documento;
                    ps.DataNascimento = list.DataNascimento;
                    ps.Bairro = list.Bairro;
                    ps.Cidade = list.Cidade;
                    listaPessoa.Add(ps);
                }
            }

            return listaPessoa;
        }

        public Pessoa ObterPessoa(int idPessoa)
        {
            using (var context = new Context())
            {
                return context.Pessoas.Include("Endereco")
                    .FirstOrDefault(f => f.id == idPessoa);               
            }                                             
        }
    }
}
