using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vize.Dtos;
using vize.Models;

namespace vize.Controllers
{
    [Route("api/SurwaysQuestion")]
    [ApiController]
    public class SurwaysQuestionController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public SurwaysQuestionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<SurwaysQuestionDto> GetList()
        {
            var SurwaysQuestion = _context.SurwaysQuestion.ToList();
            var SurwaysQuestionDtos = _mapper.Map<List<SurwaysQuestionDto>>(SurwaysQuestion);
            return SurwaysQuestionDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public SurwaysQuestionDto Get(int id)
        {
            var surwaysquestion = _context.SurwaysQuestion.Where(s => s.Id == id).SingleOrDefault();
            var SurwaysQuestionDto = _mapper.Map<SurwaysQuestionDto>(surwaysquestion);
            return SurwaysQuestionDto;
        }
        [HttpGet]
        [Route("{id}/Surways")]
        public List<SurwayDto> GetSurways(int id)
        {
            var Surways = _context.surways.Where(s => s.SurwaysQuestionId == id).ToList();
            var surwayDtos = _mapper.Map<List<SurwayDto>>(Surways);
            return surwayDtos;
        }
        [HttpPost]
        public ResultDto Post(SurwaysQuestionDto dto)
        {
            if (_context.SurwaysQuestion.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Anket Soruları Adı Kayıtlıdır!";
                return result;
            }
            var surwaysquestion = _mapper.Map<SurwaysQuestion>(dto);
            surwaysquestion.Updated = DateTime.Now;
            surwaysquestion.Created = DateTime.Now;
            _context.SurwaysQuestion.Add(surwaysquestion);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Anket Soruları Eklendi";
            return result;
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ResultDto Put(SurwaysQuestionDto dto)
        {
            var surwaysquestion = _context.SurwaysQuestion.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (surwaysquestion == null)
            {
                result.Status = false;
                result.Message = "Anket Soruları Bulunamadı!";
                return result;
            }
            surwaysquestion.Name = dto.Name;
            surwaysquestion.IsActive = dto.IsActive;
            surwaysquestion.Updated = DateTime.Now;
            surwaysquestion.Response = dto.Response;

            _context.SurwaysQuestion.Update(surwaysquestion);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Anket Soruları Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public ResultDto Delete(int id)
        {
            var surwaysquestion = _context.SurwaysQuestion.Where(s => s.Id == id).SingleOrDefault();
            if (surwaysquestion == null)
            {
                result.Status = false;
                result.Message = "Anket Soruları Bulunamadı!";
                return result;
            }
            _context.SurwaysQuestion.Remove(surwaysquestion);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Anket Soruları Silindi";
            return result;
        }
    }
}
