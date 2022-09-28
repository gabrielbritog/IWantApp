using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }
    public Category(string name, string createdBy, string editedBy)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name", "Name is required")
        .IsNotNullOrEmpty(createdBy, "Name", "Name is required")
        .IsNotNullOrEmpty(editedBy, "Name", "Name is required");
        AddNotifications(contract);


        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditeddOn = DateTime.Now;
    }
}
