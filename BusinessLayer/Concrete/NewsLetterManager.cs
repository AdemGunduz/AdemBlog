using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetter _newsletterDal;

		public NewsLetterManager(INewsLetter newsletterDal)
		{
			_newsletterDal = newsletterDal;
		}

		public void NewsLetterAdd(NewsLetter newsletter)
		{
			_newsletterDal.Insert(newsletter);
		}
	}
}