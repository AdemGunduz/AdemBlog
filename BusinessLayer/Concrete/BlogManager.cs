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
	public class BlogManager : IBlogService
	{
		private readonly IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public void BlogAdd(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogRemove(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void BlogUpdate(Blog blog)
		{
			throw new NotImplementedException();
		}

        public List<Blog> GetBlogsWithCategoryByWriterBm()
        {
            return _blogDal.GetListWithCategory();	
        }

		public List<Blog> Test(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}

        public Blog TGetById(int id)
		{
			return _blogDal.GetById(id);
		}
		public List<Blog>GetBlogByID(int id)
		{
			return _blogDal.GetListAll(x=>x.BlogID== id);	
		}
		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();	
		}
		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListAll().Take(3).ToList();
		}
		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.UserID == id);
		}

        public void TAdd(Blog t)
        {
          _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
           _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
			_blogDal.Update(t);
        }

        public List<Blog> GetBlogsWithCategory()
        {
            throw new NotImplementedException();
        }
    }
}
