namespace AspireSample.Tests;

public class DistributedApplicationFixture<T> : IAsyncLifetime
    where T : class
{
    private IDistributedApplicationTestingBuilder? _appHost;
    private DistributedApplication? _app;

    public IDistributedApplicationTestingBuilder AppHost => _appHost
        ?? throw new InvalidOperationException("Fixture has not been initialised");

    public DistributedApplication App => _app
        ?? throw new InvalidOperationException("Fixture has not been initialised.");

    public async Task InitializeAsync()
    {
        _appHost = await DistributedApplicationTestingBuilder.CreateAsync<T>().ConfigureAwait(false);

        _app = await AppHost.BuildAsync().ConfigureAwait(false);

        await App.StartAsync().ConfigureAwait(false);
    }

    public async Task DisposeAsync()
    {
        if (_app is not null)
        {
            await _app.StopAsync().ConfigureAwait(false);
            _app.Dispose();
        }
    }
}
