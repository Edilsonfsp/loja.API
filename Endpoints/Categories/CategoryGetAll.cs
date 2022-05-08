using loja.API.Domain.Products;
using loja.API.Infra.Data;

namespace loja.API.Endpoints.Categories;

public class CategoryGetAll
{
	public static string Template => "/categories";
	public static string[] Methods => new string[] { HttpMethods.Get.ToString()};
	public static Delegate Handle => Action;
	public static IResult Action(ApplicationDbContext context)
	{
		var categories = context.Categories.ToList();
		var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active });
		context.SaveChanges();

		return Results.Ok(response);
	}
}
