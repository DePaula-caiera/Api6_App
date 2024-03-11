using Dapper;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Security.Claims;

namespace IWantApp.Endpoints.Empregados;

public class EmpregadoGetAll
{
    public static string Template => "/empregados";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "Empregado004Policy")]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {

       
            //if (page == null || rows == null)
            //    return Results.BadRequest("Ausência de Parâmetros");

            //int.TryParse(page, out var pageId);
            //int.TryParse(rows, out var rowsId);
            //var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);
            //var query =
            //    @"SELECT Email, ClaimValue AS NOME  
            //    FROM AspNetUsers AS U
            //    INNER JOIN AspNetUserClaims C ON U.Id = C.UserId AND C.ClaimType = 'Nome'
            //    ORDER BY Email
            //    OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";
            //var empregados = db.Query<EmpregadoResponse>(
            //    query,
            //    new { pageId, rowsId }
            //);

            //if(!empregados.Any()) 
            //    return Results.NotFound();

            return Results.Ok(query.Execute(page.Value, rows.Value));        
        
    }
  
}

