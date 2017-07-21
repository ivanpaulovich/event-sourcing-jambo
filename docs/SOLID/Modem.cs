public interface Modem
{
    public void Dial(string pno);
    public void Hangup();
    public void Send(char c);
    public char Recv();
}