using System;

namespace Constractor_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleRepository pr = new PeopleRepository(new Gmail());

            pr.Add(1,"sina");
            pr.Remove(1,"sina");

            Console.ReadKey();
        }
    }

    public interface ISender
    {
        public void Sender();
    }

    public class Yahoo : ISender
    {
        public void Sender()
        {
            Console.WriteLine("Yahoo");
        }
    }

    public class Gmail : ISender // این رو بعد از تحریم ها اضافه کردیم
    {
        public void Sender()
        {
            Console.WriteLine("Gmail");
        }
    }

    public class Sms : ISender
    {
        public void Sender()
        {
            Console.WriteLine("Sms");
        }
    }

    public class PeopleRepository // من وابستگی کلاس رو به واسطه ی (( رابط یا اینترفیس )) آی سندر ، به سایر کلاس های یاهو و اس ام اس و جیمیل کم کردم و من صرفا به اینترفیس آی سندر وابسته هستم و سایر کلاس ها اگر می خواهن توسط من پیاده سازی بشن باید حتما قوانین گفته شده در این اینترفیس رو پیاده سازی کنن . در واقع من وابستگی رو از کلاس خودم خارج کردم و به سایر کلاس های بیرون از خودم منتقل کردم و حالا باید اونا وابستگی رو از بیرون کلاس به من تزریق کنن . برای این کار روش های مختلفی هست که یکی از آن ها روش کانستراکتور اینجکشن هست 
    {
        private ISender _sender;
        public PeopleRepository(ISender sender) // Constructor Injection
        {
            _sender = sender;
        }

        public bool Add(int key , string fullName)
        {

            Console.WriteLine("People Add");
            _sender.Sender();
            return true;

        }

        public bool Remove(int key, string fullName)
        {
            Console.WriteLine("people Remove");
            _sender.Sender();
            return true;
        }
    } 
    
}
