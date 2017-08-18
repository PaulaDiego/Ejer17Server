using System.Linq;

namespace Ejer17Server.Services
{
    public interface IPersonaService
    {
        Persona Create(Persona persona);
        Persona Delete(Persona persona);
        Persona GetPersona(long id);
        void PutPersona(Persona persona);
        IQueryable<Persona> ReadPersonas();
    }
}