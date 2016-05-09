namespace DctDomainModel.Model
{
    public class DctField
    {
		public int Id { get; set; }

		public int DctSectionId { get; set; }

		public string Name { get; set; }

		public bool Required { get; set; }

		public bool ReadOnly { get; set; }

		public string Value { get; set; }
    }
}
