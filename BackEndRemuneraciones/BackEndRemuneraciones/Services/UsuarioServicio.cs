using BackEndRemuneraciones.Models.Autenticacion.Request;
using BackEndRemuneraciones.Reponse.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemuneraciones.Models.Data;
using BackEndRemuneraciones.Helpers;
using BackEndRemuneraciones.Reponse;
using BackEndRemuneraciones.Controllers.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using BackEndRemuneraciones.Models.Autenticacion;

namespace BackEndRemuneraciones.Services
{
    public class UsuarioServicio: IUsuarioServicio
    {

        private readonly AppSettings _appSettings;
        private Models.Data.remuneracionesContext _db;

        public UsuarioServicio(IOptions<AppSettings> appSettings, Models.Data.remuneracionesContext db) 
        {
            _appSettings = appSettings.Value;
            _db = db;
        }
        public UsuarioResponse Autenticacion(AutenticacionRequest Model) 
        {
               UsuarioResponse usuarioResponse = new UsuarioResponse();
            
                string Spassword = Utiles.GetSHA256(Model.Password);

                var Usuario = _db.Usuario.Where(u => u.Email == Model.Email && u.Contrasena == Spassword).FirstOrDefault();

                if (Usuario == null) return null;

                usuarioResponse.Email = Usuario.Email;
                usuarioResponse.Token = GetToken(Usuario);
              

            return usuarioResponse;
        }


        private string GetToken(Usuario usuario) 
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email),
                        new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var Token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(Token);
        }
    }
}
