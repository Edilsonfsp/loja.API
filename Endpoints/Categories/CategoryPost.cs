using loja.API.Domain.Products;
using loja.API.Infra.Data;

namespace loja.API.Endpoints.Categories;

public class CategoryPost
{
	public static string Template => "/categories";
	public static string[] Methods => new string[] { HttpMethods.Post.ToString()};
	public static Delegate Handle => Action;
	public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
	{
		var category = new Category(categoryRequest.Name, "Test", "Test");
		

		if(!category.IsValid)
			return Results.BadRequest(category.Notifications);
		context.Categories.Add(category);
		context.SaveChanges();

		return Results.Created($"Template/{category.Id}", category.Id);
	}
}
