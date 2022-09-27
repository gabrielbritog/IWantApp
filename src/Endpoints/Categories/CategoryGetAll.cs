using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public static class CategoryGetAll
{
    public static string Template => "/categories"; //Rota
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() }; //Método de acesso(Acessar pelo método POST)
    public static Delegate Handle => Action; //Chamar a ação

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryReponse {Id = c.Id, Name = c.Name, Active = c.Active });
        context.SaveChanges();

        return Results.Ok(response);//retornando a url e exibe o Id do que foi salvo
    }
}
