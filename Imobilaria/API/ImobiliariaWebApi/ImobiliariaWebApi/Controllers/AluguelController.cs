using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImobiliariaWebApi.Domains;
using ImobiliariaWebApi.Interfaces;
using ImobiliariaWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaWebApi.Controllers
{   
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _aluguelRepository;

        public AluguelController()
        {
            _aluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_aluguelRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_aluguelRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Aluguel novoAluguel)
        {
            _aluguelRepository.Cadastrar(novoAluguel);

            return Ok("Novo Aluguel Cadastrado com Sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _aluguelRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPorId(int id, Aluguel aluguelAtualizado)
        {
            Aluguel aluguel = _aluguelRepository.BuscarPorId(id);

            if (id == null)
            {
                try
                {
                    _aluguelRepository.Atualizar(id, aluguelAtualizado);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

                return NotFound("Id Especificado não encontrada, ou não existe no Banco de Dados");
            }

            return StatusCode(404);
        }
    }   
}
