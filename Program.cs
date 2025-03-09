
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using RestAPI_SamiHarun_Net24.Models;
using RestAPI_SamiHarun_Net24.Models.Data;


namespace RestAPI_SamiHarun_Net24
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var client = new HttpClient();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CvDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Endpoint: Hämta alla personer
            app.MapGet("/persons", async (CvDBContext db) =>
            {
                return Results.Ok(await db.Personer.ToListAsync());
            });

            // Endpoint: Hämta en person med ID
            app.MapGet("/persons/{id}", async (CvDBContext db, int id) =>
            {
                var person = await db.Personer.FindAsync(id);
                return person is not null ? Results.Ok(person) : Results.NotFound("Personen hittades inte.");
            });

            // Endpoint: Lägg till en person
            app.MapPost("/persons", async (CvDBContext db, Person person) =>
            {
                db.Personer.Add(person);
                await db.SaveChangesAsync();
                return Results.Created($"/persons/{person.Id}", person);
            });

            // Endpoint: Uppdatera en person
            app.MapPut("/persons/{id}", async (CvDBContext db, int id, Person updatedPerson) =>
            {
                var person = await db.Personer.FindAsync(id);
                if (person is null) return Results.NotFound("Personen hittades inte.");

                person.Namn = updatedPerson.Namn;
                person.Beskrivning = updatedPerson.Beskrivning;
                person.KontaktInfo = updatedPerson.KontaktInfo;

                await db.SaveChangesAsync();
                return Results.Ok(person);
            });

            // Endpoint: Ta bort en person
            app.MapDelete("/persons/{id}", async (CvDBContext db, int id) =>
            {
                var person = await db.Personer.FindAsync(id);
                if (person is null) return Results.NotFound("Personen hittades inte.");

                db.Personer.Remove(person);
                await db.SaveChangesAsync();
                return Results.Ok("Personen har tagits bort.");
            });


            // Endpoint för att hämta GitHub-repositories
            app.MapGet("/github/{username}", async (string username) =>
            {
                var url = $"https://api.github.com/users/{username}/repos";

                // GitHub kräver en User-Agent header
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("User-Agent", "MinimalAPI");

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return Results.NotFound($"Kunde inte hitta GitHub-repositories för användare: {username}");
                }

                var repositories = await response.Content.ReadFromJsonAsync<List<GitHubRepo>>();

                return Results.Ok(repositories);
            });

            // Endpoint: Hämta alla utbildningar
            app.MapGet("/utbildningar", async (CvDBContext db) =>
            {
                return Results.Ok(await db.Utbildningar.ToListAsync());
            });

            // Endpoint: Hämta en utbildning via ID
            app.MapGet("/utbildningar/{id}", async (CvDBContext db, int id) =>
            {
                var utbildning = await db.Utbildningar.FindAsync(id);
                return utbildning is not null ? Results.Ok(utbildning) : Results.NotFound("Utbildningen hittades inte.");
            });

            // Endpoint: Lägg till en ny utbildning
            app.MapPost("/utbildningar", async (CvDBContext db, Utbildning utbildning) =>
            {
                db.Utbildningar.Add(utbildning);
                await db.SaveChangesAsync();
                return Results.Created($"/utbildningar/{utbildning.Id}", utbildning);
            });

            // Endpoint: Uppdatera en utbildning
            app.MapPut("/utbildningar/{id}", async (CvDBContext db, int id, Utbildning updatedUtbildning) =>
            {
                var utbildning = await db.Utbildningar.FindAsync(id);
                if (utbildning is null) return Results.NotFound("Utbildningen hittades inte.");

                utbildning.Skola = updatedUtbildning.Skola;
                utbildning.Examen = updatedUtbildning.Examen;
                utbildning.StartDatum = updatedUtbildning.StartDatum;
                utbildning.SlutDatum = updatedUtbildning.SlutDatum;

                await db.SaveChangesAsync();
                return Results.Ok(utbildning);
            });

            // Endpoint: Ta bort en utbildning
            app.MapDelete("/utbildningar/{id}", async (CvDBContext db, int id) =>
            {
                var utbildning = await db.Utbildningar.FindAsync(id);
                if (utbildning is null) return Results.NotFound("Utbildningen hittades inte.");

                db.Utbildningar.Remove(utbildning);
                await db.SaveChangesAsync();
                return Results.Ok("Utbildningen har tagits bort.");
            });

            // Endpoint: Hämta all arbetserfarenhet
            app.MapGet("/erfarenheter", async (CvDBContext db) =>
            {
                return Results.Ok(await db.Erfarenheter.ToListAsync());
            });

            // Endpoint: Hämta en arbetserfarenhet via ID
            app.MapGet("/erfarenheter/{id}", async (CvDBContext db, int id) =>
            {
                var erfarenhet = await db.Erfarenheter.FindAsync(id);
                return erfarenhet is not null ? Results.Ok(erfarenhet) : Results.NotFound("Erfarenheten hittades inte.");
            });

            // Endpoint: Lägg till en ny arbetserfarenhet
            app.MapPost("/erfarenheter", async (CvDBContext db, Erfarenhet erfarenhet) =>
            {
                db.Erfarenheter.Add(erfarenhet);
                await db.SaveChangesAsync();
                return Results.Created($"/erfarenheter/{erfarenhet.Id}", erfarenhet);
            });

            // Endpoint: Uppdatera en arbetserfarenhet
            app.MapPut("/erfarenheter/{id}", async (CvDBContext db, int id, Erfarenhet updatedErfarenhet) =>
            {
                var erfarenhet = await db.Erfarenheter.FindAsync(id);
                if (erfarenhet is null) return Results.NotFound("Erfarenheten hittades inte.");

                erfarenhet.JobTitel = updatedErfarenhet.JobTitel;
                erfarenhet.Företag = updatedErfarenhet.Företag;
                erfarenhet.År = updatedErfarenhet.År;

                await db.SaveChangesAsync();
                return Results.Ok(erfarenhet);
            });

            // Endpoint: Ta bort en arbetserfarenhet
            app.MapDelete("/erfarenheter/{id}", async (CvDBContext db, int id) =>
            {
                var erfarenhet = await db.Erfarenheter.FindAsync(id);
                if (erfarenhet is null) return Results.NotFound("Erfarenheten hittades inte.");

                db.Erfarenheter.Remove(erfarenhet);
                await db.SaveChangesAsync();
                return Results.Ok("Erfarenheten har tagits bort.");
            });



            app.Run();


        }
    }
}
