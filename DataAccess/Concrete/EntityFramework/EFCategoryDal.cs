﻿using Core.Concrete.Entityframework;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class EFCategoryDal : EfEntityRepoBase<UdemyDbContext, Category>, ICategoryDal
    {

    } 
}
