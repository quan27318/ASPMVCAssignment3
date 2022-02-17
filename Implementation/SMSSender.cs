using VewMVC.Interfaces;

namespace VewMVC.Implementation
{
    public class SMSSender : ISender
    {
        public string PrintToScreen()
        {
           return "ISeender is being called from SMS Sender class";
        }
    }
}