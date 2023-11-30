using seed_desafio_cdc.API;

namespace seed_desafio_cdc.IntegrationTest.Controllers;

public class AuthorControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory;   
    private readonly AuthorInput authorInput = new AuthorInput("Robson Calixto", "created a new author", "robson@test.com");
                                            
    public AuthorControllerTest(WebApplicationFactory<Program> factory)
    {
        this.factory = factory;
    }

    [Trait("Integration","AuthorControllerTest")]
    [Fact(DisplayName = "Should create a new author")]   
    public async Task Post_ShouldCreateAuthor_Return200Ok()
    {
        var authorInput = new AuthorInput("Robson Calixto","created a new author", "teste@teste.com");

        var client = factory.CreateClient();
        var response = await client.PostAsJsonAsync("/author", authorInput);
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);  

        var author = await response.Content.ReadFromJsonAsync<API.Author>();
        author.Should().NotBeNull();
        author!.Id.Should().BeGreaterThan(0);
        author.Name.Should().Be(authorInput.name);
        author.Description.Should().Be(authorInput.description);
        author.Email.Should().Be(authorInput.emailAddress);
    }

    [Trait("Integration","AuthorControllerTest")]
    [Fact(DisplayName = "Should not create a new author with email already exists")] 
    public async Task Post_ShouldNotCreateANewAuthorIfEmailAlready_Return400BadRequest()
    {
        var client = factory.CreateClient();
        
        await client.PostAsJsonAsync("/author", authorInput);
        var response = await client.PostAsJsonAsync("/author", authorInput);
        
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);         
    }

    [Trait("Integration","AuthorControllerTest")]
    [Fact(DisplayName = "Should not create a new author empty")]
    public async Task Post_ShouldNotCreateANewAuthorIfNameEmpty_Return400BadRequest()
    {
        var client = factory.CreateClient();
        var authorInput = new AuthorInput("","","");

        var response = await client.PostAsJsonAsync("/author", authorInput);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

        var validationProblems = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
        validationProblems!.Errors.Should().ContainKey("name");
        validationProblems.Errors["name"].Should().Contain("The name field is required.");
        validationProblems!.Errors.Should().ContainKey("description");
        validationProblems.Errors["description"].Should().Contain("The description field is required.");
        validationProblems!.Errors.Should().ContainKey("emailAddress");
        validationProblems.Errors["emailAddress"].Should().Contain("Email is required.");
    }
}
