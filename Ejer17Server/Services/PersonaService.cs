using Ejer17Server.Models;
using Ejer17Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejer17Server.Services
{
    public class PersonaService : IPersonaService
    {
        private IPersonaRepository personaRepository;
        public PersonaService(IPersonaRepository _personaRepository)
        {
            this.personaRepository = _personaRepository;
        }
        public Persona Create(Persona persona)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        persona = personaRepository.Create(persona);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return persona;
            }
        }

        public IQueryable<Persona> ReadPersonas()
        {
            using (var context = new ApplicationDbContext())
            {
                IQueryable<Persona> personas;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        personas = personaRepository.ReadPersonas();
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return personas;
            }
        }

        public Persona GetPersona(long id)
        {
            using (var context = new ApplicationDbContext())
            {
                Persona persona;
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        persona = personaRepository.Read(id);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
                return persona;
            }
        }

        public void PutPersona(Persona persona)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        personaRepository.PutEntrada(persona);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
        }

        public Persona Delete(Persona persona)
        {
            Persona resultado;
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        resultado = personaRepository.Delete(persona);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", ex);
                    }

                }
            }
            return resultado;
        }
    }
}