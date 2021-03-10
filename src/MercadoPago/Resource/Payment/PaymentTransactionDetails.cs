﻿namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Transaction details.
    /// </summary>
    public class PaymentTransactionDetails
    {
        /// <summary>
        /// External financial institution identifier
        /// </summary>
        public string FinancialInstitution { get; set; }

        /// <summary>
        /// Amount received by the seller
        /// </summary>
        public decimal? NetReceivedAmount { get; set; }

        /// <summary>
        /// Total amount paid by the buyer (includes fees)
        /// </summary>
        public decimal? TotalPaidAmount { get; set; }

        /// <summary>
        /// Total installments amount
        /// </summary>
        public decimal? InstallmentAmount { get; set; }

        /// <summary>
        /// Amount overpaid (only for tickets)
        /// </summary>
        public decimal? OverpaidAmount { get; set; }

        /// <summary>
        /// Identifies the resource in the payment processor
        /// </summary>
        public string ExternalResourceUrl { get; set; }

        /// <summary>
        /// For credit card payments is the USN. For offline payment methods,
        /// is the reference to give to the cashier or to input into the ATM.
        /// </summary>
        public string PaymentMethodReferenceId { get; set; }
    }
}
