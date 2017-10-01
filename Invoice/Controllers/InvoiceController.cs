using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Repositories.Models;

namespace Invoice.Controllers
{
    public class InvoiceController : Controller
    {
        
        private IInvoiceMapper _invoiceMapper;
        private IOrderDetailMapper _iOrderDetailMapper;
        private ICustomerMapper _customerMapper;
        private ICompanyMapper _companyMapper;
        private IOrderMapper _orderMapper;

        public InvoiceController( IInvoiceMapper invoice, IOrderDetailMapper orderDetailMapper, ICustomerMapper customer, ICompanyMapper companyMapper, IOrderMapper orderMapper)
        {
            _invoiceMapper = invoice;
            _iOrderDetailMapper = orderDetailMapper;
            _customerMapper = customer;
            _companyMapper = companyMapper;
            _orderMapper = orderMapper;
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
        public async Task<IActionResult> Test()
        {
            var inf2 = await _invoiceMapper.BlGetById(1);
            //var inf = await _invoiceMapper.BlGetAll();

            return View(inf2);
        }
        public async Task<IActionResult> Invoice(int ? id)
        {
            //var inf2 = await _invoiceMapper.BlGetById(id);
            var inf = await _customerMapper.BlGetCustById(id);

            return View(inf);
        }
        public async Task<JsonResult> GetCustomerJson(int? id)
        {
           
            var inf2 = await  _customerMapper.BlGetCustById(id);
           
            return Json(inf2);
        }
        public async Task<JsonResult> GetCompanyJson(int? id)
        {

            var inf2 = await _companyMapper.BlGetById(id);

            return Json(inf2);
        }
        public async Task<JsonResult> GetOederDetailsJson(int? id)
        {
            var inf2 = await _orderMapper.GetOrderById(id);
           
            return Json(inf2);
        }
    }
}