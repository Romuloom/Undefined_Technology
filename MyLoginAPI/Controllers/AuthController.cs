using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyLoginAPI.Data; // Certifique-se de que o namespace esteja correto
using MyLoginAPI.Models; // Certifique-se de que o namespace esteja correto para os modelos
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher<User> _passwordHasher;

    public AuthController(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
        _passwordHasher = new PasswordHasher<User>();
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto loginDto)
    {
        try
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == loginDto.Username);

            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return Unauthorized();
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                Console.WriteLine("Senha incorreta.");
                return Unauthorized();
            }

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante o login: {ex.Message}");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class UserLoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
