

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using ApiSystemArchiveDoc.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;

namespace ApiSystemArchiveDoc.Areas.Identity.Pages.Account
{
    public class EditUserModel : PageModel
    {
        private readonly UserManager<ApiSystemArchiveDocUser> _userManager;
        private readonly IUserStore<ApiSystemArchiveDocUser> _userStore;
        private readonly IUserEmailStore<ApiSystemArchiveDocUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        

        public EditUserModel(
            UserManager<ApiSystemArchiveDocUser> userManager,
            IUserStore<ApiSystemArchiveDocUser> userStore,
            ILogger<RegisterModel> logger
            )
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
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
            public string Id { get; set; }
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
           
        }


        public async Task OnGetAsync(string Id, string returnUrl = null)
        {
            var usr = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Id);
            Input = new InputModel()
            {
                Id = usr.Id,
                FirstName = usr.FirstName,
                LastName = usr.LastName,
                Patronymic = usr.Patronymic,
                Department = usr.Department,
                IsAdministrator = await _userManager.IsInRoleAsync(usr, "IsAdministrator"),
                IsLock = await _userManager.IsInRoleAsync(usr, "isLocked"),
                IsController = await _userManager.IsInRoleAsync(usr, "isController"),
                IsArchiver = await _userManager.IsInRoleAsync(usr, "isArchiver"),
                Email = usr.Email,

            };
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
           
          
                if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Input.Id);
                        await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                        user.Department = Input.Department;
                        user.FirstName = Input.FirstName;
                        user.LastName = Input.LastName;
                        user.Patronymic = Input.Patronymic;

                        var claims = await _userManager.GetClaimsAsync(user);

                        await _userManager.RemoveClaimsAsync(user, claims);
                        await _userManager.AddClaimsAsync(user, new []
                        {
                            new Claim("FirstName", Input.FirstName),
                            new Claim("LastName", Input.LastName),
                            new Claim("Department", Input.Department),
                            new Claim("Patronymic", Input.Patronymic)
                        });
                        

                        await _userManager.RemoveFromRolesAsync(user,
                            new[] { "IsAdministrator", "IsArchiver", "IsController", "isLocked" });
                        if (Input.IsAdministrator)
                            await _userManager.AddToRoleAsync(user, "IsAdministrator");
                        if (Input.IsArchiver)
                            await _userManager.AddToRoleAsync(user, "IsArchiver");
                        if (Input.IsController)
                            await _userManager.AddToRoleAsync(user, "IsController");
                        if (Input.IsLock)
                            await _userManager.AddToRoleAsync(user, "isLocked");

                        var result = await _userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            scope.Complete();
                            _logger.LogInformation("User updated");
                            var userId = await _userManager.GetUserIdAsync(user);
                            return LocalRedirect("/Identity/Account/Users");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    catch(Exception e)
                    {
                        return Page();
                    }
                }
            }
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
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApiSystemArchiveDocUser)}'.");
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
