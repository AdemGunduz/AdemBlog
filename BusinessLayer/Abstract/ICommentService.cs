﻿using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public  interface ICommentService
	{
		void CommentAdd(Comment comment);

		//void CategoryRemove(Category category);

		//void CategoryUpdate(Category category);

		List<Comment> GetList(int id);

		void Delete(Comment t);

		//Category GetById(int id);
	}
}
