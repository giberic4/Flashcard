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
        public List<Card> Create(Card u)
        {
            _service.CreateCard(u);
            return _service.GetAll();
        }

        [HttpPut]
        [Route("Card/update")]
        public Card UpdateCard(Card u)
        {
            return _service.UpdateCard(u);

        }
        
        [HttpDelete]
        [Route("Card/Delete")]
        public Card DeleteCard(Card u)
        {
            return _service.DeleteCard(u);
        }
    }
}