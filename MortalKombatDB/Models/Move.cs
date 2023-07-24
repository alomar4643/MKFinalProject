﻿using System.Text.Json.Serialization;

namespace MortalKombatDB.Models
{
	public class Move
	{

		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public bool IsFatality { get; set; }
		//[JsonIgnore]
		//public List<Character>? characters { get; set; }
	}
}
