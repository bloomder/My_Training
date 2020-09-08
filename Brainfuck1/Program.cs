using System;
using System.Collections.Generic;
using System.Threading;

namespace Brainfuck1
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp _app = new App(new Brainfuck(new ConsoleOutput()));
            _app.Start();
            Console.ReadKey();
        }
    }

    public static class Settings
    {
        public static string text_input = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.";
        public static string text_output = "";
    }

    interface IApp
    {
        void Start();
    }
    interface ILanguage
    {
        void Processing(string text);
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
            if(_language != null)
            {
                _language.Processing(Settings.text_input);
            }
        }
    }
    class Brainfuck : ILanguage
    {
        private readonly IOutput _output;
        char[] _massChars = new char[30000];
        int _count, _countWhile, _posStartWhile, _posEndWhile;

        public Brainfuck(IOutput output)
        {
            _output = output;
        }
        public void Processing(string text)
        {
            _count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                switch(text[i])
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
}
