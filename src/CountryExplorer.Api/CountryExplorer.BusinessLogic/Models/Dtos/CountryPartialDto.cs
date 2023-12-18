﻿namespace CountryExplorer.BusinessLogic.Models.Dtos
{
	public record CountryPartialDto
	{
		public string Name { get; set; }
		public string Capital { get; set; }
		public string Currency { get; set; }
		public string Language { get; set; }
		public string Region { get; set; }
	}
}
