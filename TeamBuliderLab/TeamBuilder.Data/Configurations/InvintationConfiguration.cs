namespace TeamBuilder.Data.Configurations
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Infrastructure.Annotations;
	using TeamBuilder.Models;
	using System.Data.Entity.ModelConfiguration;

	class InvintationConfiguration: EntityTypeConfiguration<Invintation>
	{
		public InvintationConfiguration()
		{
			
		}
	}
}
