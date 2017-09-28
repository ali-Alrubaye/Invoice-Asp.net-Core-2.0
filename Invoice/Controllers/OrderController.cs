using System.Linq;
using System.Threading.Tasks;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Controllers
{
    public class OrderController : Controller
    {
        private IOrderMapper _OrderMapper { get; }
        private ICustomerMapper _customerMapper { get; }

        public OrderController(IOrderMapper orderMapper, ICustomerMapper customerMapper)
        {
            _OrderMapper = orderMapper;
            _customerMapper = customerMapper;
        }
        public async Task<IActionResult> Index()
        {
            var comp = _OrderMapper.BlGetAll();
            return View(await comp);
        }

        // GET: Posts/Create
        public async Task<IActionResult> Create()
        {
          
            var cust = _customerMapper.BlGetAllCustomer();
            ViewData["CustomerId"] = new SelectList(cust, "CustomerId", "FullName");
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderNumber,OrderDate,RequiredDate,AdvancePaymentTax,IsOffer,OfferlDetails,Paid")] OrderVm order)
        {
            var cust = _customerMapper.BlGetAllCustomer();
            if (ModelState.IsValid)
            {
                await _OrderMapper.BlInser(order);

                return RedirectToAction(nameof(Index));

            }
           
            ViewData["CustomerID"] = new SelectList(cust, "CustomerID", "FullName", order.CustomerId);
            return View(order);
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Order = await _OrderMapper.BlGetById(id);
            if (Order == null)
            {
                return NotFound();
            }

            return View(Order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Order = await _OrderMapper.BlGetById(id);
            if (Order == null)
            {
                return NotFound();
            }
            var cust = _customerMapper.BlGetAllCustomer();
            ViewData["CustomerId"] = new SelectList(cust, "CustomerId", "FullName");
            return View(Order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderNumber,OrderDate,RequiredDate,AdvancePaymentTax,IsOffer,OfferlDetails,Paid")] OrderVm Order)
        {
            if (id != Order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _OrderMapper.BlUpdateAsync(Order);

                }
                catch (DbUpdateConcurrencyException)
                {
                    var Exists = _OrderMapper.OrderExists((Order.OrderId));
                    if (!Exists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var cust = _customerMapper.BlGetAllCustomer();
                ViewData["CustomerId"] = new SelectList(cust, "CustomerId", "FullName");
                return RedirectToAction(nameof(Index));
            }
            return View(Order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Order = await _OrderMapper.BlGetById(id);

            if (Order == null)
            {
                return NotFound();
            }

            return View(Order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _OrderMapper.BlDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}