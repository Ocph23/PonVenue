using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using PonVenue.Models;

namespace PonVenue.Data
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        private readonly UserManager<IdentityUser> _usermanagar;

        public UserService(IOptions<AppSettings> appSettings,
            UserManager<IdentityUser> userManagar,
            ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
            _appSettings = appSettings.Value;
            _usermanagar = userManagar;
        }

        public async Task<AuthenticateResponse> Authenticate(UserLogin model)
        {
            try
            {
                var user = await _usermanagar.FindByNameAsync(model.UserName.ToUpper());
                if (user != null && await _usermanagar.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await _usermanagar.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthorizationConstants.JWT_SECRET_KEY));

                    var token = new JwtSecurityToken(
                        expires: DateTime.Now.AddDays(7),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );
                    return new AuthenticateResponse(user, userRoles, new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);

                }
                throw new UnauthorizedAccessException();
            }
            catch (System.Exception ex)
            {
                throw new UnauthorizedAccessException(ex.Message);
            }
        }


        //public async Task<AuthenticateResponse> Register(RegistrasiPerusahaan model)
        //{
        //    var trans = _context.Database.BeginTransaction();
        //    try
        //    {
        //        var user = new IdentityUser {UserName=model.Email, Email = model.Email, EmailConfirmed = true };
        //        var userResult = await _usermanagar.CreateAsync(user, model.Password);
        //        if (userResult.Succeeded)
        //        {
        //            var roleResult = await _usermanagar.AddToRoleAsync(user, "Umat");
        //            if (roleResult.Succeeded)
        //            {
        //                var umat = model as Perusahaan;
        //                umat.UserId = user.Id;
        //                _context.Perusahaans.Add(umat);
        //                await _context.SaveChangesAsync();

        //                var userRoles = await _usermanagar.GetRolesAsync(user);

        //                var authClaims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, user.UserName),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            };

        //                foreach (var userRole in userRoles)
        //                {
        //                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //                }

        //                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthorizationConstants.JWT_SECRET_KEY));

        //                var token = new JwtSecurityToken(
        //                    expires: DateTime.Now.AddDays(7),
        //                    claims: authClaims,
        //                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //                    );


        //                await trans.CommitAsync();
        //                return new AuthenticateResponse(user, userRoles, new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
        //            }
        //        }

        //        throw new SystemException("User tidak berhasil dibuat !");

        //    }
        //    catch (Exception ex)
        //    {
        //        await trans.RollbackAsync();
        //        throw new SystemException(ex.Message);
        //    }
        //}


        //internal async Task<Perusahaan> GetProfile(string username)
        //{
        //    try
        //    {
        //        var user = await _usermanagar.FindByNameAsync(username.ToUpper());
        //        if (user == null)
        //            throw new UnauthorizedAccessException("Anda Tidak Memiliki Akses");

        //        var umat = _context.Perusahaans.SingleOrDefault(x => x.UserId == user.Id);
        //        if (umat == null)
        //            throw new UnauthorizedAccessException("Anda Tidak Memiliki Profile");

        //        return umat;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new SystemException(ex.Message);
        //    }
        //}
    }
}