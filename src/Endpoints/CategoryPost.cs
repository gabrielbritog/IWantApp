using IWantApp.Domain.Products;
using IWantApp.Infra.Data;

namespace IWantApp.Endpoints;

public class CategoryPost
{
    public string Template => "/categories"; //Rota
    public string[] Methods => new string[] { HttpMethod.Post.ToString() }; //Método de acesso(Acessar pelo método POST)
    public Delegate Handle => Action; //Chamar a ação

    public IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = new Category
        {
            Name = categoryRequest.Name
        };
        context.Categories.Add(category);
        context.SaveChanges();
        return Results.Created($"/categories/{category.Id}", category.Id);//retornando a url e exibe o Id do que foi salvo
    }
}
