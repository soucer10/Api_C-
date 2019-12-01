using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using MongoDB.Driver;
using Service;
namespace MongoDB
{
    public class PessoaMongoDB : IPessoa
    {

        private MongoDatabaseBase DataBase;
        private string DataBaseName = "DBPessoa";
        private string StringConexao = "mongodb+srv://soucer10:soucer10@cluster0-fwaym.mongodb.net/DBPessoa?retryWrites=true&w=majority";
        private IMongoCollection<Pessoa> Pessoas;
        public PessoaMongoDB() {

            var cliente = new MongoClient(StringConexao);
            DataBase = (MongoDatabaseBase)cliente.GetDatabase(DataBaseName);
            Pessoas = DataBase.GetCollection<Pessoa>(DataBaseName);
            
        } 

        public void Criar(string email,string name,int idade)
        {
            Pessoas.InsertOne(new Pessoa(email,name, idade));
        }

        public List<Pessoa> GetPessoa(string email)
        {
            
            try
            {
                var p = Pessoas.Find<Pessoa>(p => p.email == email).ToList(); ;
               return  p;
            }
            catch
            {
                return null;
            }
        
        }

        public List<Pessoa> list()
        {
            return Pessoas.Find(p => p.Nome != "").ToList();
        }


    }

   
}
