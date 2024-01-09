namespace IWantApp.Domain.Produtos;

public class Categoria : Entity
{    
    public new string? Nome { get; set; }
    public bool Ativo { get; set; } = true;

}
