using PjA2Tp3.Models;

namespace PjA2Tp3.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario, string nomeSessao);

        void CriarSessaoDaEmpresa(Empresa empresa, string nomeSessao);

        void CriarSessaoParaNome(string nome, string nomeSessao);

        void CriarSessaoPermissao(Perfil perfil, string nomeSessao);

        void RemoverSessao(string nomeSessao);

        Usuario BuscarSessao(string nomeSessao);
    }
}
