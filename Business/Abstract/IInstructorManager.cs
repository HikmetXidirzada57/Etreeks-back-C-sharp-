﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInstructorManager
    {
        public Task<IEnumerable<Instructor>> GetInstructors();
        public Task<Instructor> GetById(int? id);
    }
}