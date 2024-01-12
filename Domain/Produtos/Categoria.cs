using Flunt.Validations;
using System.Diagnostics.Contracts;

namespace IWantApp.Domain.Produtos;

public class Categoria : Entity
{
    public new string? Nome { get; set; }
    public bool Ativo { get; private set; }

    public Categoria(string nome, string createdBy, string editedBy)
    {
        Nome = nome;
        Ativo = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();

    }

    private void Validate()
    {
        var contrato = new Contract<Categoria>()
            .IsNotNullOrEmpty(Nome, "Nome")
            .IsGreaterOrEqualsThan(Nome, 3, "Nome")
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
            .IsNotNullOrEmpty(EditedBy, "EditedBy");
        AddNotifications(contrato);
    }

    public void EditarInfo(string nome, bool ativo)
    {
        Ativo = ativo;
        Nome = nome;

        Validate();
    }
}

