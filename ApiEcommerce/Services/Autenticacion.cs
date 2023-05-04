using ApiEcommerce.ModelsHelpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UpgradeERP.Models.Personas;

namespace ApiEcommerce.Services
{

    public interface IAutenticacion
    {
        Task<string> GenerarToken(Cliente cliente);
        Task<string> ValidacionToken(ClaimsIdentity identity);
    }

    public class Autenticacion : IAutenticacion
    {
        private readonly IConfiguration config;
        private readonly IClientesServices clientesServices;
        public Autenticacion(IClientesServices clientesServices, IConfiguration config)
        {
            this.clientesServices = clientesServices;
            this.config = config;
        }


        public async Task<string> GenerarToken(Cliente cliente)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwttoken = config.GetSection("Jwt").Get<Jwt>();
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, jwttoken.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("identificador", cliente._id),
                new Claim("correo", cliente.Persona.Email),
                new Claim("nombre", cliente.Persona.Nombre)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwttoken.Key));
                var singin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    jwttoken.Issuer,
                    jwttoken.Audience,
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: singin
                    );



                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                return "te weveaste";

                throw ex;
            }
        }

        public async Task<string> ValidacionToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return "Te weveaste 2";
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == "identificador").Value;
                Cliente cliente = await clientesServices.GetClienteId(id);
                if (cliente != null)
                {
                    return "200";
                }
                else
                {
                    return "te weveaste 4";
                }

            }
            catch (Exception ex)
            {
                return "Te weveaste 5";
                throw ex;
            }
        }



    }
}
