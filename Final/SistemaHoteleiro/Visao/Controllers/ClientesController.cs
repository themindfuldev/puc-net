using System.Web.Mvc;
using Modelo.Dominio;

namespace Visao.Controllers
{ 
    public class ClientesController : Controller
    {
        //
        // GET: /Clientes/

        public ViewResult Index()
        {
            ViewBag.Title = "Clientes";
            ViewBag.Message = "Visualizar todos os clientes.";

            var servicoCliente = new ServicoCliente.ServicoClienteClient();
            return View(servicoCliente.ObterClientes());
        }

        //
        // GET: /Clientes/Details/5

        public ViewResult Details(long id)
        {
            ViewBag.Title = "Clientes";
            ViewBag.Message = "Detalhar cliente.";

            var servicoCliente = new ServicoCliente.ServicoClienteClient();
            return View(servicoCliente.ObterCliente(id));
        }

        //
        // GET: /Clientes/Create

        public ActionResult Create()
        {
            ViewBag.Title = "Clientes";
            ViewBag.Message = "Cadastrar cliente.";

            return View();
        } 

        //
        // POST: /Clientes/Create

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var servicoCliente = new ServicoCliente.ServicoClienteClient();
                servicoCliente.CadastrarCliente(cliente);
                return RedirectToAction("Index");  
            }

            return View(cliente);
        }
        
        //
        // GET: /Clientes/Edit/5
 
        public ActionResult Edit(long id)
        {
            ViewBag.Title = "Clientes";
            ViewBag.Message = "Alterar cliente.";

            var servicoCliente = new ServicoCliente.ServicoClienteClient();
            return View(servicoCliente.ObterCliente(id));
        }

        //
        // POST: /Clientes/Edit/5

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var servicoCliente = new ServicoCliente.ServicoClienteClient();
                servicoCliente.AlterarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Clientes/Delete/5
 
        public ActionResult Delete(long id)
        {
            ViewBag.Title = "Clientes";
            ViewBag.Message = "Excluir cliente.";

            var servicoCliente = new ServicoCliente.ServicoClienteClient();
            return View(servicoCliente.ObterCliente(id));
        }

        //
        // POST: /Clientes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            var servicoCliente = new ServicoCliente.ServicoClienteClient();
            var cliente = servicoCliente.ObterCliente(id);
            servicoCliente.ExcluirCliente(cliente);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}