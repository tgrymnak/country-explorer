namespace CountryExplorer.BusinessLogic.Constants
{
	internal struct StatusCode
	{
		public static StatusCode Status200OK => new(200);
		public static StatusCode Status400BadRequest => new(400);
		public static StatusCode Status401Unauthorized => new(401);
		public static StatusCode Status404NotFound => new(404);
		public static StatusCode Status500InternalServerError => new(500);

		private int Value { get; set; }

		private StatusCode(int code)
		{
			Value = code;
		}

		public static implicit operator string(StatusCode value)
		{
			return value.ToString();
		}

		public static implicit operator int(StatusCode value)
		{
			return value.Value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
