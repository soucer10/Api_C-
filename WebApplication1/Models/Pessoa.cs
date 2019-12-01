using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pessoa
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        [Required]
        [Display(Name ="Nome")]
        public string Nome { get; private set; }

        [Required]
        [Display(Name = "Idade")]
        public int idade { get; private set; }

        [BsonDateTimeOptionsAttribute(Kind = DateTimeKind.Local)]
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            this.idade = idade;
        }

        public Pessoa() { }
    }
}
