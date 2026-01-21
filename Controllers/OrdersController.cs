using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderDbContext _context;

        public OrdersController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            var orders = from o in _context.Orders.Include(o => o.Product)
                         select o;

            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.OrderNumber.Contains(searchString) || o.CustomerName.Contains(searchString));
            }

            int pageSize = 10;
            var paginatedOrders = await PaginatedList<Order>.CreateAsync(orders.AsNoTracking(), pageNumber ?? 1, pageSize);

            ViewData["CurrentFilter"] = searchString;
            return View(paginatedOrders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View(new Order { OrderDate = DateTime.Now });
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            // Generate OrderNumber
            var dateStr = DateTime.Now.ToString("yyyyMMdd");
            var lastOrder = _context.Orders.Where(o => o.OrderNumber.StartsWith($"ORD-{dateStr}-")).OrderByDescending(o => o.OrderNumber).FirstOrDefault();
            int nextNum = 1;
            if (lastOrder != null)
            {
                var parts = lastOrder.OrderNumber.Split('-');
                if (parts.Length == 3 && int.TryParse(parts[2], out int num))
                {
                    nextNum = num + 1;
                }
            }
            order.OrderNumber = $"ORD-{dateStr}-{nextNum:D4}";

            if (ModelState.IsValid)
            {
                // Custom validations
                if (order.OrderDate > DateTime.Now)
                {
                    ModelState.AddModelError("OrderDate", "Order Date cannot be in the future.");
                }
                if (order.DeliveryDate.HasValue && order.DeliveryDate <= order.OrderDate)
                {
                    ModelState.AddModelError("DeliveryDate", "Delivery Date must be after Order Date.");
                }
                var product = await _context.Products.FindAsync(order.ProductId);
                if (product == null)
                {
                    ModelState.AddModelError("ProductId", "Product not found.");
                }
                else if (order.Quantity > product.StockQuantity)
                {
                    ModelState.AddModelError("Quantity", "Quantity exceeds stock quantity.");
                }
                if (_context.Orders.Any(o => o.OrderNumber == order.OrderNumber))
                {
                    ModelState.AddModelError("OrderNumber", "Order Number must be unique.");
                }
                if (_context.Orders.Any(o => o.CustomerEmail == order.CustomerEmail))
                {
                    ModelState.AddModelError("CustomerEmail", "Customer Email must be unique.");
                }

                if (ModelState.IsValid)
                {
                    order.CreatedAt = DateTime.UtcNow;
                    order.UpdatedAt = DateTime.UtcNow;
                    _context.Add(order);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Order created successfully.";
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Custom validations
                if (order.OrderDate > DateTime.Now)
                {
                    ModelState.AddModelError("OrderDate", "Order Date cannot be in the future.");
                }
                if (order.DeliveryDate.HasValue && order.DeliveryDate <= order.OrderDate)
                {
                    ModelState.AddModelError("DeliveryDate", "Delivery Date must be after Order Date.");
                }
                var product = await _context.Products.FindAsync(order.ProductId);
                if (product == null)
                {
                    ModelState.AddModelError("ProductId", "Product not found.");
                }
                else if (order.Quantity > product.StockQuantity)
                {
                    ModelState.AddModelError("Quantity", "Quantity exceeds stock quantity.");
                }
                if (_context.Orders.Any(o => o.OrderNumber == order.OrderNumber && o.Id != id))
                {
                    ModelState.AddModelError("OrderNumber", "Order Number must be unique.");
                }
                if (_context.Orders.Any(o => o.CustomerEmail == order.CustomerEmail && o.Id != id))
                {
                    ModelState.AddModelError("CustomerEmail", "Customer Email must be unique.");
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        order.UpdatedAt = DateTime.UtcNow;
                        _context.Update(order);
                        await _context.SaveChangesAsync();
                        TempData["Success"] = "Order updated successfully.";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!OrderExists(order.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Order deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}