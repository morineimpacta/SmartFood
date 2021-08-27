using System.Text.Json.Serialization;

namespace TechnoSolution.Entidades
{
    public class ItemMenu
    {
        [JsonIgnore]
        public virtual int Id { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual byte[] Imagem { get; set; }

        public virtual int QuantidadePessoas { get; set; }

        public virtual long Calorias { get; set; }

        public virtual long Peso { get; set; }

        public virtual long Preco { get; set; }

        public virtual string TempoPreparo { get; set; }

        public virtual string LinkVideo { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }

        [JsonIgnore]
        public virtual bool Ativo { get; set; }
    }
}