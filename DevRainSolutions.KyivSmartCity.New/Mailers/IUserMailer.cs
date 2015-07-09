using Mvc.Mailer;

namespace DevRainSolutions.KyivSmartCity.New.Mailers
{ 
    public interface IUserMailer
    {
			MvcMailMessage Welcome(string to);
	}
}