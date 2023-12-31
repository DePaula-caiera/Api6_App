﻿using IWantApp.Domain.Produtos;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categorias;

public class CategoriaPost
{
    public static string Template => "/categorias";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoriaRequest categoriaRequest, ApplicationDbContext context)
    {
        var categoria = new Categoria
        {
            Nome = categoriaRequest.Nome,
            CreateBy = "TESTE",
            CreatedOn = DateTime.Now,
            EditedBy = "TESTE",
            EditedOn = DateTime.Now
        };
        context.Categorias?.Add(categoria);
        context.SaveChanges();

        return Results.Created($"/categorias/{categoria.Id}", categoria.Id);
    }
}
