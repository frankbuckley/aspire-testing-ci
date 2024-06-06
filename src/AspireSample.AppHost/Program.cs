var builder = DistributedApplication.CreateBuilder(args);

builder.AddDapr();

var pubsub = builder.AddDaprPubSub("pubsub");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithDaprSidecar()
    .WithReference(pubsub);

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithDaprSidecar()
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
