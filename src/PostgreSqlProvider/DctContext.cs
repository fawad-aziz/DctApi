using System;
using System.Linq;
using DctDomainModel.Model;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace PostgreSqlProvider
{
	public class DctContext : DbContext
	{
		public DbSet<Dct> Dcts { get; set; }

		public DbSet<DctSection> DctSections { get; set; }

		public DbSet<DctField> DctFields { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Dct>().HasKey(m => m.Id);
			builder.Entity<DctSection>().HasKey(m => m.Id);
			builder.Entity<DctField>().HasKey(m => m.Id);

			// shadow properties
			builder.Entity<Dct>().Property<DateTime>("UpdatedTimestamp");
			builder.Entity<DctSection>().Property<DateTime>("UpdatedTimestamp");
			builder.Entity<DctField>().Property<DateTime>("UpdatedTimestamp");

			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder().AddJsonFile("../config.json").AddEnvironmentVariables();
			var configuration = builder.Build();

			var sqlConnectionString = configuration["DataAccessPostgreSqlProvider:ConnectionString"];

			optionsBuilder.UseNpgsql(sqlConnectionString);
		}

		public override int SaveChanges()
		{
			this.ChangeTracker.DetectChanges();

			this.UpdateUpdatedProperty<Dct>();
			this.UpdateUpdatedProperty<DctSection>();
			this.UpdateUpdatedProperty<DctField>();

			return base.SaveChanges();
		}

		private void UpdateUpdatedProperty<T>() where T : class
		{
			var modifiedSourceInfo =
				this.ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in modifiedSourceInfo)
			{
				entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
			}
		}
	}
}