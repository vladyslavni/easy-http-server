using System.Collections.Generic;
using Extension;

namespace easy_http_server
{
    public class RandomWordGenerator
    {
        static readonly List<string> who = new List<string>{"Псина сутулая", "Картофельный король", "Молекулярный Дядько", "Шизоидный дед", 
        "Ниггер-Трансформер", "Твой Отец который ушёл 8 лет назад", "Душитель чужих ужей"};
        static readonly List<string> how = new List<string>{"без раздумий", "уверенно", "игриво поглаживая усики", "сексуально", "нежно", 
        "плавно снимая штаны", "рвя на себе последние трусы", "как в последний раз развратно и похотливо"};
        static readonly List<string> does = new List<string>{"совращает", "анализирует", "облизывает", "массирует",
        "пожирает взгядом", "входит в"};
        static readonly List<string> what = new List<string>{"клавиатуру", "бабушку", "твой говно код", "Транс-Программиста ", "системник", 
        "тебя", "твоего кота", "китайца из уханя", "Игоря"};

        public static string GetRandomWho() 
        {
            return who.GetRandomValue();
        }

        public static string GetRandomHow() 
        {
            return how.GetRandomValue();
        }

        public static string GetRandomDoes() 
        {
            return does.GetRandomValue();
        }

        public static string GetRandomWhat() 
        {
            return what.GetRandomValue();
        }

        public static string GetRandomQuote()
        {
            return GetRandomWho() + " " + GetRandomHow() + " " + 
                    GetRandomDoes() + " " + GetRandomWhat();
        }
    }
}