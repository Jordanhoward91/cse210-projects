using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EternalQuest
{
	public class SaveData
	{
		[JsonInclude]
		public List<Goal> Goals { get; set; }

		[JsonInclude]
		public int UserScore { get; set; }
	}
}
