using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MinimalJWT.Models;
using MinimalJWT.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.MapGet("/", () => "Hello, World!");
app.MapPost("/create", (Movie movie, IMovieService service) => Create(movie, service));
app.MapGet("/get", (int id, IMovieService service) => Get(id, service));
app.MapGet("/list", (IMovieService service) => List(service));
app.MapPut("/update", (Movie newMovie, IMovieService service) => Update(newMovie, service));
app.MapDelete("/delete", (int id, IMovieService service) => Delete(id, service));

IResult Create(Movie movie, IMovieService service)
{
    var result = service.Create(movie);
    return Results.Ok();
}

IResult Get(int id, IMovieService service)
{
    var movie = service.Get(id);
    if (movie is null)
        return Results.NotFound("Movie not found.");
    return Results.Ok(movie);
}

IResult List(IMovieService service)
    => Results.Ok(service.List());

IResult Update(Movie newMovie, IMovieService service)
{
    var updatedMovie = service.Update(newMovie);
    if (updatedMovie is null)
    {
        return Results.NotFound("Movie not found.");
    }

    return Results.Ok();
}

IResult Delete(int id, IMovieService service)
{
    var result = service.Delete(id);
    if (!result)
        return Results.BadRequest("Something went wrong.");

    return Results.Ok(result);
}

app.Run();