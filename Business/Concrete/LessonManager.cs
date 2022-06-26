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
    public class LessonManager : ILessonManager
    {
        ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public async Task<IEnumerable<Lesson>> GetLessons(int? lessonId)
        {
            return await _lessonDal.GetAll(x=>!x.IsDeleted);
        }
    }
}
