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
    public class PaymentRecords
    {
        public int DocID { get; set; }
        public String AptType {get; set;}
        public double PayRate { get; set; }
        public int Hours { get; set; }
        public String ForText { get; set; }
        public DateTime PayDate { get; set; }
         

    }

    #endregion

}