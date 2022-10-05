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
        /*if (string.IsNullOrEmpty(categoryRequest.Name))        Essa validação não é boa quando se precisa validar muitas propriedades, validação feita no Entity usando FLunt
        {
            return Results.BadRequest("Name is required");
        }*/

        var category = new Category(categoryRequest.Name, "Test", "Test");

        if (!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        }

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);//retornando a url e exibe o Id do que foi salvo
    }
}
