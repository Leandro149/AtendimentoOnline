using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoOnline.Entidade;
using System.Data.Entity;

namespace AtendimentoOnline.DAL
{
    public class CadastroPessoaDAL
    {

        public int CadastroPessoa(Pessoa _pessoa)
        {
            Context db = new Context();
            Pessoa pessoa = new Pessoa();

            try
            {
                if (_pessoa.id > 0)
                {
                    pessoa = db.Pessoas.First(x => x.id == _pessoa.id);

                    pessoa.id = _pessoa.id;
                    pessoa.Nome = _pessoa.Nome.ToUpper();
                    pessoa.IdSexo = _pessoa.IdSexo;
                    pessoa.IdTipoPessoa = _pessoa.IdTipoPessoa;
                    pessoa.Documento = _pessoa.Documento;
                    pessoa.Email = _pessoa.Email;
                    pessoa.DataNascimento = _pessoa.DataNascimento;
                    pessoa.Celular = _pessoa.Celular;
                    pessoa.Telefone = _pessoa.Telefone;
                    pessoa.Descricao = _pessoa.Descricao;
                    pessoa.DataAlteracao = DateTime.Now;
                    pessoa.idUsuarioAlteracao = 1;
                    pessoa.TituloMunicipio = _pessoa.TituloMunicipio;

                    Endereco e = db.Enderecos.Find(_pessoa.Endereco.id);

                    e.CEP = _pessoa.Endereco.CEP.Replace("-", "");
                    e.Logradouro = _pessoa.Endereco.Logradouro;
                    e.Numero = _pessoa.Endereco.Numero;
                    e.Complemento = _pessoa.Endereco.Complemento;
                    e.Bairro = _pessoa.Endereco.Bairro;
                    e.Cidade = _pessoa.Endereco.Cidade;
                    e.UF = _pessoa.Endereco.UF;


                    db.Entry<Endereco>(e).State = EntityState.Modified;


                    db.Entry(pessoa).State = EntityState.Modified;

                }
                else
                {
                    _pessoa.Ativo = true;
                    _pessoa.DataAlteracao = DateTime.Now;
                    _pessoa.DataCadastro = DateTime.Now;
                    _pessoa.idUsuarioCadastro = 1;
                    _pessoa.idUsuarioAlteracao = 1;
                    _pessoa.Nome = _pessoa.Nome.ToUpper();

                    _pessoa.Endereco.Ativo = true;
                    _pessoa.Endereco.DataAlteracao = DateTime.Now;
                    _pessoa.Endereco.DataCadastro = DateTime.Now;
                    _pessoa.Endereco.idUsuarioCadastro = 1;
                    _pessoa.Endereco.idUsuarioAlteracao = 1;
                    _pessoa.Endereco.CEP = _pessoa.Endereco.CEP.Replace("-", "");

                    db.Pessoas.Add(_pessoa);
                }
                                    
                db.SaveChanges();

                var retorno = _pessoa.id;
                return retorno;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
    }
}
