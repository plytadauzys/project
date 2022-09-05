using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace back_end.Controllers;

[Route("users")]
[ApiController]
public class JwtTokenController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly Context _context;

    public JwtTokenController(IConfiguration configuration, Context context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        if (user is not { Username: { }, Password: { } }) return BadRequest("Invalid Credentials");
        var userData = await GetUser(user.Username, user.Password);
        var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
        if (userData is null) return BadRequest("Invalid credentials");
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new Claim("Id", user.Id.ToString()),
            new Claim("UserName", user.Username),
            new Claim("Password", user.Password)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            jwt.Issuer,
            jwt.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: signIn
        );
        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async Task<User?> GetUser(string username, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
    }
}