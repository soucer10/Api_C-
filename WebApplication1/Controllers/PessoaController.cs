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

        private PessoaMongoDB Pessoas = new PessoaMongoDB();

        [Route("pessoa/cadastrar")]
        [HttpGet]
        public string get(string email,string nome,int idade)
        {
            var p = Pessoas.GetPessoa(email);
            if (p.Count >=1)
            {
                return "Usuário já está adastrado";
            }
            Pessoas.Criar(email,nome, idade);
            return "Casdastro OK";
        }

        [Route("pessoa/list")]
        [HttpGet]
        public string List()
        {
            var response=Pessoas.list();
            return JsonConvert.SerializeObject(response);
        }

        [Route("pessoa/name/{email}")]
        [HttpGet]
        public string name(string email)
        {
            var response = Pessoas.GetPessoa(email);
            return JsonConvert.SerializeObject(response);
        }
    }
}