namespace Menetrend.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
        public string AkcioCollectionName { get; set; } = null!;
        public string AllomasCollectionName { get; set; } = null!;
        public string JaratCollectionName { get; set; } = null!;
        public string JegyCollectionName { get; set; } = null!;
        public string UtasCollectionName { get; set; } = null!;
        public string VarosCollectionName { get; set; } = null!;
        public string VonatCollectionName { get; set; } = null!;
    }
}
