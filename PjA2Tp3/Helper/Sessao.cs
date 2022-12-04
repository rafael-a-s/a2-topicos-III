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

        public Usuario BuscarSessaoDoUsuario(string nomeSessao)
        {
            string sessaoUsu = _httpContext.HttpContext.Session.GetString(nomeSessao);

            if (string.IsNullOrEmpty(sessaoUsu)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsu); 
        }

        public void CriarSessaoDoUsuario(Usuario usuario, string nomeSessao)
        {
            string valor = JsonConvert.SerializeObject(usuario);    
            _httpContext.HttpContext.Session.SetString(nomeSessao,valor);
        }

        public void CriarSessaoNomeUsuario(string nome, string nomeSessao)
        {
            _httpContext.HttpContext.Session.SetString(nomeSessao, nome);
        }

        public void RemoverSessaoDoUsuario(string nomeSessao)
        {
            _httpContext.HttpContext.Session.Remove(nomeSessao);
        }
    }
}
