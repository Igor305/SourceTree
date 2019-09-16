using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.BusinessLogicLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using System;

namespace CustomIdentityApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateAsync(model);
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

        [Route("Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]EditModel model)
        {
            if (ModelState.IsValid)
            {
                    var result = await _userService.EditAsync(model);
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

        [Route("Delete")]
        [HttpPost]
        public async Task<ActionResult> Delete([FromBody]Guid id)
        {
            var result = await _userService.Delete(id);
            return Ok("Пользователь под номером"+id+" был удачно удалён");
        }

        [Route("ChangePassword")]
        [HttpPost]
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