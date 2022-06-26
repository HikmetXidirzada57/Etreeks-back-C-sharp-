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
    public class LessonVideoManager : ILessonVideoManager
    {
        ILessonVideoDal _lessonVideoDal;

        public LessonVideoManager(ILessonVideoDal lessonVideoDal)
        {
            _lessonVideoDal = lessonVideoDal;
        }
        public async Task<IEnumerable<LessonVideo>> GetLessonVideos(int? lessonId)
        {
            if (lessonId == null) return null;

            return await _lessonVideoDal.GetAll(x => x.LessonId ==lessonId);
        }
    }
}
