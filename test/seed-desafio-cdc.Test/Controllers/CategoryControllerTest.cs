using seed_desafio_cdc.API;

namespace seed_desafio_cdc.IntegrationTest.Controllers;

public class CategoryControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory;
    public CategoryControllerTest(WebApplicationFactory<Program> factory)
    {
        this.factory = factory;
    }

    [Trait("Integration","CategoryControllerTest")]
    [Fact(DisplayName = "Should create a new category")]
    public async Task Post_ShouldCreateCategory_Return200Ok()
    {
        var categoryInput = new CategoryInput("Category 1");

        var client = factory.CreateClient();
        var response = await client.PostAsJsonAsync("/category", categoryInput);

        var category =  await response.Content.ReadFromJsonAsync<API.Category>();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        category.Should().NotBeNull();
        category!.Id.Should().BeGreaterThan(0);
        category.Name.Should().Be(categoryInput.name);
    }

    [Trait("Integration","CategoryControllerTest")]
    [Fact(DisplayName = "Should not create a new category with name already exists")]
    public async Task Post_ShouldNotCreateANewCategoryIfNameAlready_Return400BadRequest()
    {
        var client = factory.CreateClient();
        var categoryInput = new CategoryInput("Category 2");

        await client.PostAsJsonAsync("/category", categoryInput);
        var response = await client.PostAsJsonAsync("/category", categoryInput);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Trait("Integration","CategoryControllerTest")]
    [Fact(DisplayName = "Should not create a new category with name empty")]
    public async Task Post_ShouldNotCreateANewCategoryIfNameEmpty_Return400BadRequest()
    {
        var client = factory.CreateClient();
        var categoryInput = new CategoryInput("");

        var response = await client.PostAsJsonAsync("/category", categoryInput);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

        var validationProblems = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        validationProblems!.Errors.Should().ContainKey("name");
        validationProblems.Errors["name"].Should().Contain("The name field is required.");
    }

}
