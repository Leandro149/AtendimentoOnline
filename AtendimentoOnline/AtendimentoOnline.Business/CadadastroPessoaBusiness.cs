using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtendimentoOnline.DAL;
using AtendimentoOnline.Entidade;

namespace AtendimentoOnline.Business
{
    public class CadadastroPessoaBusiness
    {
        public int CadastroPessoa(Pessoa Pessoa)
        {
            CadastroPessoaDAL PessoaDal = new CadastroPessoaDAL();

            var retorno = 0;
                retorno = PessoaDal.CadastroPessoa(Pessoa);

        return retorno;
        }

        public List<Sexo> ObterSexo()
        {
            SexoDAL SexoDal = new SexoDAL();
            var retorno = SexoDal.ObterSexo();
            return retorno;
        }

        public List<TipoPessoa> ObterTipoPessoa()
        {
            TipoPessoaDAL TipoPessoaDal = new TipoPessoaDAL();
            var retorno = TipoPessoaDal.ObterTipoPessoa();
            return retorno;
        }

        public List<Municipio> ObterMunicipio()
        {
            MunicipioDAL municipioDal = new MunicipioDAL();
            var retorno = municipioDal.obterMunicipio();
            return retorno;
        }

    }

}
