using Newtonsoft.Json;
using PjA2Tp3.Models;

namespace PjA2Tp3.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor _httpContext)
        {
            _httpContext = _httpContext;   
        }

        public Usuario BuscarSessaoDoUsuario()
        {
            string sessaoUsu = _httpContext.HttpContext.Session.GetString("usuLogado");

            if (string.IsNullOrEmpty(sessaoUsu)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsu); 
        }

        public void CriarSessaoDoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);    
            _httpContext.HttpContext.Session.SetString("usuLogado",valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("usuLogado");
        }
    }
}
