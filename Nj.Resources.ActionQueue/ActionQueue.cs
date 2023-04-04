namespace Nj.Resources.ActionQueue;
public class ActionQueue<T>
{
    private readonly Queue<Action<T>> _queue = new();
    public void Enqueue(Action<T> action)
    {
        _queue.Enqueue(action);
    }

    public Action<T> Dequeue()
    {
        return _queue.Dequeue();
    }
    public void DequeueAndInvoke(T arg)
    {
        if (_queue.Count > 0) _queue.Dequeue().Invoke(arg);
    }

    public Action<T> Peek() => _queue.Peek();

    public int Count => _queue.Count;
}

public class ActionQueueBuilder<T>
{
    public ActionQueue<T> Build()
    {
        return new ActionQueue<T>();
    }
}