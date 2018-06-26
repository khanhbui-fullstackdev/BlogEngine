﻿using BlogEngine.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Service.IServices
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
    }
}
