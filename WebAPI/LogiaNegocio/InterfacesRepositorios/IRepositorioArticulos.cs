using LogiaNegocio.Dominio;

namespace LogiaNegocio.InterfacesRepositorios
{
    public interface IRepositorioArticulos 
    {
        IEnumerable<Articulo> FindAll();
        Articulo FindById(int id);
    }
}