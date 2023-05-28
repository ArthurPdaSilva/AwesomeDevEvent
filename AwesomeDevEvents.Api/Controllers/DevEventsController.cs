using AwesomeDevEvents.Api.Entities;
using AwesomeDevEvents.Api.Interfaces;
using AwesomeDevEvents.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEvents.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Com ela, eu não preciso colocar [FromBody] ao receber o objeto
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _dbContext;

        public DevEventsController(DevEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _dbContext.DevEvents
                .Where(d => !d.IsDeleted)
                .ToList();

            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _dbContext.DevEvents.SingleOrDefault(d => d.Id == id);
            if(devEvent == null) return NotFound();
            return Ok(devEvent);

        }

        [HttpPost]
        public IActionResult Post(DevEvent devEvent) {
            _dbContext.DevEvents.Add(devEvent);
            //Objeto criado e execute a ação, acesse getById e passa o e o objeto
            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id}, devEvent );
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent devEvent) {
            var devEventUpdated = _dbContext.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEventUpdated == null) return NotFound();

            UpdateDevEventProp updateDevEventProp = new UpdateDevEventProp();
            updateDevEventProp.Title = devEvent.Title;
            updateDevEventProp.Description = devEvent.Description;
            updateDevEventProp.StartDate = devEvent.StartDate;
            updateDevEventProp.EndDate = devEvent.EndDate;

            devEventUpdated.Update(updateDevEventProp);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) {
            var devEvent = _dbContext.DevEvents.SingleOrDefault(d => d.Id == id);
            if (devEvent == null) return NotFound();
            devEvent.Delete();
            return NoContent();
        }

        [HttpPost("{id}/speakers")]
        public IActionResult PostSpeaker(Guid id, DevEventSpeaker devEventSpeaker)
        {
            var devEvent = _dbContext.DevEvents.SingleOrDefault(d => d.Id == id);
            if(devEvent == null) return NotFound();
            devEvent.Speakers.Add(devEventSpeaker);
            return NoContent();
        }


    }
}
