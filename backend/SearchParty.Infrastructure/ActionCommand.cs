namespace SearchParty.Infrastructure
{
    public abstract class ActionCommand<TReturn> : IActionCommand<TReturn>
    {
        public abstract void Validate(object[] validationErrors);

        public TReturn Execute(object[] validationErrors)
        {
            Validate(validationErrors);

            if (validationErrors != null)
            {
                throw new ApiValidationException(validationErrors);
            }

            return PerformAction();
        }

        public abstract TReturn PerformAction();
    }
}