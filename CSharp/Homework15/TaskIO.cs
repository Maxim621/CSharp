
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

        // Дочекатися завершення останньої операції запису
        await task;
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
        var readBuffer = new byte[500 * 1024 * 1024];
        var processBuffer = new byte[500 * 1024 * 1024];

        await using var stream = File.OpenRead(_path);
        await using var resultStream = File.OpenWrite("../../../../result.bin");

        while (true)
        {
            var readCount = await stream.ReadAsync(readBuffer, 0, readBuffer.Length);
            if (readCount == 0)
                break;

            var processCount = 0;
            for (int i = 0; i < readCount; i++)
            {
                var ch = (char)readBuffer[i];
                if (char.IsAscii(ch))
                {
                    processBuffer[processCount] = readBuffer[i];
                    processCount++;
                }
            }

            await resultStream.WriteAsync(processBuffer, 0, processCount);
        }
    }
}

internal class Program
{
    private static string _path;

    private static async Task Main(string[] args)
    {
        var gen = new Generator("../../../../data.bin");
        var genTask = gen.Do();
        var parser = new Parser("../../../../data.bin");

        await genTask;
        await parser.Parse();

        await foreach (var line in File.ReadLinesAsync(_path))
        {
            Console.WriteLine(line);
        }

    }
}