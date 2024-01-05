namespace IWantApp.Domain.Produtos;

public class Categoria : Entity
{    
    public string? Nome { get; set; }
    public bool Active { get; set; } = true;

}
