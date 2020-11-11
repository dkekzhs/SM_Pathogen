public class Say
{
    public string question;
    public EnumManager.States state;
  
    public Say(string _question)
    {
        question = _question;
        state = EnumManager.States.None;
    }

    public Say(EnumManager.States _states)
    {
        state = _states;
    }
}
