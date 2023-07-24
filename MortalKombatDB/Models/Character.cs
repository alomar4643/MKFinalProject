using System.Text.Json.Serialization;

namespace MortalKombatDB.Models
{
	public class Character
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
		//[JsonIgnore]
		//public List<Move>? Moves { get; set; }

	}
}
