using System;
using System.Collections.Generic;
using estudo3.Models;

namespace estudo3.Repositories
{
    public interface IFundoCapitalRespository
    {
        void Adicionar(FundoCapital fundo);
        void Alterar(FundoCapital fundo);
        IEnumerable<FundoCapital> listarFundos();
        FundoCapital ObterPorId(Guid id);
        void RemoverFundo(FundoCapital fundo);
    }
}