

using System.Text.Json.Serialization;

namespace TechnoSolution.Entidades
{
    public class Estabelecimento
    {

        [JsonIgnore]
        public virtual int Id { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string NomeFantasia { get; set; }

        public virtual string Login { get; set; }

        public virtual string Email { get; set; }

        public virtual string Senha { get; set; }

        [JsonIgnore]
        public virtual string ExpiracaoSenha { get; set; }

        public virtual long CNPJ { get; set; }

        public virtual string NomeContato { get; set; }
        public virtual long NumeroCelular { get; set; }
    }
}