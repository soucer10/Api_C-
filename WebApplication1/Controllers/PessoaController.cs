using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using MongoDB;


namespace WebApplication1.Controllers
{
    [ApiController]
    
    public class PessoaController : ControllerBase
    {
        [Route("pessoa/cadastrar")]
        [HttpGet]
        public string get(string nome,int idade)
        {
            var Pessoas = new PessoaMongoDB();
            Pessoas.Criar(nome, idade);
            return "Casdastro OK";
        }

        [Route("pessoa/list")]
        [HttpGet]
        public string List()
        {
            var Pessoas = new PessoaMongoDB();
            var response=Pessoas.list();
            return JsonConvert.SerializeObject(response);
        }

        [Route("pessoa/name/{nome}")]
        [HttpGet]
        public string name(string nome)
        {
            var Pessoas = new PessoaMongoDB();
            var response = Pessoas.list();
            return JsonConvert.SerializeObject(response.Where(p=>p.Nome==nome));
        }
    }
}