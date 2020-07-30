namespace UXDivers.Gorilla.Droid
{
	internal static class AssemblyGlobal
	{
		public const string Company = "UXDivers";

		public const string ProductLine = "Gorilla Player";

		public const string Year = "2017";

		public const string VersionBase = "1.5.5.0";

		public const string AssemblyVersion = VersionBase;// + ".*";

		public const string Copyright = Company + " - " + Year;

		#if DEBUG
		public const string Configuration = "Debug";
		#elif RELEASE
		public const string Configuration = "Release";
		#else
		public const string Configuration = "Unkown";
		#endif
	}	
}