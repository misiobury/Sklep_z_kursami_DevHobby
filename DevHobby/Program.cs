//ten plik odpowiada za utworzenie instancji naszego programu,
//nie widac tutaj funkcji main bo domyslnie jest ukryta
//kazda aplikacja net core posiada wlasny serwer cestrel i jest niezalezna od innych czynnikow?

using DevHobby.Models;
using DevHobby.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); //parametr args dotyczy pliku appsetting.json

builder.Services.AddDbContext<DevHobbyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DevHobbyDbContextConnection"]);
});

builder.Services.AddControllersWithViews(); //tutaj dodajesz usluge controlera z widokami ktory umozliwia tworzenie projektu MVC
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();



var app = builder.Build();

//obsluga zadan przez ponizsze komponenty powoduje zwarcie zadania
////bo nie pozwala przejsc dalej zadaniu do kolejnego komponentu po obsludze przez wczesniejszy
//app.MapGet("/", () => "Hello World!");  //komponent oprogramowania posredniczacego middleware, ktore nasluchuje potoku zadan pipeline?
                                        //komponenty opr posr wprowadzamy pomiedzy build a app.run() i wazna jest kolejnosc!!!

app.UseStaticFiles();  //komponent od obslugi zadan plikow statycznych i po nadesciu zadania zajrzy on do folderu wwwroot

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  //pokazuje bledy
}

app.MapDefaultControllerRoute();

DbInitializer.Seed(app);

app.Run();


/*MVC
mODEL - zaweira danye  (klasy modelu danych)  ale tez i operacje przeprowadzane na tym danych - czyli tzw model logiczny ale tez i repozytoria
czyli klasy umozliwiajace prace z modelem danych



*/