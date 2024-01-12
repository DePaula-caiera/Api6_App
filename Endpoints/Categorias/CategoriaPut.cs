using IWantApp.Domain.Produtos;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categorias;

public class CategoriaPut
{
    public static string Template => "/categorias/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, CategoriaRequest categoriaRequest, ApplicationDbContext context)
    {
        var categoria = context.Categorias?.Where(c => c.Id == id).FirstOrDefault();

        if (categoria == null)
            Results.NotFound();

        categoria.EditarInfo(categoriaRequest.Nome, categoriaRequest.Ativo);

        if (!categoria.IsValid)
            return Results.ValidationProblem(categoria.Notifications.ConvertToProblemDetails());
        

        context.SaveChanges();

        return Results.Ok();

    }
}
