using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RpgMvc.Models;

namespace RpgMvc.Controllers
{
    public class UsuariosController : Controller
    {
        public string uriBase = "http://localhost:5000/Usuario/";

        [HttpGet]

        public ActionResult Index()
        {
            return View("CadastrarUsuario");
        }


        [HttpPost]
        public async Task<ActionResult> RegistrarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                        TempData["Messagem"] =
                            string.Format("Usuario {0} Resgistrado com sucesso! Faça o login para acessar." , u.Username);
                        return View("AutenticarUsuario");

                }
                else
                {
                    throw new System.Exception(serialized);
                }

               
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]

        public ActionResult IndexLogin()
        {
            return View("AutenticarUsuario");


        }

    [HttpPost]
    public async Task<ActionResult> AutenticarAsync(UsuarioViewModel u)
    {
        try {
            HttpClient httpClient = new HttpClient();
                string uriComplementar = "Autenticar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                        HttpContext.Session.SetString("SessionTokenUsuario", serialized);
                        TempData["Message"] = string.Format("Bem-vindo {0}!!!", u.Username);
                        return RedirectToAction("Index", "Personagens");
                }
                else{
                    throw new System.Exception(serialized);
                }

        }
        catch(System.Exception ex)
        {
            TempData["MensagemErro"] = ex.Message;
            return IndexLogin();
        }
    }












    }
}