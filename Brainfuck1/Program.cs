using System.Collections.Generic;

namespace Brainfuck1
{
    class Program
    {
        static void Main(string[] args)
        {
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
        string Processing(string text);
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
        private readonly IOutput _output;
        private readonly IInput _input;
        public App(ILanguage language, IOutput output, IInput input)
        {
            _language = language;
            _output = output;
            _input = input;
        }
        public App(ILanguage language, IOutput output)
        {
            _language = language;
            _output = output;
        }
        public void Start()
        {
            if(_input != null)
            {
                Settings.text_input = _input.Read();
            }
            if(_language != null)
            {
                Settings.text_output = _language.Processing(Settings.text_input);
            }
            if(_output != null)
            {
                _output.Show(Settings.text_output);
            }

        }
    }
    class Brainfuck : ILanguage
    {
        public string Processing(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
