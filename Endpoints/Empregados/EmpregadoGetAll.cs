using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace IWantApp.Endpoints.Empregados;

public class EmpregadoGetAll
{
    public static string Template => "/empregados";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int? page, int? rows, IConfiguration configuration)
    {
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);
        var query =
            @"SELECT Email, ClaimValue AS NOME  
            FROM AspNetUsers AS U
            INNER JOIN AspNetUserClaims C ON U.Id = C.UserId AND C.ClaimType = 'Nome'
            ORDER BY Email
            OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";
        var empregados = db.Query<EmpregadoResponse>(
            query,
            new { page, rows }
        );

        return Results.Ok(empregados);
        
    }
}
