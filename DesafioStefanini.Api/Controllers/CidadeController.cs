using AutoMapper;
using DesafioStefanini.Api.Dto;
using DesafioStefanini.Api.Services;
using DesafioStefanini.Api.Utils;
using DesafioStefanini.Domain.Entities;
using DesafioStefanini.Domain.Filters;
using DesafioStefanini.Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<Cidade> _validator;
        private readonly IUriService _uriService;   

        public CidadeController(ICidadeRepository repository,
                                IMapper mapper,
                                IValidator<Cidade> validator,
                                IUriService uriService)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _uriService = uriService;
        }


        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] PaginationFilter filter)
        { 
            try
            {
                string route = Request.Path.Value;

                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                List<CidadeDto> pagedData = _mapper.Map<List<CidadeDto>>(await _repository.GetAllPaged(validFilter));

                int totalRecords =  _repository.GetAll().Result.Count;

                PagedResponseResult<List<CidadeDto>> pagedResponse = PaginationHelper
               .CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);

                return Ok(pagedResponse);

            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseResult<CidadeDto> { Succeeded = false, Message = ex.Message });
            }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                CidadeDto cidade = _mapper.Map<CidadeDto>(await _repository.GetById(id));
                if (cidade == null) return NotFound(new ResponseResult<CidadeDto>
                {
                    Succeeded = false,
                    Message = "Não encontrado"
                });
                return Ok(new ResponseResult<CidadeDto>(cidade));
            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseResult<CidadeDto>
                {
                    Succeeded = false,
                    Message = ex.Message
                });
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CidadeDto cidadeDto)
        {
            try
            {
                if (cidadeDto == null) throw new ArgumentNullException(nameof(cidadeDto));

                Cidade cidade = _mapper.Map<Cidade>(cidadeDto);

                ValidationResult resultValidation = await _validator.ValidateAsync(cidade);

                if (!resultValidation.IsValid)
                {
                    return UnprocessableEntity(new ResponseResult<CidadeDto>
                    {
                        Succeeded = false,
                        Message = "Erro de validação!",
                        Errors = resultValidation.Errors
                    });
                }

                await _repository.Save(cidade);

                return Ok(new ResponseResult<CidadeDto>
                {
                    Succeeded = true,
                    Message = "Cadastro realizado com sucesso!",                
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult<CidadeDto>
                {
                    Succeeded = false,
                    Message = ex.Message
                });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CidadeDto cidadeDto, int id)
        {
            try
            {

                Cidade cidade = await _repository.GetById(id);

                if (cidade == null) return NotFound(new ResponseResult<CidadeDto>
                {
                    Succeeded = false,
                    Message = "Não encontrado"
                });
                
                cidade.Nome = cidadeDto.Nome;
                cidade.UF   = cidadeDto.UF;

                ValidationResult resultValidation = await _validator.ValidateAsync(cidade);

                if (!resultValidation.IsValid)
                {
                    return UnprocessableEntity(new ResponseResult<CidadeDto>
                    {
                        Succeeded = false,
                        Message = "Erro de validação!",
                        Errors = resultValidation.Errors
                    });
                }

                await _repository.Update(cidade);

                return Ok(new ResponseResult<CidadeDto>
                {
                    Succeeded = true,
                    Message = "Registro atualizado com sucesso!",
                    
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult<CidadeDto>
                {
                    Succeeded = false,
                    Message = ex.Message,
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if(await _repository.GetById(id) == null) return NotFound(new ResponseResult<CidadeDto>
                {
                    Succeeded = false,
                    Message = "Não encontrado"
                });

                await _repository.DeleteById(id);

                return Ok(new ResponseResult<CidadeDto>
                {
                    Succeeded = true,
                    Message = "Registro removido com sucesso!",
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseResult<CidadeDto>
                {
                    Succeeded = false,
                    Message = ex.Message,
                });
            }
           
          
        }

    }
}
