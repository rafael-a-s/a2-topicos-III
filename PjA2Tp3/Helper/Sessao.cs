using Newtonsoft.Json;
using PjA2Tp3.Models;
using System.Drawing;

namespace PjA2Tp3.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;   
        }

        public Usuario BuscarSessao(string nomeSessao)
        {
            string sessaoUsu = _httpContext.HttpContext.Session.GetString(nomeSessao);

            if (string.IsNullOrEmpty(sessaoUsu)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsu); 
        }

        public void CriarSessaoDaEmpresa(Empresa empresa, string nomeSessao)
        {
            string valor = JsonConvert.SerializeObject(empresa);
            _httpContext.HttpContext.Session.SetString(nomeSessao, valor);
        }

        public void CriarSessaoDoUsuario(Usuario usuario, string nomeSessao)
        {
            string valor = JsonConvert.SerializeObject(usuario);    
            _httpContext.HttpContext.Session.SetString(nomeSessao,valor);
        }

        public void CriarSessaoParaNome(string nome, string nomeSessao)
        {
            _httpContext.HttpContext.Session.SetString(nomeSessao, nome);
        }

        public void CriarSessaoPermissao(Perfil perfil, string nomeSessao)
        {
            string value = JsonConvert.SerializeObject(perfil);  
            _httpContext.HttpContext.Session.SetString(nomeSessao, value);
        }

        public void RemoverSessao(string nomeSessao)
        {
            _httpContext.HttpContext.Session.Remove(nomeSessao);
        }
    }
}
