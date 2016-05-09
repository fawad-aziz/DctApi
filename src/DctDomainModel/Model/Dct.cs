using System.Collections.Generic;

namespace DctDomainModel.Model
{
    public class Dct
    {
		public int Id { get; set; }

		public string Name { get; set; }

		public List<DctSection> Sections { get; set; }
    }
}
