using System;
using System.Collections.Generic;
using System.Threading;

namespace Brainfuck1
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp _app = new App(new Brainfuck(new ConsoleOutput(), new ConsoleInput()));
            _app.Start();
            Console.ReadKey();
        }
    }

    interface IApp
    {
        void Start();
    }
    interface ILanguage
    {
        void Processing();
    }
    interface IOutput
    {
        void Show(string text);
    }
    interface IInput
    {
        string Read();
    }

    class App : IApp
    {
        private readonly ILanguage _language;
        public App(ILanguage language)
        {
            _language = language;
        }
        public void Start()
        {
           _language.Processing();
        }
    }
    class Brainfuck : ILanguage
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        char[] _massChars = new char[30000];
        int _count, _countWhile, _posStartWhile, _posEndWhile;
        string _defaultText = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.";

        public Brainfuck(IOutput output, IInput input)
        {
            _output = output;
            _input = input;
        }
        public void Processing()
        {
            string _text = _input.Read();
            if (_text == "") _text = _defaultText;
            _count = 0;
            for (int i = 0; i < _text.Length; i++)
            {
                switch(_text[i])
                {
                    case '+':
                        _massChars[_count]++;
                        break;
                    case '[':
                        _countWhile = _count;
                        _posStartWhile = i;
                        if (_massChars[_countWhile] <= 0) i = _posEndWhile;
                        break;
                    case '>':
                        _count++;   
                        break;
                    case '<':
                        _count--;
                        if (_count < 0)
                        {
                            _output.Show("Индекс находился вне границ массива");
                            i = _text.Length;
                        }
                        break;
                    case '-':
                        _massChars[_count]--;
                        break;
                    case ']':
                        _posEndWhile = i;
                        i = _posStartWhile-1;
                        break;
                    case '.':
                        _output.Show(_massChars[_count].ToString());
                        break;
                }

            }
        }
    }
    class ConsoleOutput : IOutput
    {
        public void Show(string text)
        {
            Console.Write(text);
        }
    }
    class ConsoleInput : IInput
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
