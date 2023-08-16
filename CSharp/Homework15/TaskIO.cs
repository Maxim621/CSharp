
class Generator
{
    private readonly string _path;
    private readonly long _size;

    private readonly Random _random = new Random();

    public Generator(string path, long size = 10L * 1024 * 1024 * 1024)
    {
        this._path = path;
        this._size = size;
    }

    public async Task Do()
    {
        var bufferSize = (int)(_size * 0.1);
        var task = Task.CompletedTask;
        var buffers = GetBuffers(bufferSize);

        await using var stream = File.OpenWrite(_path);

        var progress = _size;
        while (progress > 0)
        {
            buffers.MoveNext();
            var buffer = buffers.Current;

            _random.NextBytes(buffer);

            await task;
            task = stream.WriteAsync(buffer, 0, buffer.Length);

            progress -= bufferSize;
        }
    }

    private IEnumerator<byte[]> GetBuffers(int length)
    {
        var buffer1 = new byte[length];
        var buffer2 = new byte[length];

        while (true)
        {
            yield return buffer1;
            yield return buffer2;
        }
    }
}

class Parser
{
    private readonly string _path;

    public Parser(string path)
    {
        this._path = path;
    }

    public async Task Parse()
    {
        var buffer = new byte[500 * 1024 * 1024];
        var bufferResult = new byte[500 * 1024 * 1024];
        var semaphore = new SemaphoreSlim(1); // Для обмеження одночасних записів

        await using var stream = File.OpenRead(_path);
        await using var resultStream = File.OpenWrite("../../../../result.bin");

        while (stream.Position < stream.Length)
        {
            var count = await stream.ReadAsync(buffer, 0, buffer.Length);

            var tasks = new List<Task>();

            for (int i = 0; i < count; i++)
            {
                var ch = (char)buffer[i];
                if (char.IsAscii(ch))
                {
                    bufferResult[i] = buffer[i];
                }
            }

            var resultCount = bufferResult.Take(count).Count(b => b != 0);

            await semaphore.WaitAsync();
            try
            {
                await resultStream.WriteAsync(bufferResult, 0, resultCount);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}

internal class Program
{
    private static async Task Main(string[] args)
    {
        var gen = new Generator("../../../../data.bin");
        var genTask = gen.Do();
        var parser = new Parser("../../../../data.bin");

        await genTask;
        await parser.Parse();

        foreach (var line in await File.ReadAllLinesAsync("../../../../result.bin"))
        {
            // Обробка кожного рядка зі result.bin
            Console.WriteLine(line);
        }

    }
}