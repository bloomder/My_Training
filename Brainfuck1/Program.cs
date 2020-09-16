using System;
using System.Collections.Generic;
using System.Threading;

namespace Brainfuck1
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp _app = new App(new Brainfuck(new ConsoleOutput(), new TestBrainfuckInput(), new Errors()));
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
    interface IErrors
    {
        bool FindReport(string text);
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
        private readonly IErrors _errors;
        char[] _massChars = new char[30000];
        string _text = "";
        int _count = 0;

        public Brainfuck(IOutput output, IInput input, IErrors errors)
        {
            _output = output;
            _input = input;
            _errors = errors;
        }
        public void Processing()
        {            
            _text = _input.Read();
            if (_errors.FindReport(_text))
            {
                _count = 0;
                for (int i = 0; i < _text.Length; i++)
                {
                    switch (_text[i])
                    {
                        case '+':
                            _massChars[_count]++;
                            break;
                        case '-':
                            _massChars[_count]--;
                            break;
                        case '>':
                            _count++;
                            break;
                        case '<':
                            _count--;
                            break;
                        case '[':
                            if(_massChars[_count]==0)
                            {
                                i = (FindEndWhile(i)+1);
                            }
                            break;
                        case ']':
                            if(_massChars[_count]!=0)
                            {
                                i = (FindStartWhile(i)-1);
                            }
                            break;
                        case '.':
                            _output.Show(_massChars[_count].ToString());
                            break;
                    }
                    if ((_count < 0) || (_count >= 30000))
                    {
                        _output.Show("Индекс находился вне границ массива\r\n");
                        return;
                    }
                    
                }
            }
            else
            {
                _output.Show("Ошибка компиляции");
            }
        }
        int FindStartWhile(int position)
        {
            int _stageWhile = 0;
            for (int i = position; i >= 0; i--)
            {
                if(_text[i]==']')
                {
                    _stageWhile++;
                }
                if(_text[i]=='[')
                {
                    _stageWhile--;
                }
                if(_stageWhile==0)
                {
                    position = i;
                    break;
                }
            }
            return position;
        }
        int FindEndWhile(int position)
        {
            int _stageWhile = 0;
            for (int i = position; i < _text.Length; i++)
            {
                if (_text[i] == '[')
                {
                    _stageWhile++;
                }
                if (_text[i] == ']')
                {
                    _stageWhile--;
                }                
                if (_stageWhile == 0)
                {
                    position = i;
                    break;
                }
            }
            return position;
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
    class TestBrainfuckInput : IInput
    {
        public string Read()
        {
            string _defaultText = "";
            _defaultText = "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.";
            //_defaultText = "+[++[++>]]+++<.";
            return _defaultText;
        }
    }

    class Errors : IErrors
    {
        public bool FindReport(string text)
        {
            int _count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '[') _count++;
                if (text[i] == ']') _count--;
            }
            if (_count == 0) return true;
            else return false;
        }
    }
}
