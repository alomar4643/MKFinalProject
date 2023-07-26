using Microsoft.EntityFrameworkCore;

namespace MortalKombatDB
{
	[Keyless]
	public class SQLQuery
	{

		public string Name { get; set; }

		public string Description { get; set; }

		public bool IsFatality { get; set; }

	}
}
