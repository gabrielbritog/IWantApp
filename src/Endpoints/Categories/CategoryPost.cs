using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints.Categories;

public static class CategoryPost
{
    public static string Template => "/categories"; //Rota
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() }; //Método de acesso(Acessar pelo método POST)
    public static Delegate Handle => Action; //Chamar a ação

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category
        {
            Name = categoryRequest.Name,
            CreatedBy = "Test",
            CreatedOn = DateTime.Now,
            EditedBy = "Test",
            EditeddOn = DateTime.Now,

        };
        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);//retornando a url e exibe o Id do que foi salvo
    }
}
