using App.Restaurante.Models;
using App.Restaurante.UnitOfWork;
using App.Restaurante.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.Restaurante.WebMVC.Controllers
{
    public class UsuarioController : BaseController
    {
        public UsuarioController(IUnitOfWork unit) : base(unit)
        {
        }
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            return View(await _unitOfWork.Usuarios.Listar());
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Usuarios.Agregar(usuario);
                return RedirectToAction("Index");
            }
            return PartialView(usuario);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView("_Edit", await _unitOfWork.Usuarios.Obtener(id));
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Usuario usuario) 
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Usuarios.Modificar(usuario);
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", usuario);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var subgrupo = await _unitOfWork.Usuarios.Obtener(id);
            return PartialView("_Delete", subgrupo);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            if ((await _unitOfWork.Usuarios.Eliminar(id)) != 0) return RedirectToAction("Index");

            return View(await _unitOfWork.Usuarios.Obtener(id));
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View("Login", new UserViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserViewModel user)
        {
            if (ModelState.IsValid) {
                Usuario usuariovalido = await _unitOfWork.Usuarios.ValidarUsuario(user.Email, user.Password);
                if (usuariovalido == null) {
                    ModelState.AddModelError("Error", "Email o Password inválido");
                    return View("Login", user);
                }
                var usuarioRoles = await _unitOfWork.UsuarioRoles.ListarRolesporUsuario(user.Email);
                getUserClaims(usuariovalido, usuarioRoles);
                //var identity = new ClaimsIdentity(new[]
                //{
                //    new Claim(ClaimTypes.Email, usuariovalido.Email),
                //    new Claim(ClaimTypes.Name, $"{usuariovalido.Nombres} {usuariovalido.Apellidos}"),                    
                //    new Claim(ClaimTypes.NameIdentifier, usuariovalido.IdUsuario.ToString())
                //}, "ApplicationCookie");

                var identity = new ClaimsIdentity(getUserClaims(usuariovalido, usuarioRoles), "ApplicationCookie");

                var context = Request.GetOwinContext();
                var authManager = context.Authentication;

                authManager.SignIn(identity);

                return RedirectToLocal(user.ReturnUrl);
            }
            return View(user);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(Usuario usuario)
        {
            if (ModelState.IsValid) {
                var mensaje = await _unitOfWork.Usuarios.CrearUsuario(usuario);
                if (mensaje.Objeto != null) return RedirectToAction("Login");
                else {
                    ViewBag.ErrorMessage = mensaje.Mensaje;
                    return View(usuario);
                }
            }
            return View(usuario);
        }
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Login", "Usuario");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public IEnumerable<Claim> getUserClaims(Usuario usuariovalido, IEnumerable<UsuarioRol> usuarioRols) {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, usuariovalido.Email));
            claims.Add(new Claim(ClaimTypes.Name, $"{usuariovalido.Nombres} {usuariovalido.Apellidos}"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuariovalido.IdUsuario.ToString()));
            foreach (var role in usuarioRols) {
                claims.Add(new Claim(ClaimTypes.Role, role.Descripcion_Rol.ToString()));
            }
            return claims;
        }
    }
}