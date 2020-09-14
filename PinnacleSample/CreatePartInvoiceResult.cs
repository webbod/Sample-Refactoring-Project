namespace PinnacleSample
{
    public class CreatePartInvoiceResult
    {
        public CreatePartInvoiceResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }

        #region Factory Methods

        public static CreatePartInvoiceResult Successful()
        {
            return new CreatePartInvoiceResult(true);
        }

        public static CreatePartInvoiceResult Failed ()
        {
            return new CreatePartInvoiceResult(false);
        }

        #endregion
    }
}
