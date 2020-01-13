using System;
using System.Collections.Generic;
using System.Linq;
using estudo3.Models;

namespace estudo3.Repositories
{
    public class FundoCapitalRespository : IFundoCapitalRespository
    {
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRespository()
        {
            _storage = new List<FundoCapital>();
        }

        public void Adicionar(FundoCapital fundo)
        {
            _storage.Add(fundo);
        }

        public void Alterar(FundoCapital fundo)
        {
            var index = _storage.FindIndex(0, 1, X => X.Id == fundo.Id);
            _storage [index] = fundo;
        }

        public IEnumerable<FundoCapital> listarFundos()
        {
            return _storage;
        }

        public FundoCapital ObterPorId(Guid id)
        {
            return _storage.FirstOrDefault(x => x.Id == id);
            
        }

        public void RemoverFundo(FundoCapital fundo)
        {
            _storage.Remove(fundo);
        }
    }
}