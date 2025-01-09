// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ApiSystemArchiveDoc.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace ApiSystemArchiveDoc.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApiSystemArchiveDocUser> _signInManager;
        private readonly UserManager<ApiSystemArchiveDocUser> _userManager;
        private readonly IUserStore<ApiSystemArchiveDocUser> _userStore;
        private readonly IUserEmailStore<ApiSystemArchiveDocUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        

        public RegisterModel(
            UserManager<ApiSystemArchiveDocUser> userManager,
            IUserStore<ApiSystemArchiveDocUser> userStore,
            SignInManager<ApiSystemArchiveDocUser> signInManager,
            ILogger<RegisterModel> logger
            )
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
           
        }

       
        [BindProperty]
        public InputModel Input { get; set; }

        
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
           
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Required]
            [Display(Name = "Имя")]
            public string FirstName { get; set; }
            
            [Required]
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }
           
            [Display(Name = "Отчество")]
            public string Patronymic  { get; set; }
            
            [Display(Name = "Отдел")]
            public string Department  { get; set; }
            
            [Display(Name = "Роль администратора")]
            public bool IsAdministrator  { get; set; }
            
            [Display(Name = "Роль архивариус")]
            public bool IsArchiver  { get; set; }
            
            [Display(Name = "Роль контроллера")]
            public bool IsController  { get; set; }
            
            [Display(Name = "Учетная запись заблокирована")]
            public bool IsLock  { get; set; }
            
            
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);

                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                user.Department = Input.Department;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.Patronymic = Input.Patronymic;


                var result = await _userManager.CreateAsync(user, Input.Password);

                await _userManager.AddClaimAsync(user, new Claim("FirstName", Input.FirstName));
                await _userManager.AddClaimAsync(user, new Claim("LastName", Input.LastName));
                await _userManager.AddClaimAsync(user, new Claim("Department", Input.Department));
                await _userManager.AddClaimAsync(user, new Claim("Patronymic", Input.Patronymic));

                await _userManager.RemoveFromRolesAsync(user,
                    new[] { "IsAdministrator", "IsArchiver", "IsController", "isLocked" });
               if(Input.IsAdministrator)
                await _userManager.AddToRoleAsync(user,"IsAdministrator" );
               if(Input.IsArchiver)
                   await _userManager.AddToRoleAsync(user,"IsArchiver" );
               if(Input.IsController)
                   await _userManager.AddToRoleAsync(user,"IsController" );
               if(Input.IsLock)
                   await _userManager.AddToRoleAsync(user,"isLocked" );
            if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    var userId = await _userManager.GetUserIdAsync(user);
                        return LocalRedirect("/Identity/Account/Users");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApiSystemArchiveDocUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApiSystemArchiveDocUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApiSystemArchiveDocUser)}'. " +
                    $"Ensure that '{nameof(ApiSystemArchiveDocUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApiSystemArchiveDocUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApiSystemArchiveDocUser>)_userStore;
        }
    }
}
