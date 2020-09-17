using System;
using System.Collections.Generic;

namespace Shop1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    interface IApp
    {
        void Start();
    }
    interface IShop
    {
        void Start();
        void Stop();
        void AddBuyer(IBuyer buyer);
        void RemoveBuyer(IBuyer buyer);
    }
    interface IBuyer
    {
        decimal Total();
        void PutInBasket(IProduct product);
        void DeleteFromBasket(IProduct product);
    }
    interface IProduct
    {
        void SetPrice(decimal price);
        decimal GetPrice();
    }
    interface ICalculator
    {
        decimal Calculation(List<IProduct> listProducts);
    }
    interface IInput
    {
        bool Read();
        EAction GetAction();
    }
    interface IOutput
    {
        void Show();
        void ShowQuestion();
    }
    enum EAction
    {
        PutProduct,
        DeleteProduct,
        OpenBasket,
        CloseBasket,
        Error
    }
    class Shop : IShop
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private IBuyer _buyer;
        private List<IBuyer> _listBuyers = new List<IBuyer>();

        public Shop(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
            _output.ShowQuestion();
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
            _listBuyers.Add(new Buyer());
            _buyer = _listBuyers[1];
            while(_input.Read())
            {
                switch(_input.GetAction())
                {
                    case EAction.PutProduct:
                        break;
                    case EAction.DeleteProduct:
                        break;
                    case EAction.OpenBasket:
                        break;
                    case EAction.CloseBasket:
                        break;
                    case EAction.Error:
                        break;
                }
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }

    class Buyer : IBuyer
    {
        private readonly IProduct _product;
        private readonly ICalculator _calculator;
        private List<IProduct> _listProducts = new List<IProduct>();
        public decimal Total()
        {
            return _calculator.Calculation(_listProducts);
        }

        public void DeleteFromBasket(IProduct product)
        {
            _listProducts.Add(product);
        }

        public void PutInBasket(IProduct product)
        {
            _listProducts.Remove(product);
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
    }
}
