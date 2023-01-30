using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoyalCars.Models.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Controllers
{
    [Authorize]

    public class AccountController : Controller
    {

        private UserManager<IdentityUser> userManger;
        private SignInManager<IdentityUser> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> _userManger,
            SignInManager<IdentityUser> _signInManager, RoleManager<IdentityRole> _roleManager)

        {
            roleManager = _roleManager;
            signInManager = _signInManager;
            userManger = _userManger;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegestirViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    Email = model.Email,
                    PhoneNumber = model.Mobile,
                    UserName = model.Email
                };
                var result = await userManger.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index","Home");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    string Id = userManger.GetUserId(User);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid User or Password");

                return View(model);

            }
            return View(model);

        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]

        public IActionResult RolesList()

        {
            return View(roleManager.Roles);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult CreatRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> CreatRole(CreatViewRole model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = model.RoleName };
                var result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("RolesList");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);

                }
                return View(model);
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DelateRole(String id)
        {
            if (id == null)
            {
                return RedirectToAction("RolesList");
            }
            var role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RolesList");
            }
            return RedirectToAction("RolesList");

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> EditRole(string id)
        {
            if (id == null)
            {
                return RedirectToAction("RolesList");
            }
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return RedirectToAction("RolesList");
            }
            EditRoleViewModel model = new EditRoleViewModel
            {
                RoleName = role.Name,
                RoleId = role.Id
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.RoleId);
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RolesList");

                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return View(model);

            }
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult LoginC()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginC(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    string Id = userManger.GetUserId(User);
                    return RedirectToAction("About","Home");
                }

                ModelState.AddModelError("", "Invalid User or Password");

                return View(model);

            }
            return View(model);

        }
    }
}
