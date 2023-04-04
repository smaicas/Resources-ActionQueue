using Nj.Resources.ActionQueue;

namespace Nj_Resources.ActionQueue.Test;

public class ActionQueueTest
{
    [Fact]
    public void ActionQueueBuilder_BuildsActionQueue()
    {
        ActionQueue<string> queue = new ActionQueueBuilder<string>().Build();

        Assert.NotNull(queue);
        Assert.IsType<ActionQueue<string>>(queue);
    }

    [Fact]
    public void ActionQueue_EnqueueActions()
    {
        ActionQueue<string> queue = new ActionQueueBuilder<string>().Build();
        string result = "";

        queue.Enqueue(s => result += s);

        var item = queue.Dequeue();

        Assert.NotNull(item);
        Assert.IsType<Action<string>>(item);
    }

    [Fact]
    public void ActionQueue_ReturnsCount()
    {
        ActionQueue<string> queue = new ActionQueueBuilder<string>().Build();
        string result = "";

        queue.Enqueue(s => result += s);

        var c = queue.Count;

        Assert.Equal(1, c);
    }

    [Fact]
    public void ActionQueue_ReturnsPeek()
    {
        ActionQueue<string> queue = new ActionQueueBuilder<string>().Build();
        string result = "";

        var action1 = new Action<string>((s) => result += s);
        queue.Enqueue(action1);

        var action = queue.Peek();

        Assert.Same(action1, action);
    }

    [Fact]
    public void ActionQueue_CanDequeueAndInvoke()
    {
        ActionQueue<string> queue = new ActionQueueBuilder<string>().Build();
        string result = "cosa";

        var action1 = new Action<string>((s) => result += s);
        queue.Enqueue(action1);

        queue.DequeueAndInvoke("hola");

        Assert.Equal("cosahola", result);
    }
}