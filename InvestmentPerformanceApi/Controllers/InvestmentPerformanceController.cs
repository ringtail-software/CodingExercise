using AutoMapper;
using InvestmentPerformanceApi.Data;
using InvestmentPerformanceApi.Dtos;
using InvestmentPerformanceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace InvestmentPerformanceApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class InvestmentPerformanceController : ControllerBase
    {
        private readonly IInvestmentPerformanceRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public InvestmentPerformanceController(IInvestmentPerformanceRepo repository,
            ILogger<InvestmentPerformanceController> logger,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("{userId:int}/investments")]
        public ActionResult<InvestmentsReadDto> GetInvestments(int userId)
        {
            try
            {
                var investmentItem = _repository.Get(userId);
                if (investmentItem != null)
                {
                    return Ok(_mapper.Map<InvestmentsReadDto>(investmentItem));
                }
                return NotFound();
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }


        [HttpGet("{userId:int}/investments/{investmentId:int}/investmentdetails", Name = "GetInvestmentDetails")]
        public ActionResult<InvestmentDetailsReadDto> GetInvestmentDetails(int userId, int investmentId)
        {
            try
            {
                var investmentDetails = _repository.GetDetails(userId, investmentId);
                if (investmentDetails != null)
                {
                    return Ok(_mapper.Map<InvestmentDetailsReadDto>(investmentDetails));
                }
                return NotFound();
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }

        }

        [Route("{userId:int}/investments/{investmentId:int}/investmentdetails")]
        [HttpPost]
        public ActionResult<InvestmentDetailsReadDto> Buy(InvestmentDetailsCreateDto investmentDetailsCreateDto)
        {
            var investModel = _mapper.Map<InvestmentDetails>(investmentDetailsCreateDto);
            _repository.Buy(investModel);
            //_repository.SaveChanges();

            var investReadDto = _mapper.Map<InvestmentDetailsReadDto>(investModel);

            return CreatedAtRoute(nameof(GetInvestmentDetails), new { investReadDto.InvestmentId }, investReadDto);
        }


        [Route("{userId:int}/investments/{investmentId:int}/investmentdetails")]
        [HttpPut]
        public ActionResult Update(int userId, int investmentId, InvestmentDetailsUpdateDto updateDto)
        {
            var investModel = _repository.GetDetails(userId, investmentId);
            if (investModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDto, investModel);

            _repository.Update(investModel);

            //_repository.SaveChanges();

            return NoContent();
        }

        [Route("{userId:int}/investments/{investmentId:int}/investmentdetails")]
        [HttpDelete]
        public ActionResult Sell(int userId, int investmentId)
        {
            var sell = _repository.GetDetails(userId, investmentId);
            if (sell == null)
            {
                return NotFound();
            }
            _repository.Sell(sell);
            //_repository.SaveChanges();

            return NoContent();
        }
    }
}
