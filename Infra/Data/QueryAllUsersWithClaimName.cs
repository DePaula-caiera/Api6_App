using Dapper;
using IWantApp.Endpoints.Empregados;
using Microsoft.Data.SqlClient;

namespace IWantApp.Infra.Data;

public class QueryAllUsersWithClaimName
{
    private IConfiguration configuration;

    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmpregadoResponse> Execute(int page, int rows)
    {        
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);
        var query =
            @"SELECT Email, ClaimValue AS NOME  
                FROM AspNetUsers AS U
                INNER JOIN AspNetUserClaims C ON U.Id = C.UserId AND C.ClaimType = 'Nome'
                ORDER BY Email
                OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";
        return db.Query<EmpregadoResponse>(
            query,
            new { page, rows }
        );
    }
}
