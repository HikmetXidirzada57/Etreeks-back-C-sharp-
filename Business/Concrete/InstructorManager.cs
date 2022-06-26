using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorManager
    {
        IInstructerDal _dal;

        public InstructorManager(IInstructerDal dal)
        {
            _dal = dal;
        }

        public Task<Instructor> GetById(int? id)
        {
            return _dal.Get(x => !x.IsDeleted);
        }


        public async Task<IEnumerable<Instructor>> GetInstructors()
        {
            return await _dal.GetAll(x => !x.IsDeleted);

        }
    }
}
