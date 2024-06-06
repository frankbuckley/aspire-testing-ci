var builder = DistributedApplication.CreateBuilder(args);

builder.AddDapr();

var state = builder.AddDaprStateStore("state");

var pubsub = builder.AddDaprPubSub("pubsub");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithDaprSidecar()
    .WithReference(state)
    .WithReference(pubsub);

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithDaprSidecar()
    //.WithExternalHttpEndpoints()
    .WithReference(state)
    .WithReference(apiService);

builder.Build().Run();
