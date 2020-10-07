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
    public class SituacaoController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository;

        public SituacaoController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_situacaoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_situacaoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Situacao novaSituacao)
        {
            _situacaoRepository.Cadastrar(novaSituacao);

            return Ok("Nova Situação Cadastrado com Sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _situacaoRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPorId(int id, Situacao situacaoAtualizada)
        {
            Situacao situacao = _situacaoRepository.BuscarPorId(id);

            if (id == null)
            {
                try
                {
                    _situacaoRepository.Atualizar(id, situacaoAtualizada);
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
