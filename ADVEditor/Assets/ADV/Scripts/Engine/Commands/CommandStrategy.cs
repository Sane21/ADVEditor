namespace HarapekoADV.Commands
{
    public interface CommandStrategy
    {
        void Initialise(string[] args);
        void Act(ADVPresenter presenter);

    }
}