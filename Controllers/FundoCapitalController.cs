using System;
using System.Collections.Generic;
using estudo3.Models;
using estudo3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace estudo3.Controllers
{
    public class FundoCapitalController:Controller
    {
        private readonly IFundoCapitalRespository _repositorio;

        public FundoCapitalController(IFundoCapitalRespository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("v1/FundoCapital")]
        public IActionResult ListarFundos()
        {
          return Ok(
            new List<FundoCapital>{
                    new FundoCapital{
                        Nome = "Viagem de ferias",
                        ValorAtual = 200,
                        ValorNecessario = 5000,
                        DateResgate = new DateTime(2019, 12, 1)
                    },
                     new FundoCapital{
                        Nome = "Reserva de emergência",
                        ValorAtual = 400,
                        ValorNecessario = 10000,
                    }
                }
          );
        }
    
        [HttpPost("v1/FundoCapital")]
        public IActionResult AdicionarFundos([FromBody]FundoCapital fundo)
        {
            _repositorio.Adicionar(fundo);
            return Ok(); 
        } 
        [HttpPut("v1/FundoCapital/{id}")]
        public IActionResult AlterarFundos(Guid id, [FromBody]FundoCapital fundo)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);
            if(fundoAntigo ==null)
            {
                return NotFound();
            }
             fundoAntigo.Nome = fundo.Nome;
             fundoAntigo.ValorAtual = fundo.ValorAtual;
             fundoAntigo.ValorNecessario = fundo.ValorNecessario;
             fundoAntigo.DataResgate = fundo.DataResgate;
             _repositorio.Alterar(fundoAntigo);

            return Ok();
        } 
        [HttpGet("v1/FundoCapital/{id}")]
        public IActionResult ObterFundos(Guid id)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);
            if(fundoAntigo ==null)
            {
                return NotFound();
            }
            return Ok(fundoAntigo); 
        } 
        [HttpGet("v1/FundoCapital/{id}")]
        public IActionResult RemoverFundos(Guid id)
        {
            var fundo = _repositorio.ObterPorId(id);
            if(fundo ==null)
            {
                return NotFound();
            }
            _repositorio.RemoverFundo(fundo); 
            return Ok(); 
        } 
    }
}
                        