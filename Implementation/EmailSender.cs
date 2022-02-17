using VewMVC.Interfaces;

namespace VewMVC.Implementation;

public class EmailSender : ISender
{
    public string PrintToScreen()
    {
        return "ISeender is being called from EmailSender class";
    }
}
