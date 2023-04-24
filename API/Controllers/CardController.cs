using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Services;

namespace API.Controllers
{
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly Services.CardServices _service;
        public CardController(Services.CardServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Card/{id:int}")]
        public Card GetById(int id)
        {

            return _service.GetCard(id);

        }

        [HttpGet]
        [Route("Cards")]
        public List<Card> GetAll()
        {
            return _service.GetAll();
        }



        [HttpPost]
        [Route("Card/create")]
        public IActionResult Create([FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.CreateCard(card);
            return Ok(_service.GetCard(card.Id));
        }

        [HttpPut]
        [Route("Card/update")]
        public IActionResult UpdateCard([FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCard = _service.UpdateCard(card);
            if (updatedCard == null)
            {
                return NotFound();
            }

            return Ok(updatedCard);
        }
        
        [HttpDelete]
        [Route("Card/Delete")]
        public Card DeleteCard(Card u)
        {
            return _service.DeleteCard(u);
        }
    }
}
