using IWantApp.Endpoints.Categorias;
using IWantApp.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:IWantDb"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(CategoriaPost.Template, CategoriaPost.Methods, CategoriaPost.Handle);
app.MapMethods(CategoriaGetAll.Template, CategoriaGetAll.Methods, CategoriaGetAll.Handle);
app.MapMethods(CategoriaPut.Template, CategoriaPut.Methods, CategoriaPut.Handle);

app.Run();