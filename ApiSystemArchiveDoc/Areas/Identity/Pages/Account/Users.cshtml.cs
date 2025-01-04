// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using ApiSystemArchiveDoc.Areas.Identity.Models;
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
    public class UsersModel : PageModel
    {
   
       
      
        private readonly UserManager<ApiSystemArchiveDocUser> _userManager;
      

        public UsersModel(UserManager<ApiSystemArchiveDocUser> userManager)
        {
            _userManager = userManager;
         
        }

        
        public IList<ApiSystemArchiveDocUser> Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = _userManager.Users.ToList();
            

            // Users = await _context.Users.OrderBy(u => u.Name).ToListAsync();
            // RoleList = (await _userManager.GetRolesAsync(new AppUser()))
            //     .Select(r => r.Name).ToArray();
        }
        // public IEnumerable<string> Roles { get; set; }
        //
        // public async Task OnGetAsync(string id)
        // {
        //     Roles = _roleManager.Roles.Select(r => r.Name);
        //
        //     if (!string.IsNullOrEmpty(id))
        //     {
        //         User = await _userManager.FindByIdAsync(id);
        //     }
        //     else
        //     {
        //         User = new IdentityUser();
        //     }
        // }
        //
        // public async Task<IActionResult> OnPostAsync()
        // {
        //     if (ModelState.IsValid)
        //     {
        //         
        //         if (User.Id == null)
        //         {
        //             if((await _userManager.CreateAsync(User)).Succeeded)
        //                 return RedirectToPage("./Users");
        //         }
        //         else
        //         {
        //             if((await _userManager.UpdateAsync(User)).Succeeded)
        //                 return RedirectToPage("./Users");
        //         }
        //     }
        //
        //     Roles = _roleManager.Roles.Select(r => r.Name);
        //     return Page();
        // }
    }

    /*public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApiSystemArchiveDocUser> _signInManager;
        private readonly UserManager<ApiSystemArchiveDocUser> _userManager;
        private readonly IUserStore<ApiSystemArchiveDocUser> _userStore;
        private readonly IUserEmailStore<ApiSystemArchiveDocUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApiSystemArchiveDocUser> userManager,
            IUserStore<ApiSystemArchiveDocUser> userStore,
            SignInManager<ApiSystemArchiveDocUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
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
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
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
    }*/
}
