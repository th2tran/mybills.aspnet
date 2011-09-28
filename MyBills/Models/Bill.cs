using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MyBills.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Vendor is required")]
        [Display(Name = "Vendor Name:")]
        public string VendorName { get; set; }
        [Required(ErrorMessage="Billing Date must be specified")]
        [Display(Name = "Bill Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode=true)]
        public DateTime BillDate { get; set; }
        [Required(ErrorMessage = "Received Date must be specified")]
        [Display(Name = "Received Date:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReceivedDate { get; set; }
        [Display(Name = "Due Date:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [Display(Name = "Amount:")]
        public decimal Amount { get; set; }
    }

    public class BillDBContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
    }
}