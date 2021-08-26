

using System;
using System.Text.Json.Serialization;

namespace TechnoSolution.Dominio
{
    public class Usuario
    {

        [JsonIgnore]
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }

        public virtual string Login { get; set; }

        public virtual string Email { get; set; }

        public virtual string Senha { get; set; }

        [JsonIgnore]
        public virtual string ExpiracaoSenha { get; set; }

        public virtual long CPF { get; set; }
        public virtual long NumeroCelular { get; set; }
        public virtual DateTime DataNascimento { get; set; }
    }
}