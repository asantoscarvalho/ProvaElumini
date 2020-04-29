using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoContato.Repository.Interface;
using ProjetoContato.Domain.Dtos;
using ProjetoContato.Domain.Model;

namespace ProjetoContato.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
          private readonly IContatoRepository _repo;
        private readonly IMapper _map;

        public ContatoController(IContatoRepository repo, IMapper map)
        {
            this._repo = repo;
            this._map = map;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> Get()
        {
            try
            {
                var Contatos = await _repo.GetContatoAsync();

                var results = _map.Map<IEnumerable<ContatoDto>>(Contatos);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{ContatoId}")]
        public async Task<ActionResult> Get(int ContatoId)
        {
            try
            {
                var Contato = await _repo.GetContatoAsyncById(ContatoId);

                var results = _map.Map<ContatoDto>(Contato);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }



        }

        [HttpGet("Nome/{Nome}")]
        public async Task<ActionResult> Get(string Nome)
        {
            try
            {
                var Contato = await _repo.GetContatoAsyncByName(Nome);

                var results = _map.Map<IEnumerable<ContatoDto>>(Contato);

                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(ContatoDto model)
        {
            try
            {
                var modelo = _map.Map<Contato>(model);

                _repo.Add(modelo);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/Contato/{modelo.Id}",  _map.Map<ContatoDto>(modelo));
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }

        [HttpPut("{Contatoid}")]
        public async Task<ActionResult> Put(int ContatoId, ContatoDto model)
        {
            try
            {
                var Contato = await _repo.GetContatoAsyncById(ContatoId);
                if (Contato == null) return NotFound();

                _map.Map(model, Contato);

                _repo.Update(Contato);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/Contato/{model.Id}", _map.Map<ContatoDto>(Contato));
                }


            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();

        }

        [HttpDelete("{ContatoId}")]
        public async Task<ActionResult> Delete(int ContatoId)
        {
            try
            {
                var Contato = await _repo.GetContatoAsyncById(ContatoId);
                if (Contato == null) return NotFound();

                _repo.Delete(Contato);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();

        }
    }
}