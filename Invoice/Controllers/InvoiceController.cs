using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Invoice.Controllers
{
    public class InvoiceController : Controller
    {
        
        private IInvoiceMapper _invoiceMapper;
        private IOrderDetailMapper _iOrderDetailMapper;
        private ICustomerMapper _customerMapper;

        public InvoiceController( IInvoiceMapper invoice, IOrderDetailMapper orderDetailMapper, ICustomerMapper customer)
        {
            _invoiceMapper = invoice;
            _iOrderDetailMapper = orderDetailMapper;
            _customerMapper = customer;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var inf = await _iOrderDetailMapper.BlGetById(id);

            return View(inf);
        }
        public async Task<IActionResult> InvoiceTest(int id=1)
        {
            var inf = await _invoiceMapper.BlGetById(id);
            //var inf = await _invoiceMapper.BlGetAll();

            return View( inf);
        }
        public async Task<IActionResult> InvoiceTest2(int? id=1)
        {
            var inf2 = await _invoiceMapper.BlGetById(id);
            //var inf = await _invoiceMapper.BlGetAll();

            return View(inf2);
        }
        public async Task<IActionResult> Test(int? id = 1)
        {
            var inf2 = await _invoiceMapper.BlGetById(id);
            //var inf = await _invoiceMapper.BlGetAll();

            return View(inf2);
        }
        //// GET: Posts/Create
        //public async Task<IActionResult> Create()
        //{
            
        //    var cust = _customerMapper.BlGetAllCustomer();
        //    ViewData["CustomerId"] = new SelectList(cust, "CustomerId", "LastName");

        //    return View();
        //}
    }
}