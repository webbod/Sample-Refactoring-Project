using PinnacleSample.Interfaces;
using System;

namespace PinnacleSample
{
    public class DataService : IDataService, IDisposable
    {
        private ICustomerService __CustomerService;
        public ICustomerService CustomerService
        {
            get
            {
                // lazy loading
                if (__CustomerService == null) { __CustomerService = new CustomerRepositoryDB(); }
                return __CustomerService;
            }
        }

        private IPartInvoiceService __PartInvoiceService;
        public IPartInvoiceService PartInvoiceService
        {
            get
            {
                if (__PartInvoiceService == null) { __PartInvoiceService = new PartInvoiceRepositoryDB(); }
                return __PartInvoiceService;
            }
        }

        private IPartAvailabilityService __PartAvaliabilityService;
        public IPartAvailabilityService PartAvaliabilityService
        {
            get
            {
                if (__PartAvaliabilityService == null) { __PartAvaliabilityService = new PartAvailabilityServiceClient(); }
                return __PartAvaliabilityService;
            }
        }

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                }

                // free unmanaged resources (unmanaged objects) and override finalizer

                __CustomerService = null;
                __PartInvoiceService = null;
                __PartAvaliabilityService = null;

                disposedValue = true;
            }
        }
        
        ~DataService()
        {
             Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
