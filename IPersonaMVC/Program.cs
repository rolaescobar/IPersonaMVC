using IPersonaMVC.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Registrar ApplicationDbContext con la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonaDBConnection")));

// Agregar controladores y vistas
builder.Services.AddControllersWithViews();

// Habilitar sesiones
builder.Services.AddSession();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitar autorización
app.UseAuthorization();

// Habilitar sesiones
app.UseSession();

// Cambiar la ruta predeterminada a Auth/Login
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
