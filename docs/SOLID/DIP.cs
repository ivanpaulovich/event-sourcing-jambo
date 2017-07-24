public void CheckOut()
{
    MailMessage myMessage = new MailMessage(
        "loja@minhaloja.com", 
        "usuario@minhaloja.com", 
        "Seu pedido foi recebido.",
        "Obrigado!");

    SmtpClient smptClient = new SmtpClient("localhost");
    smtpClient.Send(myMessage);    
}

public interface ISendEmail
{
    void SendMail(string to, string from, string subject, string body);
}

public class LiveSmtpMailer : ISendEmail
{
    void SendMail(string to, string from, string subject, string body)
    {
        MailMessage myMessage = new MailMessage(from, to, subject, body);
        SmtpClient smptClient = new SmtpClient("localhost");
        smtpClient.Send(myMessage);    
    }
}

public class Cart
{
    private ISendEmail _emailProvider;

    public Cart(ISendEmail emailProvider)
    {
        _emailProvider = emailProvider;  
    }

    public void Checkout()
    {
        this.emailProvider.SendMail(
            "loja@minhaloja.com", 
            "usuario@minhaloja.com", 
            "Seu pedido foi recebido.",
            "Obrigado!");      
    } 
}