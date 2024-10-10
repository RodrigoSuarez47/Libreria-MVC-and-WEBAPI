
using DTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesRepositorios;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Web_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //TipoMovimiento
            builder.Services.AddScoped <ICUListar<TipoMovimientoDTO>, CUListarTiposMovimientosDTO>();
            builder.Services.AddScoped <ICUBuscarPorId<TipoMovimientoDTO>, CUBuscarTipoMovimientoPorId>();
            builder.Services.AddScoped <ICUModificar<TipoMovimientoDTO>, CUModificarTipoMovimientoDTO>(); 
            builder.Services.AddScoped <ICUBaja, CUBajaTipoMovimientoDTO>(); 
            builder.Services.AddScoped <ICUAlta<TipoMovimientoDTO>, CUAltaTipoMovimientoDTO>();

            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimiento>();

            //Usuario
            builder.Services.AddScoped<ICULoginUsuario, CULoginUsuario>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();

            //Articulo
            
            builder.Services.AddScoped<ICUListar<ArticuloDTO>, CUListarArticulosDTO>();
            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();

            //MovimientoStock 
            builder.Services.AddScoped<ICUAlta<MovimientoStockDTO>, CUAltaMovimientoStockDTO>(); 
            builder.Services.AddScoped<ICUBuscarPorId<MovimientoStockDTO>, CUBuscarMovimientoStockPorId>();
            builder.Services.AddScoped<ICUListar<MovimientoStockDTO>, CUListarMovimientosDTO>();
            builder.Services.AddScoped<ICUObtenerMovimientosPorArticuloYTipo, CUObtenerMovimientosPorArticuloYTipo>();
            builder.Services.AddScoped<ICUObtenerMovimientosPorRangoDeFechas, CUObtenerMovimientosPorRangoDeFechas>();
            builder.Services.AddScoped<ICUObtenerResumenMovimientos, CUObtenerResumenMovimientos>();
            builder.Services.AddScoped<ICUObtenerCantidadPaginas, CUObtenerCantidadPaginas>();
            builder.Services.AddScoped<IRepositorioMovimientosStock, RepositorioMovimientoStock>();

            // Add services to the container.
            string strCon = builder.Configuration.GetConnectionString("ConexionRodrigo");
            builder.Services.AddDbContext<DepositoContext>(options => options.UseSqlServer(strCon));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Token
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut => {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut => {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
