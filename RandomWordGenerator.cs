using System.Collections.Generic;

namespace easy_http_server
{
    public class RandomWordGenerator
    {
        List<string> who = new List<string>{"Псина сутулая", "Котяра", "Бабёр", "Картофельный король", "Nul", "Братюня"};
        List<string> how = new List<string>{"без раздумий", "уверенно", "думая"};
        List<string> does = new List<string>{"кричит:", "говорит:", "выдаёт:", "огрызается:"};
        List<string> what = new List<string>{"Лави аптечку", "Аннигиляторная пууушкаааа", "Deus Vult", 
        "Я желаю всем мужчинам пройти афганскую войну. Аллах акбар", "Здарова, начальник! Начальник, привет! У нас тут тепло Котлетки в обед Поторопись!"};

        public string GetRandomWho() 
        {
            return who.GetRandomValue();
        }

        public string GetRandomHow() 
        {
            return how.GetRandomValue();
        }

        public string GetRandomDoes() 
        {
            return does.GetRandomValue();
        }

        public string GetRandomWhat() 
        {
            return what.GetRandomValue();
        }

        public string GetRandomQuote()
        {
            return GetRandomWho() + " " + GetRandomHow() + " " + 
                    GetRandomDoes() + " " + GetRandomWhat();
        }
    }
}