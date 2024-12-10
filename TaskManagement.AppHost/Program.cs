var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.TaskManagement_API>("taskmanagement-api");

builder.AddProject<Projects.TaskManagement_UI>("taskmanagement-ui")
    .WithReference(api)
    .WithExternalHttpEndpoints();

builder.Build().Run();
