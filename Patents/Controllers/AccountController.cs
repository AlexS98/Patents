using Microsoft.Owin.Security;
using Patents.Models;
using Patents.Models.Entities;
using Patents.Models.Repositories;
using Patents.Models.ViewModels;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Patents.Controllers
{
    public class AccountController : Controller
    {
        EFDBContext db = new EFDBContext();
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Person user = null;
                Role role = null;
                if (!model.Manager) user = await db.Inventors.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
                else
                {
                    Register register = await db.Registers.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
                    if (register != null)
                    {
                        role = await db.Roles.FirstOrDefaultAsync(u => u.RoleId == register.RoleId); 
                        user = register as Person;
                    }
                }

                if (user == null)
                {
                    ModelState.AddModelError("", "Wrong login or password.");
                }
                else
                {
                    ClaimsIdentity claim = new ClaimsIdentity("ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.GetPersonId().ToString(), ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
                    claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                        "OWIN Provider", ClaimValueTypes.String));
                    claim.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, (role != null) ? role.UserRole : "Registred user", ClaimValueTypes.String));


                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerModel)
        {
            InventorsRepository inventors = new InventorsRepository();
            inventors.AddInventor(registerModel.ToInventor());
            //LoginModel model = new LoginModel
            //{
            //    Manager = false,
            //    Name = registerModel.FullName,
            //    Password = registerModel.Password
            //};
            //await Login(model);//redirect to login(post)
            return RedirectToAction("Login", "Account");
        }
    } 
}