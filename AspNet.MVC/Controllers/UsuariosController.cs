using AspNet.MVC.DAO.Cadastros;
using AspNet.MVC.Models.Cadastros;
using System.Web.Mvc;

namespace CrudMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioDAO _usuarioDAO = new UsuarioDAO(); 

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = _usuarioDAO.ObterTodosUsuarios();
            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            var usuario = _usuarioDAO.ObterUsuarioPorId(id);
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                _usuarioDAO.CriarUsuario(usuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = _usuarioDAO.ObterUsuarioPorId(id);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                _usuarioDAO.EditarUsuario(usuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            var usuario = _usuarioDAO.ObterUsuarioPorId(id);
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuario usuario)
        {
            try
            {
                _usuarioDAO.ExcluirUsuario(usuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
