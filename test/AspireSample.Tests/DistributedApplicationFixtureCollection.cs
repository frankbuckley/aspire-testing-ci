namespace AspireSample.Tests;

[CollectionDefinition("DistributedApplicationFixture")]
public class DistributedApplicationFixtureCollection
    : ICollectionFixture<DistributedApplicationFixture<Projects.AspireSample_AppHost>>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
