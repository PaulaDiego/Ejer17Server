using Ejer17Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ejer17Server.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        public Persona Create(Persona _entrada)
        {

            return ApplicationDbContext.applicationDbContext.Personas.Add(_entrada);
        }

        public IQueryable<Persona> ReadPersonas()
        {
            IList<Persona> lista = new List<Persona>(ApplicationDbContext.applicationDbContext.Personas);
            return lista.AsQueryable();
        }

        public Persona Read(long id)
        {

            return ApplicationDbContext.applicationDbContext.Personas.Find(id);
        }

        public Persona Delete(Persona persona)
        {

            return ApplicationDbContext.applicationDbContext.Personas.Remove(persona);

        }

        public void PutEntrada(Persona persona)
        {

            ApplicationDbContext.applicationDbContext.Entry(persona).State = EntityState.Modified;

        }
    }
}