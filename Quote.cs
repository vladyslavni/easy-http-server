using System;
using System.Collections.Generic;
using Extension;

namespace easy_http_server
{
    public class Quote
    {
        private static readonly Dictionary<string, string[]> words = new Dictionary<string, string[]>()
        {
            {"who", new string[] {"Псина сутулая", "Картофельный король", "Молекулярный Дядько", "Шизоидный дед", 
            "Ниггер-Трансформер", "Твой Отец который ушёл 8 лет назад", "Душитель чужих ужей"}},
            
            {"how", new string[] {"без раздумий", "уверенно", "игриво поглаживая усики", "сексуально", "нежно", 
            "плавно снимая штаны", "рвя на себе последние трусы", "как в последний раз развратно и похотливо"}},
            
            {"does", new string[] {"совращает", "анализирует", "облизывает", "массирует",
            "пожирает взгядом", "входит в"}},
            
            {"what", new string[] {"клавиатуру", "бабушку", "твой говно код", "Транс-Программиста ", "системник", 
            "тебя", "твоего кота", "китайца из уханя", "Игоря"}}
        };

        public static string getWord(string key)
        {
            return words.GetValueOrDefault(key).GetRandomValue();
        }
    
        public static string GetQuote()
        {
            return words.GetValueOrDefault("who").GetRandomValue() + " " +
                    words.GetValueOrDefault("how").GetRandomValue() + " " + 
                    words.GetValueOrDefault("does").GetRandomValue() + " " + 
                    words.GetValueOrDefault("what").GetRandomValue();
        }
    }
}