﻿using DataAccessLayer.Abstract;
using DataAccessLayer.concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramwork
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c = new MyConnectionDbContext())
            {
                return  c.Blogs.Include(x=> x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new MyConnectionDbContext())
            {
                return c.Blogs.Include(x => x.Category).Where(x=>x.UserID==id ).ToList();
            }
        }
    }
}
