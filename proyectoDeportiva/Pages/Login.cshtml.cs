// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using proyectoDeportiva.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proyectoDeportiva.Data;

namespace proyectoDeportiva.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        public string ReturnUrl { get; set; }
        private readonly SignInManager<User> _signInManager;

        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public LoginModel(ApplicationDbContext dbContext, SignInManager<User> signInManager, ILogger<LoginModel> logger, Microsoft.AspNetCore.Identity.UserManager<User> userManager)
        {
            _context = dbContext;
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        //public LoginModel(ILogger<LoginModel> logger)
        //{
        //    _logger = logger;
        //}

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var login = HttpContext.Request.Form["Email"];
            var password = HttpContext.Request.Form["password"];
            string returnUrl = "/";

            Input.Password = password.FirstOrDefault();
            Input.Email = login.FirstOrDefault();

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true                

                //vamos a obligar a registrarse con un correo electrónico como usuario
                var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);

                if (usuario != null)
                {
                    //comprobar contraseña
                    var loginattempt = await _signInManager.PasswordSignInAsync(usuario, Input.Password, true,false);
                    //var result = await _signInManager.PasswordSignInAsync(Input.Usuario, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                    if (loginattempt.Succeeded)
                    {
                        await _signInManager.SignInAsync(usuario, false);

                        //await _userManager.AddClaimAsync(usuario, new Claim("idEmpresa" as String, emp.ID.ToString()));
                        //await _userManager.AddClaimAsync(usuario, new Claim("Empresa" as String, emp.Nombre.ToString()));
                        //await _userManager.AddClaimAsync(usuario, new Claim("idUsuario" as String, usuario.Id.ToString()));
                        //await _userManager.AddClaimAsync(usuario, new Claim("Usuario" as String, usuario.NombreCompleto.ToString()));
                        //await _userManager.AddClaimAsync(usuario, new Claim("idPaisEmpresa" as String, emp.idPais.ToString()));
                        //await _userManager.AddClaimAsync(usuario, new Claim("idPaisUsuario" as String, usuario.idPais.ToString()));
                        //await _userManager.AddClaimAsync(usuario, new Claim("idZonaHoraria" as String, usuario.idZonaHoraria.ToString()));

                        //HttpContext.Session.SetInt32("idEmpresa", emp.ID);
                        //HttpContext.Session.SetString("Empresa", emp.Nombre);
                        //HttpContext.Session.SetString("idUsuario", usuario.Id);
                        //HttpContext.Session.SetInt32("idPaisEmpresa", emp.idPais);


                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl); 
                    }

                    //if (loginattempt.RequiresTwoFactor)
                    //{
                    //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    //}


                    if (loginattempt.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Inicio de sesión fallido. Verifica tus credenciales.");
                    return Page();
                }

            } else
            { 

            }

            return Page();
        }


        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 

            [Required]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /*
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
            */
        }
    }
}
