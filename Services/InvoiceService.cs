using TourManagerment.Models;
using TourManagerment.Repositories;

namespace TourManagerment.Services
{
    public class InvoiceService
    {
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceService()
        {
            _invoiceRepository = new InvoiceRepository();
        }


        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _invoiceRepository.GetAllAsync();
        }


        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _invoiceRepository.GetByIdAsync(id);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            if (invoice.amount <= 0)
                throw new ArgumentException("Số tiền phải lớn hơn 0");

            if (!invoice.TourOrderID.HasValue)
                throw new ArgumentException("Phải có TourOrderID");

            await _invoiceRepository.AddAsync(invoice);
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            var existingInvoice = await _invoiceRepository.GetByIdAsync(invoice.Id);
            if (existingInvoice == null)
                throw new InvalidOperationException("Không tìm thấy invoice để cập nhật");

            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice != null)
            {
                await _invoiceRepository.DeleteAsync(invoice);
            }
        }

        public async Task<Invoice?> GetInvoiceByTourOrderIdAsync(int tourOrderId)
        {
            var invoices = await _invoiceRepository.FindAsync(i => i.TourOrderID == tourOrderId);
            return invoices.FirstOrDefault();
        }

        public async Task<bool> HasInvoiceForTourOrderAsync(int tourOrderId)
        {
            var invoice = await GetInvoiceByTourOrderIdAsync(tourOrderId);
            return invoice != null;
        }
    }
}