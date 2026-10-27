using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Productos.Api.Endpoints;
using Productos.Api.Models;
using Productos.Api.Services;

namespace Productos.Api.Tests;

public class ProductoEndpointsTests
{
    [Fact]
    public async Task GetProductos_ReturnsThreeProducts()
    {
        var (app, client) = await CreateApiAsync();
        await using var application = app;
        using var httpClient = client;

        var productos = await httpClient.GetFromJsonAsync<Producto[]>("/api/productos");

        Assert.NotNull(productos);
        Assert.Equal(3, productos.Length);
    }

    [Fact]
    public async Task GetProducto_WhenItDoesNotExist_ReturnsNotFound()
    {
        var (app, client) = await CreateApiAsync();
        await using var application = app;
        using var httpClient = client;

        var response = await httpClient.GetAsync("/api/productos/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetHealth_ReturnsHealthyStatus()
    {
        var (app, client) = await CreateApiAsync();
        await using var application = app;
        using var httpClient = client;

        var response = await httpClient.GetAsync("/health");
        var health = await response.Content.ReadFromJsonAsync<HealthResponse>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(health);
        Assert.Equal("Healthy", health.Status);
    }

    private static async Task<(WebApplication App, HttpClient Client)> CreateApiAsync()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Services.AddSingleton<IProductoService, ProductoService>();

        var app = builder.Build();
        app.MapProductoEndpoints();
        app.MapHealthEndpoints();
        await app.StartAsync();

        var server = app.Services.GetRequiredService<IServer>();
        var address = server.Features.Get<IServerAddressesFeature>()!.Addresses.Single();
        return (app, new HttpClient { BaseAddress = new Uri(address) });
    }

    private sealed record HealthResponse(string Status);
}
