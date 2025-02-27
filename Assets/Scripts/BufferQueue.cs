using System.Collections.Generic;

public class BufferQueue
{
    object _lock = new();
    public static BufferQueue Instance { get; } = new BufferQueue();
    private Queue<Pbm.Message> _buffer = new();

    public void Push(Pbm.Message message)
    {
        lock (_lock)
        {
            _buffer.Enqueue(message);
        }
    }

    public List<Pbm.Message> Pop()
    {
        var buffer = new List<Pbm.Message>();

        lock (_lock)
        {
            while (_buffer.Count > 0)
            {
                buffer.Add(_buffer.Dequeue());
            }
        }

        return buffer;
    }
}