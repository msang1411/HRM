using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using HRM.Models;
using HRM.Services;
using HRM.Areas.Identity.Data;

namespace HRM.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    //[Authorize(Roles = "Admin")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<HRMUser> _signInManager;
        private readonly UserManager<HRMUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AccountService _accountService;
        private readonly DepartmentService _departmentService;
        private readonly PositionService _positionService;
        private readonly EmployeeService _employeeService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<HRMUser> userManager,
            SignInManager<HRMUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AccountService accountService,
            DepartmentService departmentService,
            PositionService positionService,
            EmployeeService employeeService,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _accountService = accountService;
            _departmentService = departmentService;
            _positionService = positionService;
            _employeeService = employeeService;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public List<Department> ListDepartments { set; get; }

        public List<Position> ListPositions { set; get; }

        public List<Employee> ListEmployees { set; get; }

        public List<IdentityRole> Roles { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Account")]
            public string Account { get; set; }

            [Required]
            [Display(Name = "Quyền")]
            public string Role { get; set; }

            [Required]
            [Display(Name = "Nhân viên")]
            public int EmployeeId { set; get; }

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
            ListDepartments = _departmentService.GetAllDepartments();
            ListPositions = _positionService.GetAllPositions();
            ListEmployees = _employeeService.GetAll();
            Roles = _roleManager.Roles.ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new HRMUser { UserName = Input.Account, Email = Input.Account+ "@gmail.com", EmailConfirmed = true, IsEnabled = true};
                var result = await _userManager.CreateAsync(user, Input.Password );
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Input.Role);
                    await CreateAccount();
                    _logger.LogInformation("User created a new account with password.");

                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    Roles = _roleManager.Roles.ToList();
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private async Task CreateAccount()
        {
            Models.Account acc = new Models.Account
            {
                Account1 = Input.Account + "@gmail.com",
                Password = Input.Password,
                EmployeeId = Input.EmployeeId,
                Role = Input.Role
            };
            await _accountService.AddAsync(acc);
        }
    }
}
