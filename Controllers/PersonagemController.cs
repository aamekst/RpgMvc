using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RpgMvc.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;



namespace RpgMvc.Controllers
{
    public class PersonagemController : Controller
    {
        public string uriBase = "http://localhost:5000/Usuario/";


    [HttpGet]
    public async Task<ActionResult> IndexAsync()
    {
        try{
            string uriComplementar = "GetAll";
            HttpClient httpClient = new HttpClient();
            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar );
            string serialized = await response.Content.ReadAsStringAsync();

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<PersonagemViewModel> listaPersonagens = await Task.Run(() =>
                    JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serialized ));

                return View(listaPersonagens);

            }else
                throw new System.Exception(serialized);
        }
            

            catch(System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
        
            }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(PersonagemViewModel p)
    {

        try
        {

            HttpClient httpClient = new HttpClient();
            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(p));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uriBase, content);
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Mensagem"]= string.Format("Personagem {0}, Id {1} salvo com sucesso!", p.Nome, serialized);
                return RedirectToAction("Index");

            }else
                throw new System.Exception(serialized);
        }
            

            catch(System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Create");
        
            }
    }
 }
}
