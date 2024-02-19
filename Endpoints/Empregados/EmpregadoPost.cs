using IWantApp.Domain.Produtos;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IWantApp.Endpoints.Empregados;

public class EmpregadoPost
{
    public static string Template => "/empregados";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(EmpregadoRequest empregadoRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = empregadoRequest.Email, Email = empregadoRequest.Email };
        var result = userManager.CreateAsync(user, empregadoRequest.Senha).Result;

        if(!result.Succeeded)
            return Results.BadRequest(result.Errors.First());

        var claimResult =
            userManager.AddClaimAsync(user, new Claim("EmpregadosCodigo", empregadoRequest.EmpregadosCodigo)).Result;

        if(!claimResult.Succeeded)
            return Results.BadRequest(result.Errors.First());

        claimResult =
            userManager.AddClaimAsync(user, new Claim("Nome", empregadoRequest.Nome)).Result;

        if (!claimResult.Succeeded)
            return Results.BadRequest(result.Errors.First());

        return Results.Created($"/empregados/{user.Id}", user.Id);
    }
}
