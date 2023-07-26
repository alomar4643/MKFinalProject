using Microsoft.EntityFrameworkCore;
using MortalKombatDB.Data;

namespace MortalKombatDB
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<MortalKombatDBContext>();

			var app = builder.Build();


			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();


			// Query DataBase using RawSQL

			app.MapGet("SQLQuery", (MortalKombatDBContext _ctx) =>
			{
				String query = "SELECT Name,Description, IsFatality FROM Moves";

				List<SQLQuery> queries = _ctx.SQLQueries
										 .FromSqlRaw(query)
										 .ToList();



				return Results.Ok(queries);
			});
			//Ask if this needs to be asynchinous and if so, how 

			app.Run();
		}
	}
}