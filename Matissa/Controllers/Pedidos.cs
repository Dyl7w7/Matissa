using Matissa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matissa.Controllers
{
    public class Pedidos : Controller
    {
        private readonly dbMatissaNETContext _context;
        public Pedidos(dbMatissaNETContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            IEnumerable<Pedido> listPedidos = _context.Pedidos;
            return View(listPedidos);
        }

        // HTTP GET Detalles
        public ActionResult Details(int? id)
        {
            if (id == null || _context.DetallePedidos == null)
            {
                return NotFound("No exite el id: " + id);
            }

            var pedido = _context.DetallePedidos.FirstOrDefault(
                m => m.IdPedido == id);
            if(pedido == null)
            {
                return NotFound("Error");
            }
            return View(pedido);
        }

        // HTTP GET Create
        public ActionResult Create()
        {
            return View();
        }
        // HTTP POST Create
        [HttpPost]
        public ActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // HTTP GET Edit
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound("ID Nulo");
            }
            else
            {
                var dataPedido = _context.Pedidos.Find(id);
                if(dataPedido == null)
                {
                    return NotFound("Error");
                }
                else
                {
                    return View(dataPedido);
                }
            }
        }

        // HTTP POST Edit
        [HttpPost]
        public ActionResult Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
