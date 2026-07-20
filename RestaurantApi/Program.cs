using RestaurantApi;
using RestaurantApi.Models;
using RestaurantApi.Observers.OrderObservers;
using RestaurantApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<MenuItemRepository>();
builder.Services.AddSingleton<Restaurant>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var restaurant = app.Services.GetRequiredService<Restaurant>();
restaurant.Attach(new KitchenService());
restaurant.Attach(new PaymentService());
restaurant.Attach(new WaiterService());

app.MapGet("/", () => "Restaurant API is running. See /swagger for details.");

app.MapGet("/api/orders", () => Results.Ok(restaurant.GetOrders()));

app.MapGet("/api/orders/{id}", (string id) =>
{
    var order = restaurant.GetOrderById(id);
    return order is not null ? Results.Ok(order) : Results.NotFound();
});

app.MapPut("/api/orders/{id}/state", (string id) =>
{
    try
    {
        var result = restaurant.OrderNextState(id);
        return result is not null ? Results.Ok(result) : Results.NotFound();
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/api/orders", (OrderDto orderDto) =>
{
    return Results.Ok(restaurant.CreateOrder(orderDto));
});

app.MapGet("/api/menu", () =>
{
    return Results.Ok(restaurant.GetMenu());
});

app.Run();
