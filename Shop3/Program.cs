using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop3
{
    //Сделать магазин. Есть список товаров и цена на них. Нужно считать на какую сумму покупатель набрал товара.

    /*
     добавь возможность проводить акции! "2(или 3) товара по цене одного" и "вместе дешевле"!
     в чеке после суммы за товар нужно писать за что скидка и отрицательную сумму.
     акция должна работать даже если покупатель покупает не 2 банана вместе, а 2 раза по одному. 
     вместе дешевле - значит если, например, покупаешь банан и яблоко, то на них даётся скидка 10%
     если есть выбор одной акции из двух, выбрать ту которая выгодна покупателю
    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    interface IApp
    {
        void Run();
    }
    interface IProduct
    {
        string GetName();
        decimal GetPrice();
        int GetAmount();
    }
    interface IBasket
    {
        List<IProduct> GetProducts();
        void AddProduct(IProduct product);
    }
    interface IWarehouse
    {
        bool ProductExists(IProduct product);
        void AddProduct(IProduct product);
        IProduct FindProduct(IProduct product);
        void RemoveProduct(IProduct product);
    }
    interface IDiscount
    {
        string GetName();
        List<IProduct> GetProducts();
        int GetDiscount();
    }
    interface IPromotions
    {
        List<IDiscount> GetDiscounts();
        bool DiscountExists(IProduct product);
        
    }
    interface IShop
    {
        IBasket GetBasket();
        void AddBasket(IBasket basket);
        void RemoveBasket(IBasket basket);

        IWarehouse GetWarehouse();
        void AddWarehouse(IWarehouse warehouse);
        void RemoveWarehouse(IWarehouse warehouse);
        void CheckOut(IBasket basket);


    }
    interface IBuyer
    {
        IShop GetShop();
        void AddShop(IShop shop);
        void RemoveShop(IShop shop);
    }


    //----------------------------------------------------------------------------------------------

    class Product : IProduct
    {
        string _name = "";
        decimal _price = 0;
        int _amount = 0;
        public Product(string name)
        {
            _name = name;
        }
        public Product(string name, decimal price)
        {
            _name = name;
            _price = price;
        }
        public Product(string name, int amount)
        {
            _name = name;
            _amount = amount;
        }
        public Product(string name, decimal price, int amount)
        {
            _name = name;
            _price = price;
            _amount = amount;
        }
        public int GetAmount()
        {
            return _amount;
        }

        public string GetName()
        {
            return _name;
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }

    class Basket : IBasket
    {
        List<IProduct> _listProducts = new List<IProduct>();
        public void AddProduct(IProduct product)
        {
            if(ProductExists(product))
            {
                var _product = FindProduct(product);
                _product = new Product(product.GetName(), ((int)(product.GetAmount() + _product.GetAmount())));
            }
            else
            {
                _listProducts.Add(product);
            }
        }

        public List<IProduct> GetProducts()
        {
            throw new NotImplementedException();
        }

        bool ProductExists(IProduct product)
        {
            return _listProducts.Any((x) => x.GetName() == product.GetName());
        }
        IProduct FindProduct(IProduct product)
        {
            return _listProducts.First((x) => x.GetName() == product.GetName());
        }
    }

    class App : IApp
    {
        private readonly IBuyer _buyer;
        public App(IBuyer buyer)
        {
            _buyer = buyer;
        }
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
