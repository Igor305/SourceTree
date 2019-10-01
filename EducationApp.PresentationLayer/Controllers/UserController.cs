using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.BusinessLogicLayer.Models.User;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CustomIdentityApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly UserManager<Users> _userManager;
            public UserController(IUserService userService, RoleManager<IdentityRole> roleManager, UserManager<Users> userManager)
        {
            _roleManager = roleManager;
            _userService = userService;
            _userManager = userManager;
        }
        [HttpGet("GetAll")]
        public IActionResult UserList() => Ok(_userManager.Users.ToList());
        public async Task<IActionResult> Edit(Guid userId)
        {
            // получаем пользователя
            Users user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id.ToString(),
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                  //  AllRoles = allRoles
                };
                return Ok(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            Users user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(model);
                if (result.Succeeded)
                {
                    return Ok("Данные внесены ");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Ok(model);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody]EditModel model)
        {
            if (ModelState.IsValid)
            {
                    var result = await _userService.Update(model);
                    if (result.Succeeded)
                    {
                        return Ok("Изменены данные пользвателя ");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            return Ok(model);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody]DeleteModel model)
        {
            await _userService.Delete(model);
            return Ok("Пользователь под номером "+model.id+" был удачно удалён");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ChangePassword(model);
                if (result.Succeeded)
                {
                    return Ok("Вы поменяли свой пароль");
                }
                else
                {
                    // return Ok(result);
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Пользователь не найден");
            }
            return Ok(model);
        }
    }
}