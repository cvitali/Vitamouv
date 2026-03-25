using Vitamouv.Services.Emails;

var builder = WebApplication.CreateBuilder(args);

//attention: ports ajoutés par Render lors du déploiement mais emp^che le site de fonctionner en local en mode debug
// =>ajouter impérativement condition if (builder.Environment.IsProduction()) 
if (builder.Environment.IsProduction())
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

// Add services to the container.
builder.Services.AddControllersWithViews();

//injection de dépendance pour le service de messagerie
builder.Services.AddScoped<IEmailService, SendGridEmailService>();

var apiKey = builder.Configuration["SendGrid:ApiKey"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
