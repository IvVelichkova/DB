namespace TeamBuilder.Data.Configurations
{

	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Infrastructure.Annotations;
	using TeamBuilder.Models;
	using System.Data.Entity.ModelConfiguration;
	class TeamConfiguration: EntityTypeConfiguration<Team>
	{
		public TeamConfiguration()
		{
			this.Property(n => n.Name).IsRequired().HasMaxLength(25);

			this.Property(n => n.Descrition).HasMaxLength(30);
			this.Property(n => n.Acronym).HasMaxLength(3).IsFixedLength();
		}
	}
}
