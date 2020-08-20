using System;
using System.Collections.Generic;
using Extension;

namespace easy_http_server
{
    public class Quote
    {
        private static readonly string[] who = new string[] {"Псина сутулая", "Картофельный король", "Молекулярный Дядько", "Шизоидный дед", 
        "Ниггер-Трансформер", "Твой Отец который ушёл 8 лет назад", "Душитель чужих ужей"};
        
        private static readonly string[] how = new string[] {"без раздумий", "уверенно", "игриво поглаживая усики", "сексуально", "нежно", 
        "плавно снимая штаны", "рвя на себе последние трусы", "как в последний раз развратно и похотливо"};
        
        private static readonly string[] does = new string[] {"совращает", "анализирует", "облизывает", "массирует",
        "пожирает взгядом", "входит в"};
        
        private static readonly string[] what = new string[] {"клавиатуру", "бабушку", "твой говно код", "Транс-Программиста ", "системник", 
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
        public static string GetQuote()
        {
            return who.GetRandomValue() + " " +
                    how.GetRandomValue() + " " + 
                    does.GetRandomValue() + " " + 
                    what.GetRandomValue();
        }
    }
}