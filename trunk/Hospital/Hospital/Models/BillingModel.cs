using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MySql.Data.MySqlClient;
using Hospital.Providers;

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
        private readonly BillingProvider _provider;

        /*public BillingProviderService() : this(null)
        {

        }*/

        /*public BillingProviderService(BillingProvider provider)
        {
            _provider = provider ?? new BillingProvider();
        }*/

        public void editBillingStatement(int user_id, DateTime date, double amt, string service_item )
        {
            _provider.addBill(user_id, date, amt, service_item);
        }

        public void clearBillingStatement(int user_id)
        {
            _provider.deleteRecords(user_id);
        }

        public void showBillingStatement(string user)
        {
            _provider.patient_getBillingRecords(user);
        }
        
    }
}