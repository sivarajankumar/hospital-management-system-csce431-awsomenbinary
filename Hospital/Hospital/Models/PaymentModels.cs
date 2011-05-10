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
    public class Payment
    {
        public int id { get; set; }
        public string doctor { get; set; }
        public string type { get; set; }
        public double pay_rate { get; set; }
        public double hours { get; set; }
        public string for_text { get; set; }
        public DateTime pay_date { get; set; }

    }

    #endregion

    #region services
    public class PaymentProviderService{
      private readonly PaymentProvider _provider;

        public PaymentProviderService() : this(null)
        {
        }

        public PaymentProviderService(PaymentProvider provider)
        {
            _provider = provider ?? new PaymentProvider();
        }

        public void makePayment(Payment p)
        {
            _provider.makePayment(p);
        }
    }

    #endregion

  }