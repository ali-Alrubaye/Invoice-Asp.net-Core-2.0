using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InvoiceTow.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyMapper _companyMapper { get; }
       
        public CompanyController(ICompanyMapper companyMapper)
        {
            _companyMapper = companyMapper;
        }
        public async Task<IActionResult> Index()
        {

            var comp = _companyMapper.BlGetAll();
            //return View(comp);
            return View(await comp);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            //ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId");
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyName,Address,City,Region,Country,PostCode,Phone,Phone2,Email,Website,OrgNumber,Picture")] CompanyVm post)
        {
            if (ModelState.IsValid)
            {
               await _companyMapper.BlInser(post);
                
                return RedirectToAction(nameof(Index));
            }
           
            return View(post);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _companyMapper.BlGetById(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _companyMapper.BlGetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,Address,City,Region,Country,PostCode,Phone,Phone2,Email,Website,OrgNumber,Picture")] CompanyVm company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _companyMapper.BlUpdateAsync(company);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    var Exists = _companyMapper.CompanyExists((company.CompanyId));
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
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _companyMapper.BlGetById(id);
               
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _companyMapper.BlDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool CompanyExists(int id)
        //{
        //    var ret = await _companyMapper.f(id);
        //    if (ret != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}