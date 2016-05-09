using System.Collections.Generic;

namespace DctDomainModel.Model
{
    public class DctSection
    {
		public int Id { get; set; }

		public int DctId { get; set; }

		public string Title { get; set; }

		public List<DctField> Fields { get; set; }
    }
}
