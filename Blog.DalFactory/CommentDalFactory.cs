﻿using Blog.DAL;
using Blog.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DalFactory
{
    public class CommentDalFactory
    {
        public static ICommentDal GetCommentDal()
        {
            return new CommentDal();
        }
    }
}
