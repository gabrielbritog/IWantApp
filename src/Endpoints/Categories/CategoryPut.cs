using IWantApp.Domain.Products;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.Endpoints.Categories;

public static class CategoryPut
{
    public static string Template => "/categories/{id:guid}"; //Rota
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() }; //Método de acesso(Acessar pelo método POST)
    public static Delegate Handle => Action; //Chamar a ação

    public static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        

        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
        if(category == null)
        {
            return Results.NotFound();
        }

        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;
        context.SaveChanges();

        return Results.Ok();//retornando a url e exibe o Id do que foi salvo
    }
}
