using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.DTOs;
using kolokwium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly EventsDbContext _context;
        public ArtistsController(EventsDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}")]
        public IActionResult GetArtist([FromRoute] int id)
        {
            var artist = _context.Artist.Where(a => a.IdArtist == id)
                                        .Include(a => a.ArtistEvent)
                                        .ThenInclude(ae => ae.Event)
                                        .FirstOrDefault();

            if (artist == null)
            {
                return NotFound();
            }

            var events = new List<Event>();
            foreach (var ae in artist.ArtistEvent)
            {
                events.Add(ae.Event);
            }
            events = events.OrderByDescending(e => e.StartDate).ToList();


            var response = new ArtistResponse();
            response.IdArtist = artist.IdArtist;
            response.Nickname = artist.Nickname;

            var eventsResp = new List<EventResponse>();
            foreach (var e in events)
            {
                var er = new EventResponse();
                er.IdEvent = e.IdEvent;
                er.Name = e.Name;
                er.StartDate = e.StartDate;
                er.EndDate = e.EndDate;

                eventsResp.Add(er);

            }
            response.Events = eventsResp;

            return Ok(response);
        }


        [HttpGet("{idArtist:int}/events/{idEvent:int}")]
        public IActionResult UpdateArtistEvent([FromRoute] int idArtist, [FromRoute] int idEvent, [FromBody] ArtistEvent request)
        {
            var artistEvent = _context.ArtistEvent
                .Where(ae => ae.IdArtist == idArtist)
                .Where(ae => ae.IdEvent== idEvent)
                .Include(ae => ae.Event)
                .FirstOrDefault();

            if (artistEvent == null)
            {
                return NotFound();
            }

            if (artistEvent.Event.StartDate > DateTime.Now)
            {
                return BadRequest($"event (id: {idEvent}) already started ");
            }

            if (request.PerformanceDate > artistEvent.Event.EndDate || request.PerformanceDate < artistEvent.Event.StartDate)
            {
                // TODO detailed error msg
                return BadRequest("new performanceDate must be set within event startTime and endTime limits");
            }

            artistEvent.PerformanceDate = request.PerformanceDate;
            _context.Update(artistEvent);
            _context.SaveChanges();

            return Ok(artistEvent);
        }
    }
}