using PjA2Tp3.Models;

namespace PjA2Tp3.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);

        void RemoverSessaoDoUsuario();

        Usuario BuscarSessaoDoUsuario();
    }
}
