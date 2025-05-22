using System.Runtime.InteropServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        public static List<Livro> _livros = new();

        [HttpPost]
        public IActionResult Criar([FromBody] Livro livro)
        {
            _livros.Add(livro);
            return Created(string.Empty, livro);
        }


        [HttpGet]
        public IActionResult Mostrar()
        {
            return Ok(_livros);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult MostrarPorId([FromHeader] int id)
        {
            var verify = _livros;
            foreach (var p in verify)
            {
                if (id == p.Id)
                {
                    return Ok(p);
                }
                else
                {
                    return NotFound("Não encontrado");
                }
            }
            return Ok(verify);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Atualizar(
            [FromRoute] int id,
            [FromBody] Livro livro)
        {
            var validator = _livros.FirstOrDefault(p => p.Id == id);

            if (validator == null)
            {
                return NotFound();
            }
            else{
                validator.Titulo = livro.Titulo;
                validator.Autor = livro.Autor;
                validator.Genero = livro.Genero;
                validator.Preco = livro.Preco;
                validator.Quantidade = livro.Quantidade;
            }
            return Ok(validator);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            var validator = _livros.FirstOrDefault(p => p.Id == id);

            if (validator == null)
            {
                return NotFound("Não encontrado");
            }

            var apagar = _livros.Remove(validator);
            return Ok(apagar);
        }
    }
}