namespace IWantApp.Endpoints.Empregados;

public record EmpregadoRequest(string Email, string Senha, string Nome, string EmpregadosCodigo)
{
}
