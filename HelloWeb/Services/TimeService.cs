namespace HelloWeb.Services
{
    public class TimeService
    {
        public string GetTime()
        {
            string message = "";
            int currentHour = DateTime.Now.Hour;

            if (currentHour >= 0 && currentHour < 6)
                message = "It's night now";
            else if (currentHour >= 6 && currentHour < 12)
                message = "It's morning now";
            else if (currentHour >= 12 && currentHour < 18)
                message = "It's day now";
            else if (currentHour >= 18 && currentHour < 24)
                message = "It's evening";
            return message;

        }
    }
}
