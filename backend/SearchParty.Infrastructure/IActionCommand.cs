namespace SearchParty.Infrastructure
{
    public interface IActionCommand<out T>
    {
        T Execute(object[] validationErrors);

        void Validate(object[] validationErrors);
    }
}