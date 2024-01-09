using IWantApp.Domain.Produtos;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categorias;

public class CategoriaGetAll
{
    public static string Template => "/categorias";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categorias = context.Categorias?.ToList();
        var response = categorias?.Select(c => new CategoriaResponse { Id = c.Id, Nome = c.Nome, Ativo = c.Ativo });      

        return Results.Ok(response);

    }
}
