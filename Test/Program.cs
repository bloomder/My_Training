using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> _listA = new List<IBuyer>();
            List<IBuyer> _listB = new List<IBuyer>();
            IBuyer _buyer;

            _listA.Add(new Buyer("Петя"));
            _listB.Add(new Buyer("Влад"));
            Console.WriteLine("_listA: " + _listA.Last().GetName());
            Console.WriteLine("_listB: " + _listB.Last().GetName()+"\r\n");

            _buyer = _listA.Last();
            _buyer.SetName("Дима");

            Console.WriteLine("_listA: " + _listA.Last().GetName());
            Console.WriteLine("_listB: " + _listB.Last().GetName()+"\r\n");
            _listA = _listB;

            Console.WriteLine("_listA: " + _listA.Last().GetName());
            Console.WriteLine("_listB: " + _listB.Last().GetName());

            Console.ReadKey();
        }

    }
    interface IBuyer
    {
        string GetName();
        void SetName(string name);
    }
    class Buyer : IBuyer
    {
        private string _name = "";
        public Buyer(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}
