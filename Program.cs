using ECommerceBackend.Data; // Importing data-related classes and interfaces
using ECommerceBackend.Services; // Importing service-related classes and interfaces
using Microsoft.IdentityModel.Tokens; // Importing classes for handling security tokens

var builder = WebApplication.CreateBuilder(args);

// Adding services to the container.
builder.Services.AddControllers(); // Adding support for controllers
builder.Services.AddEndpointsApiExplorer(); // Adding support for endpoint exploration
builder.Services.AddSwaggerGen(); // Adding Swagger for API documentation
builder.Services.AddSingleton<ProductData>(); // Registering ProductData as a singleton service
builder.Services.AddScoped<IProductService, ProductService>(); // Registering ProductService with its interface

// Adding authentication services
builder.Services.AddAuthentication("Bearer")
.AddJwtBearer(options =>
{
    // Configuring JWT (JSON Web Token) authentication
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, // Validate the token issuer
        ValidateAudience = true, // Validate the token audience
        ValidateIssuerSigningKey = true, // Validate the token signing key
        ValidIssuer = builder.Configuration["Authentication:Issuer"], // Setting the valid issuer from configuration
        ValidAudience = builder.Configuration["Authentication:Audience"], // Setting the valid audience from configuration
        IssuerSigningKey = new SymmetricSecurityKey(
            Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]) // Setting the signing key from configuration
        )
    };
});

// Adding User Secrets configuration for development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>(); // Adding user secrets for development
}

var app = builder.Build();

// Configuring the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enabling Swagger in development environment
    app.UseSwaggerUI(); // Enabling Swagger UI in development environment
}

app.UseHttpsRedirection(); // Enforcing HTTPS for requests
app.UseAuthentication(); // Enabling authentication middleware

app.UseRouting(); // Enabling routing middleware
app.UseAuthorization(); // Enabling authorization middleware

app.UseEndpoints(endPoints =>
{
    endPoints.MapControllers(); // Mapping controller endpoints
});

app.Run(); // Running the application
