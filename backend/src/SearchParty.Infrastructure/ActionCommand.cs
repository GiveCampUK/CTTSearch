namespace SearchParty.Infrastructure
{
    using System;

    public class NullDto {}

    public abstract class ActionCommand<TReturn, TArgs> : IActionCommand<TReturn, TArgs>
    {
        public TReturn Execute(TArgs args)
        {
            //TODO: add in validation here
            return PerformAction(args);
        }

        public abstract TReturn PerformAction(TArgs args);
    }

    public abstract class SimpleActionCommand<TReturn> : ActionCommand<TReturn, NullDto>
    {
        public abstract TReturn PerformAction();

        public override TReturn PerformAction(NullDto args)
        {
            throw new NotImplementedException();
        }
    }
}