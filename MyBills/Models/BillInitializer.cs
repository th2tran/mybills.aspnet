using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Database;

namespace MyBills.Models
{
    public class BillInitializer : DropCreateDatabaseIfModelChanges<BillDBContext> {
        protected override void Seed(BillDBContext context) {
            base.Seed(context);
        }
    }
}