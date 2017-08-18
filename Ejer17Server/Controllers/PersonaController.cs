using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ejer17Server;
using Ejer17Server.Models;
using System.Web.Http.Cors;
using Ejer17Server.Services;

namespace Ejer17Server.Controllers
{
    [EnableCors(origins:"*", headers: "*", methods:"*")]
    public class PersonaController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private IPersonaService PersonaService;
        public PersonaController(IPersonaService _PersonaService)
        {
            this.PersonaService = _PersonaService;
        }
        // GET: api/Persona
        public IQueryable<Persona> GetPersonas()
        {
            return this.PersonaService.ReadPersonas();
        }

        // GET: api/Persona/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(long id)
        {
            Persona persona = this.PersonaService.GetPersona(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Persona/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona(long id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }


            try
            {
                this.PersonaService.PutPersona(persona);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.PersonaService.GetPersona(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Persona
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            persona = this.PersonaService.Create(persona);
            
            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE: api/Persona/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(long id)
        {
            Persona persona = this.PersonaService.GetPersona(id);
            if (persona == null)
            {
                return NotFound();
            }

            this.PersonaService.Delete(persona);
            return Ok(persona);
        }

        
    }
}