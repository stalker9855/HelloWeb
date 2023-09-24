namespace HelloWeb.Services
{
    public class TimeService
    {
        public string GetTime()
        {
            string message = "";
            int currentHour = DateTime.Now.Hour;

            if (currentHour >= 0 && currentHour < 6)
                message = "Night";
            else if (currentHour >= 6 && currentHour < 12)
                message = "Morning";
            else if (currentHour >= 12 && currentHour < 18)
                message = "Day";
            else if (currentHour >= 18 && currentHour < 24)
                message = "Evening";
            return message;

        }
    }
}
