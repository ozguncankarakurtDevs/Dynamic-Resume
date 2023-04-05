using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfAboutDal : GenericRepository<About>, IAboutDal//IAboutDal crud dışında ayrı bir işlem gerçekleştirmek gerekirse ve sadece ilgili entitye ait olması gerekirse diye yazıldı.
	{
	}
}
