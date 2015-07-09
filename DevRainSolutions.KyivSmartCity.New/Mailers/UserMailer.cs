using System.Text;
using Mvc.Mailer;

namespace DevRainSolutions.KyivSmartCity.New.Mailers
{
    public class UserMailer : MailerBase, IUserMailer
    {
        private readonly Encoding _defaultEncoding;
        private string _prefix = "[Kyiv Smart City] ";

        public UserMailer()
        {
            MasterName = "_Layout";
            _defaultEncoding = Encoding.GetEncoding("windows-1251");
        }

        public virtual MvcMailMessage Welcome(string to)
        {
            return Populate(x =>
            {
                x.SubjectEncoding = _defaultEncoding;
                x.Subject = Encode(_prefix + "ƒ€куЇмо за реЇстрац≥ю");
                x.ViewName = "Welcome";
                x.To.Add(to);
                x.Bcc.Add("info@smart.kievcity.gov.ua");
            });
        }

        private string Encode(string text)
        {
            return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(text));
        }
    }
}