namespace DelegateReflection;

public class MyVariable<T>
{
    public T Value
    {
        get => val;
        set
        {
            var prev = val;
            val = value;
            OnChangedHandlers(prev, val);
        }
    }

    private T val;

    public delegate void OnChanged(T prev, T @new);

    public OnChanged OnChangedHandlers;
}
