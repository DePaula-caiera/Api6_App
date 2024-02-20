using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IWantApp.Endpoints.Empregados;

public class EmpregadoGetAll
{
    public static string Template => "/empregados";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int page, int rows, UserManager<IdentityUser> userManager)
    {
        var usuarios = userManager.Users.Skip((page - 1) * rows).Take(rows).ToList();
        var empregados = new List<EmpregadoResponse>();
        foreach (var item in usuarios)
        {
            var claims = userManager.GetClaimsAsync(item).Result;
            var claimName = claims.FirstOrDefault(c => c.Type == "Nome");
            var nomeUsuario = claimName != null ? claimName.Value : string.Empty;
            empregados.Add(new EmpregadoResponse(item.Email, nomeUsuario));
        }
        return Results.Ok(empregados);
    }
}
