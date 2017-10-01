using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InvoiceTow.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerMapper _CustomerMapper { get; }
        private ICompanyMapper _companymapper { get; }

        public CustomerController(ICustomerMapper customerMapper, ICompanyMapper companyMapper)
        {
            _CustomerMapper = customerMapper;
            _companymapper = companyMapper;
        }
        public async Task<IActionResult> Index()
        {

            var comp = _CustomerMapper.BlGetAll();
            return View(await comp);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            var company =  _companymapper.BlGetAllCompany();
            //var comp = _CustomerMapper.BlGetAll2();
            
            ViewData["CompanyId"] = new SelectList(company, "CompanyId", "CompanyName");
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstMidName,LastName,CompanyName,ContactPerson,ContactTitle,Address,City,Region,PostCode,Country,Phone,Phone2,Fax,Email,CompanyId")] CustomerVm post)
        {
            if (ModelState.IsValid)
            {
                await _CustomerMapper.BlInser(post);

                return RedirectToAction(nameof(Index));
            }
            var company = _companymapper.BlGetAllCompany();
            ViewData["CompanyId"] = new SelectList(company, "CompanyId", "CompanyName", post.CompanyId);
            return View(post);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Customer = await _CustomerMapper.BlGet_Cust_Comp_ById(id);
            if (Customer == null)
            {
                return NotFound();
            }

            return View(Customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Customer = await _CustomerMapper.BlGet_Cust_Comp_ById(id);
            if (Customer == null)
            {
                return NotFound();
            }
            var company = _companymapper.BlGetAllCompany();
            ViewData["CompanyId"] = new SelectList(company, "CompanyId", "CompanyName");
            return View(Customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstMidName,LastName,CompanyName,ContactPerson,ContactTitle,Address,City,Region,PostCode,Country,Phone,Phone2,Fax,Email,CompanyId")] CustomerVm cust)
        {
            if (id != cust.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _CustomerMapper.BlUpdateAsync(cust);

                }
                catch (DbUpdateConcurrencyException)
                {
                    var Exists = _CustomerMapper.CustomerExists((cust.CustomerId));
                    if (!Exists)
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
            //var company = _companymapper.BlGetAllCompany();
            //ViewData["CompanyID"] = new SelectList(company, "CompanyID", "CompanyName", cust.CustomerID);
            return View(cust);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Customer = await _CustomerMapper.BlGet_Cust_Comp_ById(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return View(Customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _CustomerMapper.BlDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}