using DataAccessLayer.Models;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalleryMoqDataTest.TestEntities
{

    public class SqlLiteWith20EntitiesTestFixture : IDisposable
    {
        public Gallery_dbContext Context => SqlLiteInMemoryContext();

        public void Dispose()
        {
            Context?.Dispose();
        }

        private Gallery_dbContext SqlLiteInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<Gallery_dbContext>()
                //.UseSqlite("DataSource=:memory:")
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=MSSQLLocalDB;Integrated Security=True;")
                .Options;

            var context = new Gallery_dbContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            context.CartItem.AddRange(TestCartItem());
            context.CartItemTypes.AddRange(TestCartItemTypes());
            context.Country.AddRange(TestCountry());
            context.Currency.AddRange(TestCurrency());
            context.DeliveryDetails.AddRange(TestDeliveryDetails());
            context.DeliveryOption.AddRange(TestDeliveryOption());
            context.OrderItem.AddRange(TestOrderItem());
            context.OrderStatus.AddRange(TestOrderStatus());
            context.OrderTb.AddRange(TestOrderTb());
            context.PaymentOption.AddRange(TestPaymentOption());
            context.Role.AddRange(TestRole());
            context.SellItem.AddRange(TestSellItem());
            context.ShoppingCart.AddRange(TestShoppingCart());
            context.Users.AddRange(TestUsers());
            context.SaveChanges();
            return context;
        }

        //methods generating test data
        private List<CartItem> TestCartItem()
        {
            return Builder<CartItem>.CreateListOfSize(20).TheFirst(20)
                .TheFirst(3).
                     With(x=>x.Quantity = 3)
                .TheNext(6).
                    With(x=>x.Quantity = 6)
                .Build().ToList();
        }

        private List<CartItemTypes> TestCartItemTypes()
        {
            return Builder<CartItemTypes>.CreateListOfSize(20).Build().ToList();
        }

        private List<Country> TestCountry()
        {
            return Builder<Country>.CreateListOfSize(20).Build().ToList();
        }

        private List<Currency> TestCurrency()
        {
            return Builder<Currency>.CreateListOfSize(20).Build().ToList();
        }

        private List<DeliveryDetails> TestDeliveryDetails()
        {
            return Builder<DeliveryDetails>.CreateListOfSize(20).Build().ToList();
        }

        private List<DeliveryOption> TestDeliveryOption()
        {
            return Builder<DeliveryOption>.CreateListOfSize(20).Build().ToList();
        }

        private List<OrderItem> TestOrderItem()
        {
            return Builder<OrderItem>.CreateListOfSize(20).Build().ToList();
        }

        private List<OrderStatus> TestOrderStatus()
        {
            return Builder<OrderStatus>.CreateListOfSize(20).Build().ToList();
        }

        private List<OrderTb> TestOrderTb()
        {
            return Builder<OrderTb>.CreateListOfSize(20).Build().ToList();
        }

        private List<PaymentOption> TestPaymentOption()
        {
            return Builder<PaymentOption>.CreateListOfSize(20).Build().ToList();
        }

        private List<Role> TestRole()
        {
            return Builder<Role>.CreateListOfSize(20).Build().ToList();
        }

        private List<SellItem> TestSellItem()
        {
            return Builder<SellItem>.CreateListOfSize(20).Build().ToList();
        }

        private List<ShoppingCart> TestShoppingCart()
        {
            return Builder<ShoppingCart>.CreateListOfSize(20).Build().ToList();
        }

        //private List<Users> TestUsers()
        //{
        //    return Builder<Users>.CreateListOfSize(20).Build().ToList();
        //}


        private List<Users> TestUsers()
        {
            var usersList = Builder<Users>.CreateListOfSize(20)
                .TheFirst(1)
                    .With(x => x.IdRole = 1)
                    .With(x => x.Name = "Mery")
                    .With(x => x.ProfilePictName = "mery_pict")
                .TheNext(10)
                    .With(x => x.IdRole = 3)
                .Build();

            return usersList.ToList();
        }
    }
}
