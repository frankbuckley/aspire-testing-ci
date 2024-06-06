var builder = DistributedApplication.CreateBuilder(args);

builder.AddDapr();

var state = builder.AddDaprStateStore("state");

var pubsub = builder.AddDaprPubSub("pubsub");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithDaprSidecar()
    .WithReference(state)
    .WithReference(pubsub);

var apiService2 = builder.AddProject<Projects.AspireSample_ApiService>("apiservice2")
    .WithDaprSidecar()
    .WithReference(state)
    .WithReference(pubsub);

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithDaprSidecar()
    .WithExternalHttpEndpoints()
    .WithReference(state)
    .WithReference(apiService)
    .WithReference(apiService2);

builder.Build().Run();
