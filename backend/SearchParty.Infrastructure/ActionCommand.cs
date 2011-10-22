namespace SearchParty.Infrastructure
{
    public abstract class ActionCommand<TReturn, TArgs> : IActionCommand<TReturn,TArgs>
    {
        

        public TReturn Execute(TArgs args)
        {
            //TODO: add in validation here
            return PerformAction(args);
        }

        public abstract TReturn PerformAction(TArgs args);
    }
}