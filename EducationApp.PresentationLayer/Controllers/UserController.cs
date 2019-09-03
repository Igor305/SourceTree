using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.BusinessLogicLayer.Models.User;
using Microsoft.AspNetCore.Authorization;

namespace CustomIdentityApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserManager<Users> _userManager;

        public UserController(UserManager<Users> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok("Данные внесены " + user);
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
        public async Task<IActionResult> Edit(string id)
        {
            Users user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditModel model = new EditModel { Email = user.Email };
            return Ok(model);
        }

        [Route("Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]EditModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return Ok("Изменены данные пользвателя " + user);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return Ok(model);
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<ActionResult> Delete([FromHeader]string id)
        {
            Users user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return Ok(user);
        }
        public async Task<IActionResult> ChangePassword(string id)
        {
            Users user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordModel model = new ChangePasswordModel { Email = user.Email };
            return Ok();
        }

        [Route("ChangePassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
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
            }
            return Ok(model);
        }
    }
}