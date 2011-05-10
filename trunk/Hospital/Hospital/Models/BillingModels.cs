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
    public class Bill
    {
        public int id { get; set; }
        public string patient { get; set; }
        public double bill_total { get; set; }
        public string for_text { get; set; }
        public DateTime bill_date { get; set; }

    }

    #endregion

    #region services
    public class BillingProviderService{
      private readonly BillingProvider _provider;

        public BillingProviderService() : this(null)
        {
        }

        public BillingProviderService(BillingProvider provider)
        {
            _provider = provider ?? new BillingProvider();
        }

        public void addBill(Bill b)
        {
            _provider.addBill(b);
        }
    }

    #endregion

  }