using System.IdentityModel.Tokens.Jwt; // Library for handling JSON Web Tokens (JWT)
using System.Security.Claims; // Library for handling user claims
using Microsoft.AspNetCore.Mvc; // Library for handling HTTP requests in an ASP.NET Core MVC application
using Microsoft.IdentityModel.Tokens; // Library for handling security tokens

namespace ECommerceBackend
{
    // This controller handles authentication requests
    [Route("api/authentication")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly IConfiguration _configuration;

        // Constructor to get configuration settings (like secret keys)
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This class represents the data we expect to receive in the authentication request
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; } // The username provided by the user
            public string? Password { get; set; } // The password provided by the user
        }

        // This class represents a user in our system
        private class User
        {
            public int UserId { get; set; } // The user's unique ID
            public string UserName { get; set; } // The user's username
            public string FirstName { get; set; } // The user's first name
            public string LastName { get; set; } // The user's last name

            // Constructor to initialize a User object
            public User(int userId, string userName, string firstName, string lastName)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
            }
        }

        // This method handles the POST request to authenticate a user
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            // Validate the user's credentials (username and password)
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password
            );

            // If the user's credentials are invalid, return an Unauthorized response
            if (user == null)
            {
                return Unauthorized();
            }

            // Convert the secret key from a Base64 string to a byte array
            var secretKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Authentication:SecretForKey"])
            );

            // Create signing credentials using the secret key and the HMAC SHA-256 algorithm
            var signingCredentials = new SigningCredentials(
                secretKey, SecurityAlgorithms.HmacSha256
            );
            
            // Create a list of claims for the user (these are like attributes about the user)
            List<Claim> claimsForToken = new List<Claim>
            {
                new Claim("sub", user.UserId.ToString()), // Subject claim (user ID)
                new Claim("given_name", user.FirstName), // Given name claim (first name)
                new Claim("family_name", user.LastName) // Family name claim (last name)
            };

            // Create the JWT token
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"], // The issuer of the token
                _configuration["Authentication:Audience"], // The audience of the token
                claimsForToken, // The claims for the token
                expires: DateTime.UtcNow.AddHours(1), // The token's expiration time (1 hour from now)
                signingCredentials: signingCredentials // The signing credentials
            );

            // Write the token to a string
            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            // Return the token in the response
            return Ok(new { Token = tokenToReturn });
        }

        // This method validates the user's credentials (for now, it just checks against a hardcoded user)
        private User? ValidateUserCredentials(string? userName, string? password)
        {
            // Check if the provided username and password match our hardcoded user
            if (userName == "testuser" && password == "testpassword")
            {
                return new User(1, "testuser", "Test", "User"); // Return a User object if the credentials are valid
            }

            return null; // Return null if the credentials are invalid
        }
    }
}
