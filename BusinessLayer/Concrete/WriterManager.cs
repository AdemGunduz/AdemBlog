using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WriterManager : IWriterService
	{
		IWriterDal _writerdal;

		public WriterManager(IWriterDal writerdal)
		{
			_writerdal = writerdal;
		}

        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public object TGetById(int id)
        {
            return _writerdal.GetById(id);
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

        public void WriterAdd(Writer writer)
		{
			_writerdal.Insert(writer);
		}
	}
}
