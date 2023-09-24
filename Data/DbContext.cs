using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class CosmosDbContext : DbContext
{
	private readonly string _cosmosDbEndpoint;
	private readonly string _cosmosDbKey;
	private readonly string _databaseName;
	private readonly string _containerName;

	public CosmosDbContext(DbContextOptions<CosmosDbContext> options, IConfiguration configuration)
		: base(options)
	{
		_cosmosDbEndpoint = configuration.GetConnectionString("CosmosDbConnection");
		_cosmosDbKey = configuration["CosmosDbKey"];
		_databaseName = configuration["CosmosDbDatabaseName"];
		_containerName = configuration["CosmosDbContainerName"];
	}

	public DbSet<ApplicationForm> applicationform { get; set; }
	public DbSet<ApplicationForm> Preview { get; set; }
	public DbSet<ProgramDetails> programdetails { get; set; }
	public DbSet<Workflow> workflow { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultContainer(_containerName);
		modelBuilder.Entity<ApplicationForm>().ToContainer(_containerName);

		modelBuilder.HasDefaultContainer(_containerName);
		modelBuilder.Entity<Preview>().ToContainer(_containerName);

		modelBuilder.HasDefaultContainer(_containerName);
		modelBuilder.Entity<ProgramDetails>().ToContainer(_containerName);

		modelBuilder.HasDefaultContainer(_containerName);
		modelBuilder.Entity<Workflow>().ToContainer(_containerName);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseCosmos(
			_cosmosDbEndpoint,
			_cosmosDbKey,
			_databaseName);
	}
}
