namespace TeamBuilder.Models
{
	public class Invintation
	{
		public Invintation()
		{
			this.IsActive = true;
		}
		public int Id { get; set; }
		public int InvitedUserId { get; set; }
		public User InvitedUser { get; set; }

		public int TeamId { get; set; }
		public Team Team { get; set; }
		public bool IsActive { get; set; }

	}
}
