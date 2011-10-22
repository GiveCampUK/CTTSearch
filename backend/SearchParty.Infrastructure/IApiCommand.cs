namespace SearchParty.Infrastructure
{
    public interface IApiCommand<out T>
    {
        T Execute(object[] validationErrors);

        void Validate(object[] validationErrors);
    }
}