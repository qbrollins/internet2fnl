using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vize.Dtos;
using vize.Models;

namespace vize.Controllers
{
    [Route("api/surways")]
    [ApiController]
    public class SurwaysController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public SurwaysController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<SurwayDto> GetList()
        {
            var surways = _context.surways.ToList();
            var surwayDtos = _mapper.Map<List<SurwayDto>>(surways);
            return surwayDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public SurwayDto Get(int id)
        {
            var surway = _context.surways.Where(s => s.Id == id).SingleOrDefault();
            var SurwayDto = _mapper.Map<SurwayDto>(surway);
            return SurwayDto;
        }

        [HttpPost]
        public ResultDto Post(SurwayDto dto)
        {
            if (_context.surways.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Anket Adı Kayıtlıdır!";
                return result;
            }
            var surway = _mapper.Map<Surway>(dto);
            surway.Updated = DateTime.Now;
            surway.Created = DateTime.Now;
            _context.surways.Add(surway);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Anket Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(SurwayDto dto)
        {
            var surway = _context.surways.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (surway == null)
            {
                result.Status = false;
                result.Message = "Anket Bulunamadı!";
                return result;
            }
            surway.Name = dto.Name;
            surway.IsActive = dto.IsActive;
            surway.Description = dto.Description;
            surway.Updated = DateTime.Now;
            surway.SurwaysQuestionId = dto.SurwaysQuestionId;
            _context.surways.Update(surway);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Anket Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var surway = _context.surways.Where(s => s.Id == id).SingleOrDefault();
            if (surway == null)
            {
                result.Status = false;
                result.Message = "Anket Bulunamadı!";
                return result;
            }
            _context.surways.Remove(surway);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Anket Silindi";
            return result;
        }
    }
}
