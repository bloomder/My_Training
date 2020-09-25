using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop2
{
    //Сделать магазин. Есть список товаров и цена на них. Нужно считать на какую сумму покупатель набрал товара.
    interface IApp
    {
        void Run();
    }
    interface IOutput
    {
        void Show(IBasket basket);
    }
    interface IProduct
    {
        string GetName();
        decimal GetPrice();
        int GetAmount();
        int GetDiscount();
    }
    interface IBuyer
    {
        List<IProduct> GetBasket();
        void PutInBasket(string name, int amount);
        void CheckOut();
    }
    interface IWarehouse
    {
        IProduct GetProduct(string name, int amount);
        void AddProduct(IProduct product);
    }
    interface IShop
    {
        IProduct GetAvialable(string name, int amount);
    }
    interface IBasket
    {
        decimal GetTotal();
        void AddProduct(IProduct product);
        List<IProduct> GetProducts();
    }
    class Shop : IShop
    {
        private readonly IWarehouse _warehouse;
        public Shop(IWarehouse warehouse)
        {
            _warehouse = warehouse;
        }
        public IProduct GetAvialable(string name, int amount)
        {
            return _warehouse.GetProduct(name, amount);
        }
    }
    class Buyer : IBuyer
    {
        private readonly IOutput _output;
        private readonly IShop _shop;
        private readonly IBasket _basket;
        public Buyer(IShop shop, IBasket basket, IOutput output)
        {
            _output = output;
            _shop = shop;
            _basket = basket;
        }

        public void CheckOut()
        {
            _output.Show(_basket);
        }

        public List<IProduct> GetBasket()
        {
            return _basket.GetProducts();
        }

        public void PutInBasket(string name, int amount)
        {
            try
            {
                _basket.AddProduct(_shop.GetAvialable(name, amount));
            }
            catch(Exception ex)
            {

            }
        }
    }
    class Product : IProduct
    {
        private string _name;
        private decimal _price;
        private int _amount;
        private int _discount;
        public Product(string name, decimal price, int amount, int discount)
        {
            _name = name;
            _price = price;
            _amount = amount;
            _discount = discount;
        }
        public string GetName()
        {
            return _name;
        }
        public decimal GetPrice()
        {
            return _price;
        }
        public int GetAmount()
        {
            return _amount;
        }

        public int GetDiscount()
        {
            return _discount;
        }
    }
    class Warehouse : IWarehouse
    {
        List<IProduct> _listProducts = new List<IProduct>();
        public void AddProduct(IProduct product)
        {
            _listProducts.Add(product);
        }
        public IProduct GetProduct(string name, int amount)
        {
            var product = _listProducts.First((x) => x.GetName() == name && x.GetAmount() >= amount);
            var returnProduct = new Product(product.GetName(), product.GetPrice(), amount, product.GetDiscount());
            product = new Product(product.GetName(), product.GetPrice(), (int)(product.GetAmount() - amount), product.GetDiscount());
            return returnProduct;
        }
    }
    class Basket : IBasket
    {
        List<IProduct> _listProducts = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            
            _listProducts.Add(product);
        }

        public List<IProduct> GetProducts()
        {
            return _listProducts;
        }

        public decimal GetTotal()
        {
            decimal _total = 0;
            decimal _discount = 0;
            foreach (var item in _listProducts)
            {
                _discount = 100 - item.GetDiscount();
                _discount = _discount / 100;
                _total += (decimal)(Math.Round(((item.GetPrice()*_discount) * item.GetAmount()),2));
            }
            return _total;
        }
        bool SearchProductBasket(IProduct product)
        {
            if()
            var _product = _listProducts.First((x) => x.GetName() == product.GetName());
            var b = _listProducts.Any((x) => x.GetName() == product.GetName());

        }
    }
    class App : IApp
    {
        private readonly IBuyer _buyer;
        private readonly IWarehouse _warehouse;
        public App(IBuyer buyer, IWarehouse warehouse)
        {
            _buyer = buyer;
            _warehouse = warehouse;
        }
        public void Run()
        {
            _warehouse.AddProduct(new Product("Banana", (decimal)1.5, 3, 10));
            _warehouse.AddProduct(new Product("Apple", (decimal)0.7, 10, 0));
            _warehouse.AddProduct(new Product("Orange", (decimal)1.2, 15, 15));
            _buyer.PutInBasket("Banana", 2);
            _buyer.PutInBasket("Apple", 5);
            _buyer.PutInBasket("Orange", 7);
            _buyer.CheckOut();
        }
    }
    class ConsoleOutput : IOutput
    {
        public void Show(IBasket basket)
        {
            decimal discount = 0;
            foreach (var item in basket.GetProducts())
            {
                discount = 100 - item.GetDiscount();
                discount = discount / 100;
                discount = (decimal)(item.GetPrice() * discount);
                discount = Math.Round(discount, 2);
                Console.WriteLine(item.GetName().PadRight(20, '.') + item.GetAmount().ToString() + " X " + discount.ToString() + "$");
            }
            Console.WriteLine("Total:".PadRight(24,'.') + basket.GetTotal().ToString() + "$");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IWarehouse warehouse = new Warehouse();
            IApp app = new App
                (
                    new Buyer
                        (
                           new Shop(warehouse),
                           new Basket(),
                           new ConsoleOutput()
                        ),
                    warehouse
                );
            app.Run();
            Console.ReadKey();
        }
    }
}
