namespace IWantApp.Domain.Produtos;

public class Produto : Entity
{  
    public new string? Nome { get; set; }
    public Guid CategoriaId { get; set; }
    public Categoria? Categoria { get;}
    public string? Descricao { get; set; }
    public bool HasEstoque { get; set; }
    public bool Ativo { get; set; } = true;
}
