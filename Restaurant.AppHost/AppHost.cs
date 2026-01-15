var builder = DistributedApplication.CreateBuilder(args);

// Infrastructure
var sqlserver = builder.AddSqlServer("sqlserver")
    .WithDataVolume();

var restaurantDb = sqlserver.AddDatabase("RestaurantDb");
var ordersDb = sqlserver.AddDatabase("OrdersDb");

var rabbitmq = builder.AddRabbitMQ("messaging", port: 5672)
.WithEnvironment("RABBITMQ_DEFAULT_USER", "admin")
.WithEnvironment("RABBITMQ_DEFAULT_PASS", "admin123")
.WithManagementPlugin()
.WithDataVolume()
.WithLifetime(ContainerLifetime.Persistent);  // Keep container running between restarts

// Services
var ordersApi = builder.AddProject<Projects.Orders_API>("orders-api")
    .WithReference(ordersDb)
    .WithReference(rabbitmq);

var restaurantApi = builder.AddProject<Projects.Restaurant_API>("restaurant-api")
    .WithReference(restaurantDb)
    .WithReference(rabbitmq);

var deliveryApi = builder.AddProject<Projects.Delivery_API>("delivery-api")
    .WithReference(rabbitmq);

var paymentsApi = builder.AddProject<Projects.Payments_API>("payments-api")
    .WithReference(rabbitmq);

builder.Build().Run();
