using System;
using System.Collections.Generic;

namespace Shop1
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp app = new App(new Shop(new ConsoleOutput()));
            app.Start();
            Console.ReadKey();
        }
    }
    interface IApp
    {
        void Start();
    }
    interface IShop
    {
        void Start();
        void AddBuyer(IBuyer buyer);
        void RemoveBuyer(IBuyer buyer);
    }
    interface IBuyer
    {
        decimal GetTotal();
        void PutInBasket(IProduct product);
        void DeleteFromBasket(IProduct product);
        List<IProduct> GetListBasket();
    }
    interface IProduct
    {
        void SetPrice(decimal price);
        decimal GetPrice();
        string GetName();
    }
    interface ICalculator
    {
        decimal Calculation(List<IProduct> listProducts);
    }
    interface IInput
    {
        bool Read();
        EAction GetAction();
        IProduct GetProduct();

    }
    interface IOutput
    {
        void ShowTotal(decimal total);
        void ShowBasket(List<IProduct> products);
    }
    interface IPage
    {
        int GetCountPage();
        List<IProduct> GetPage(List<IProduct> list);
    }
    enum EAction
    {
        PutProduct,
        DeleteProduct,
        OpenBasket,
        CloseBasket,
        NextPage,
        PreviusPage,
        Error
    }

    class App : IApp
    {
        private readonly IShop _shop;
        public App(IShop shop)
        {
            _shop = shop;
        }
        public void Start()
        {
            _shop.Start();
        }
    }

    class ConsoleInput : IInput
    {
        private EAction _eAction;
        private IProduct _product;
        private string _text;
        public EAction GetAction()
        {
            return _eAction;
        }

        public IProduct GetProduct()
        {
            return _product;
        }

        public bool Read()
        {
            _text = Console.ReadLine();
            if (_text == "q") return false;
            else
            {

                return true;
            }
        }
    }

    class ConsoleOutput : IOutput
    {
        public void ShowBasket(List<IProduct> products)
        {
            foreach (IProduct item in products)
            {
                Console.WriteLine(item.GetName() + "............" + item.GetPrice().ToString() + "$");
            }
        }

        public void ShowTotal(decimal total)
        {
            Console.WriteLine("Total:" + "......." + total.ToString() + "$");
        }
    }

    class Shop : IShop
    {
        private readonly IOutput _output;
        private IBuyer _buyer;
        private List<IBuyer> _listBuyers = new List<IBuyer>();
        private List<IProduct> _listShopProducts = new List<IProduct>();

        public Shop(IOutput output)
        {
            _output = output;
            PutProductsInShop();
        }


        private void PutProductsInShop()
        {
            _listShopProducts.Add(new Product("Milk", (decimal)3.15));
            _listShopProducts.Add(new Product("Bread", (decimal)1.5));
            _listShopProducts.Add(new Product("Chocolate", (decimal)10.2));
            _listShopProducts.Add(new Product("Ice cream", (decimal)3.7));
            _listShopProducts.Add(new Product("Juice", (decimal)13));
            _listShopProducts.Add(new Product("Tea", (decimal)5.12));
            _listShopProducts.Add(new Product("Coffee", (decimal)9.8));
        }

        public void AddBuyer(IBuyer buyer)
        {
            _listBuyers.Add(buyer);
        }

        public void RemoveBuyer(IBuyer buyer)
        {
            _listBuyers.Remove(buyer);
        }

        public void Start()
        {
            _listBuyers.Add(new Buyer(new Calculator()));
            _buyer = _listBuyers[0];
            _buyer.PutInBasket(_listShopProducts[0]);
            _buyer.PutInBasket(_listShopProducts[1]);
            _buyer.PutInBasket(_listShopProducts[3]);
            _buyer.PutInBasket(_listShopProducts[3]);
            _buyer.PutInBasket(_listShopProducts[4]);
            _output.ShowBasket(_buyer.GetListBasket());
            _output.ShowTotal(_buyer.GetTotal());
        }
    }

    class Buyer : IBuyer
    {
        private readonly IProduct _product;
        private readonly ICalculator _calculator;
        private List<IProduct> _listBuyerProducts = new List<IProduct>();
        public Buyer(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public decimal GetTotal()
        {
            return _calculator.Calculation(_listBuyerProducts);
        }

        public void DeleteFromBasket(IProduct product)
        {
            _listBuyerProducts.Remove(product);
        }

        public void PutInBasket(IProduct product)
        {
            _listBuyerProducts.Add(product);
        }

        public List<IProduct> GetListBasket()
        {
            return _listBuyerProducts;
        }
    }
    class Calculator : ICalculator
    {
        public decimal Calculation(List<IProduct> listProducts)
        {
            decimal _total = 0;
            foreach (var item in listProducts)
            {
                _total += item.GetPrice();
            }
            return _total;
        }
    }
    class Product : IProduct
    {
        private decimal _price = 0;
        private string _name = "";
        public Product(string name, decimal price)
        {
            if (name == "") throw new Exception();
            else _name = name;
            if (price > 0) _price = price;
            else throw new Exception();

        }
        public decimal GetPrice() { return _price; }

        public void SetPrice(decimal price)
        {
            if (price > 0) _price = price;
            else throw new Exception();
        }
        public string GetName()
        {
            return _name;
        }

    }
}
