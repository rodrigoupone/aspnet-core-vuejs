using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TamanhoController : ControllerBase
    {
        private readonly Core.Feature.TamanhoFeature _feature;

        public TamanhoController(Core.Feature.TamanhoFeature feature)
        {
            _feature = feature;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _feature.GetItems();
            return StatusCode((int)response.Status, response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var response = await _feature.BuscarPorId(id);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Tamanho obj)
        {
            var response = await _feature.Adicionar(obj);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Del(Guid id)
        {
            var response = await _feature.Remover(id);
            return StatusCode((int)response.Status, response);
        }


    }
}