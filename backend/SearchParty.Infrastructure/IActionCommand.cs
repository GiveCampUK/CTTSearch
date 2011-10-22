namespace SearchParty.Infrastructure
{
    /// <summary>
    /// TODO: BA; add validation in.
    /// </summary>
    /// <typeparam name="TReturnValue"></typeparam>
    /// <typeparam name="TArgs"></typeparam>
    public interface IActionCommand<out TReturnValue, in TArgs>
    {
        TReturnValue Execute(TArgs args);
    }
}