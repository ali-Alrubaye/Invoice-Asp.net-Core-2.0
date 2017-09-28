using System.Linq;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InvoiceTow.Controllers
{
    public class OrderDetailController : Controller
    {
        private IOrderDetailMapper _orderDetailMapper;
        private IProductMapper _productMapper;
        private ICustomerMapper _customerMapper;
        private IOrderMapper _orderMapper;

        public OrderDetailController(IOrderDetailMapper orderDetailMapper, IProductMapper productMapper, ICustomerMapper customerMapper, IOrderMapper orderMapper )
        {
            _orderDetailMapper = orderDetailMapper;
            _productMapper = productMapper;
            _customerMapper = customerMapper;
            _orderMapper = orderMapper;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var invoiceTestContext = _orderDetailMapper.BlGetAll();
            return View(await invoiceTestContext);
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _orderDetailMapper.BlGetAll();
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            
            var cust = _customerMapper.BlGetAllCustomer();
            ViewData["CustomerId"] = new SelectList(cust, "CustomerId", "FullName");
            var prod = _productMapper.BlGetAllProduct();
            ViewData["ProductId"] = new SelectList(prod, "ProductId", "Article");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Article,Quantity,Price,Vat,Notes,OrdersVm")]OrderDetailVm orderDetail)
        {
            if (ModelState.IsValid)
            {
                await _orderMapper.BlInser(orderDetail.OrdersVm);
                await _orderDetailMapper.BlInser(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            var cust = _customerMapper.BlGetAllCustomer();
            ViewData["CustomerId"] = new SelectList(cust, "CustomerId", "FullName");
            var prod = _productMapper.BlGetAllProduct();
            ViewData["ProductId"] = new SelectList(prod, "ProductId", "Article");
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _orderDetailMapper.BlGetById(id);
          
            if (orderDetail == null)
            {
                return NotFound();
            }
            var prod =  _productMapper.BlGetAllProduct();
            ViewData["ProductId"] = new SelectList(prod, "ProductId", "Article");
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,Article,Quantity,Price,Vat,Notes")] OrderDetailVm orderDetail)
        {
            if (id != orderDetail.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _orderDetailMapper.BlUpdateAsync(orderDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderId))
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
            var prod = _productMapper.BlGetAllProduct();
            ViewData["ProductId"] = new SelectList(prod, "ProductId", "Article", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _orderDetailMapper.BlGetById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             await _orderDetailMapper.BlDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _orderDetailMapper.OrderDetailExists(id);
        }
    }
}