using Microsoft.AspNetCore.Mvc;
using MimicAPI_5.Database;
using MimicAPI_5.Model;

namespace MimicAPI_5.Controllers
{
    [Route("api/palavras")]
    public class PalavrasController : ControllerBase
    {
        private readonly MimicContext _banco;
        public PalavrasController(MimicContext banco)
        {
            _banco = banco;
        }

        [Route("")] //rota que será acessada
        [HttpGet]
        public ActionResult ObterPalavras()
        {
            return Ok(_banco.Palavras);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult ObterPalavra(int id)
        {
            var obj = _banco.Palavras.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(_banco.Palavras.Find(id));
        }

        [Route("")]
        [HttpPost]
        public ActionResult Cadastrar([FromBody] Palavra palavra)
        {
            _banco.Palavras.Add(palavra);
            _banco.SaveChanges();
            return Ok();
        }
        [Route("{id}")]
        [HttpPut]
        public ActionResult Atualizar(int id, Palavra palavra)
        {
            var obj = _banco.Palavras.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            palavra.Id = id;
            _banco.Palavras.Update(palavra);
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Deletar(int id)
        {
            var obj = _banco.Palavras.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            var palavra = _banco.Palavras.Find(id);
                palavra.Ativo = false;
            _banco.Palavras.Update(palavra);
                //_banco.Palavras.Remove(_banco.Palavras.Find(id));
            return Ok();
        }
    }
}
