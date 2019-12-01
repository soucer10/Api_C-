using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Service
{
    interface IPessoa
    {
      
        public void Criar(string name,int idade);
        public List<Pessoa> list();
    }
}
