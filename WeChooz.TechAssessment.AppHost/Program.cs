using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServerPassword = builder.AddParameter("sql-server-password", true);
var sqlServer = builder.AddSqlServer("sql-server", sqlServerPassword, 5678)
                        .WithContainerName("sql_server")
                        .WithLifetime(ContainerLifetime.Persistent)
                        .WithEndpoint("tcp", endpoint => endpoint.IsProxied = false);
var formationDb = sqlServer.AddDatabase("formation");

var cache = builder.AddRedis("cache")
                    .WithContainerName("redis_cache")
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithRedisInsight(options => options
                        .WithContainerName("redis_insight")
                        .WithLifetime(ContainerLifetime.Persistent)
                    );
var internalApi = builder.AddProject<Projects.WeChooz_TechAssessment_Api>("internalapi")
                         .WithReference(formationDb)
                         .WithReference(cache)
                         .WithHttpEndpoint(name: "api", port: 6001, isProxied: false)
                         .WaitFor(cache);

builder.AddProject<Projects.WeChooz_TechAssessment_Web>("webfrontend")
       .AddNpmRestore()
       .WithExternalHttpEndpoints()
       .WithReference(internalApi)
       //.WithReference(cache)
       .WaitFor(internalApi);
       //.WaitFor(cache);

//builder.AddProject<Projects.WeChooz_TechAssessment_Api>("wechooz-techassessment-api");

builder.Build().Run();
