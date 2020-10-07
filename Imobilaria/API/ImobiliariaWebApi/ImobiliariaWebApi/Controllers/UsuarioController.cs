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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return Ok("Novo Usuário Cadastrado com Sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPorId(int id, Usuario usuarioAtualizado)
        {
            Usuario usuario = _usuarioRepository.BuscarPorId(id);

            if (id == null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);
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
