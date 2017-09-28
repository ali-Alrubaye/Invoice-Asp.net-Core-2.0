using AutoMapper;
using BusinessLayers.Models;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayers.MapperClass
{
    public class InvoiceMapper : IInvoiceMapper
    {
        private IInvoice _invoice;
        public InvoiceMapper(IInvoice invoice)
        {
            _invoice = invoice;
        }
        public async Task<InvoiceVm> BlGetAll()
        {
            var getData = await _invoice.GetAll();
            var randomCategory = Mapper.Map<Invoice, InvoiceVm>(getData);

            return randomCategory;
        }

        public async Task<InvoiceVm> BlGetById(int? id)
        {
            var getRepo = await _invoice.GetByIdAsync(id);
            var randomCategory = Mapper.Map<Invoice, InvoiceVm>(getRepo);
            return randomCategory;
        }

        public async Task BlInser(InvoiceVm Category)
        {
            var addMap = Mapper.Map<InvoiceVm, Invoice>(Category);
            await _invoice.InsertAsync(addMap);
        }

        public async Task BlUpdateAsync(InvoiceVm Category)
        {
            var editMap = Mapper.Map<InvoiceVm, Invoice>(Category);
            await _invoice.UpdateAsync(editMap);
        }

        public async Task BlDeleteAsync(int id)
        {
            //var getFromR =await _categoryRepository.GetByIdAsync(id);
            await _invoice.DeleteAsync(id);
        }
        public bool CategoryExists(int id)
        {
            var getRepo = _invoice.InstructorExists(id);
            return getRepo;
        }

        public IEnumerable<InvoiceVm> BlGetAllInstructor()
        {
            var getData = _invoice.GetInstructor();
            var randomCompany = Mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceVm>>(getData);

            return randomCompany;
        }
    }
}
