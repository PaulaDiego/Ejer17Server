using System.Linq;

namespace Ejer17Server.Repository
{
    public interface IPersonaRepository
    {
        Persona Create(Persona _entrada);
        Persona Delete(Persona persona);
        void PutEntrada(Persona persona);
        Persona Read(long id);
        IQueryable<Persona> ReadPersonas();
    }
}