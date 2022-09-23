using IWantApp.Infra.Data;

namespace IWantApp.Endpoints;

public class CategoryPost
{
    public string Template => "/categories"; //Rota
    public string[] Methods => new string[] { HttpMethod.Post.ToString() }; //Método de acesso(Acessar pelo método POST)
    public Delegate Handle => Action; //Chamar a ação

    public IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        return Results.Ok("Ok");
    }
}
