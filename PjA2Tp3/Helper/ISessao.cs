using PjA2Tp3.Models;

namespace PjA2Tp3.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario, string nomeSessao);

        void CriarSessaoNomeUsuario(string nome, string nomeSessao);

        void RemoverSessaoDoUsuario(string nomeSessao);

        Usuario BuscarSessaoDoUsuario(string nomeSessao);
    }
}
