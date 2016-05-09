using DctDomainModel.Model;
using System.Linq;

namespace DctDomainModel
{
	public interface IDataAccessProvider
	{
		IQueryable<Dct> GetDcts();

		Dct GetDct(int id);
	}
}