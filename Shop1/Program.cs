using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void AddBuyer(IBuyer );
        void RemoveBuyer();
    }
    interface IBuyer
    {
        float Score();
        void PutInBasket();
        void DeleteFromBasket();
    }
    interface IProduct
    {
        bool SetValue(float price);
        float GetValue();
    }
    interface ICalculator
    {
        float Calculation(float cashBuyer, float price);
    }
    interface IInput
    {
        void Read();
    }
    interface IOutput
    {
        void Show();
    }
    class Shop : IShop
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IBuyer _buyer;
        private List<IBuyer> _listBuyers = new List<IBuyer>();

        public Shop(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        public void AddBuyer(IBuyer buyer)
        {
            _listBuyers.Add(buyer);
        }

        public void RemoveBuyer()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
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
        public float Score()
        {
            throw new NotImplementedException();
        }

        public void DeleteFromBasket()
        {
            throw new NotImplementedException();
        }

        public void PutInBasket()
        {
            throw new NotImplementedException();
        }
    }
}
