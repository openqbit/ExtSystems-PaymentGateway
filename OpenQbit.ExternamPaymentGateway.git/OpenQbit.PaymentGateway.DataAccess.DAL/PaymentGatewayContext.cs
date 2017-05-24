using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OpenQbit.PaymentGateway.Common.Models;

namespace OpenQbit.PaymentGateway.DataAccess.DAL
{
    public class PaymentGatewayContext : DbContext 
    {
        public PaymentGatewayContext() : base("OpenQbitPaymentGatewayDB") {}
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Merchant> Merchant { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Responce> Responce { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
