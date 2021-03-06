namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class StripeInvoiceItemServiceTest : BaseStripeTest
    {
        private const string InvoiceItemId = "co_123";

        private StripeInvoiceItemService service;
        private StripeInvoiceItemCreateOptions createOptions;
        private StripeInvoiceItemUpdateOptions updateOptions;
        private StripeInvoiceItemListOptions listOptions;

        public StripeInvoiceItemServiceTest()
        {
            this.service = new StripeInvoiceItemService();

            this.createOptions = new StripeInvoiceItemCreateOptions()
            {
                Amount = 123,
                Currency = "usd",
                CustomerId = "cus_123",
            };

            this.updateOptions = new StripeInvoiceItemUpdateOptions()
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new StripeInvoiceItemListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var invoiceItem = this.service.Create(this.createOptions);
            Assert.NotNull(invoiceItem);
            Assert.Equal("invoiceitem", invoiceItem.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var invoiceItem = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(invoiceItem);
            Assert.Equal("invoiceitem", invoiceItem.Object);
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(InvoiceItemId);
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(InvoiceItemId);
            Assert.NotNull(deleted);
        }

        [Fact]
        public void Get()
        {
            var invoiceItem = this.service.Get(InvoiceItemId);
            Assert.NotNull(invoiceItem);
            Assert.Equal("invoiceitem", invoiceItem.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var invoiceItem = await this.service.GetAsync(InvoiceItemId);
            Assert.NotNull(invoiceItem);
            Assert.Equal("invoiceitem", invoiceItem.Object);
        }

        [Fact]
        public void List()
        {
            var invoiceItems = this.service.List(this.listOptions);
            Assert.NotNull(invoiceItems);
            Assert.Equal("list", invoiceItems.Object);
            Assert.Single(invoiceItems.Data);
            Assert.Equal("invoiceitem", invoiceItems.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var invoiceItems = await this.service.ListAsync(this.listOptions);
            Assert.NotNull(invoiceItems);
            Assert.Equal("list", invoiceItems.Object);
            Assert.Single(invoiceItems.Data);
            Assert.Equal("invoiceitem", invoiceItems.Data[0].Object);
        }

        [Fact]
        public void Update()
        {
            var invoiceItem = this.service.Update(InvoiceItemId, this.updateOptions);
            Assert.NotNull(invoiceItem);
            Assert.Equal("invoiceitem", invoiceItem.Object);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var invoiceItem = await this.service.UpdateAsync(InvoiceItemId, this.updateOptions);
            Assert.NotNull(invoiceItem);
            Assert.Equal("invoiceitem", invoiceItem.Object);
        }
    }
}
