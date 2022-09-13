using AutoMapper;
using DesafioStefanini.Api.Dto;
using DesafioStefanini.Api.Services;
using DesafioStefanini.Api.Utils;
using DesafioStefanini.Domain.Entities;
using DesafioStefanini.Domain.Filters;
using DesafioStefanini.Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DesafioStefanini.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<Pessoa> _validator;
        private readonly IUriService _uriService;

        public PessoaController(IPessoaRepository repository,
                                IMapper mapper,
                                IValidator<Pessoa> validator,
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

                List<PessoaQueryDto> pagedData = 
                    _mapper.Map<List<PessoaQueryDto>>(
                        await _repository.GetPessoasWithCidadesPaged(validFilter));

                int totalRecords = _repository.GetAll().Result.Count;

                PagedResponseResult<List<PessoaQueryDto>> pagedResponse = PaginationHelper
                .CreatePagedReponse(pagedData, validFilter, totalRecords, _uriService, route);

                return Ok(pagedResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult<PessoaQueryDto>()
                {
                    Succeeded = false,
                    Message = ex.Message
                });
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                PessoaQueryDto pessoa = _mapper.Map<PessoaQueryDto>(await _repository.GetPessoaWithCidade(id));
                if (pessoa == null) return NotFound(new ResponseResult<PessoaQueryDto>()
                {
                    Succeeded = false,
                    Message = "Não encontrado!"
                }); ;
                return Ok(new ResponseResult<PessoaQueryDto>(pessoa));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult<PessoaQueryDto>()
                {
                    Succeeded = false,
                    Message = ex.Message
                });
            }

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PessoaDto pessoaDto)
        {
            try
            {
                if (pessoaDto == null) throw new ArgumentNullException();

                var pessoa = _mapper.Map<Pessoa>(pessoaDto);

                 ValidationResult resultValidation = await _validator.ValidateAsync(pessoa);

                if (!resultValidation.IsValid)
                {
                    return UnprocessableEntity(new ResponseResult<PessoaDto>()
                    {
                        Succeeded = false,
                        Message =  "Erros na validação",
                        Errors = resultValidation.Errors
                    });
                }

                await _repository.Save(pessoa);

                return Ok(new ResponseResult<PessoaDto>()
                {
                    Succeeded = true,
                    Message = "Registro realizado com sucesso!"
                });;

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult<PessoaDto>()
                {
                    Succeeded = false,
                    Message = ex.Message
                });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] PessoaDto pessoaDto, int id)
        {
            try
            {
                Pessoa pessoa = await _repository.GetById(id);

                if(pessoa == null) return NotFound(new ResponseResult<PessoaDto>()
                {
                    Succeeded = false,
                    Message = "Não encontrado!"
                });

                pessoa.Cpf = pessoaDto.Cpf;
                pessoa.Nome = pessoaDto.Nome;
                pessoa.Idade = pessoaDto.Idade;
                pessoa.Id_Cidade = pessoaDto.Id_Cidade;


                ValidationResult resultValidation = await _validator.ValidateAsync(pessoa);

                if (!resultValidation.IsValid)
                {
                    return UnprocessableEntity(new ResponseResult<PessoaDto>()
                    {
                        Succeeded = false,
                        Message = "Erro na validação",
                        Errors = resultValidation.Errors
                    });
                }

                await _repository.Update(pessoa);

                return Ok(new ResponseResult<PessoaDto>()
                {
                    Succeeded = true,
                    Message = "Registro atualizado com sucesso!"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult<PessoaDto>()
                {
                    Succeeded = false,
                    Message = ex.Message
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if (await _repository.GetById(id) == null) return NotFound(new ResponseResult<PessoaDto>()
                {
                    Succeeded = false,
                    Message = "Não encontrado!"
                });

                await _repository.DeleteById(id);

                return Ok(new ResponseResult<PessoaDto>()
                {
                    Succeeded = true,
                    Message = "Registro removido com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult<PessoaDto>()
                {
                    Succeeded = false,
                    Message = ex.Message
                });
            }


        }
    }
}
