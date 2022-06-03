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
    public class DisputasController : Controller
    {
        public string uriBase = "http://localhost:5000/Disputas/";


    [HttpGet]
    public async Task<ActionResult> IndexAsync()
    {
            try{

                HttpClient httpClient = new HttpClient();
                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string uriBuscaPersonagens = "http://localhost:5000/Personagens/GetAll";                
                HttpResponseMessage response = await httpClient.GetAsync(uriBuscaPersonagens);
                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<PersonagemViewModel> listaPersonagens = await Task.Run(() =>
                        JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serialized));

                    ViewBag.ListaAtacantes = listaPersonagens;
                    ViewBag.ListaOponentes = listaPersonagens;
                    return View();
                }
                else
                    throw new System.Exception(serialized);

              }
              catch (System.Exception ex)
              {
                  TempData["MensagemErro"] = ex.Message;
                  return RedirectToAction("Index");
              }
    }







    }
            
}

