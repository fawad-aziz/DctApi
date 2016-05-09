using DctDomainModel;
using DctDomainModel.Model;
using System.Linq;

namespace PostgreSqlProvider
{
	public class PostgreSqlProvider : IDataAccessProvider
	{
		private readonly DctContext _context;

		public PostgreSqlProvider(DctContext context)
		{
			this._context = context;
		}

		public Dct GetDct(int id)
		{
			return this._context.Dcts.First(t => t.Id == id);
		}

		public IQueryable<Dct> GetDcts()
		{
			return this._context.Dcts;
		}
	}
}
