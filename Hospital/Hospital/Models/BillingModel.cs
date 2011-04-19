using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
       #region models
    public class BillingRecords
    {
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public double BillTotal { get; set; }
        public String Item { get; set; }
                
    }

       #endregion
    public class BillingServices
    {
        public void makePayment(int id)
        {
            _provider.cancelAppointment(id);
        }

    }
}