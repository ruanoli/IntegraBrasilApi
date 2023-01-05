using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Interfaces;

namespace IntegraBrasilApi.Services
{
    public class BancoService : IBancoService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;
        public BancoService(IMapper mapper, IBrasilApi brasilApi)
        {   
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<List<BancoResponse>>> BuscarTodosBancos()
        {
            var bancos = await _brasilApi.BuscarTodosBancos();

            return _mapper.Map<ResponseGenerico<List<BancoResponse>>>(bancos);
        }
        public async Task<ResponseGenerico<BancoResponse>> BuscarBancoPorCodigo(string codigo)
        {
            var banco = await _brasilApi.BuscarBancoPorCodigo(codigo);

            return _mapper.Map<ResponseGenerico<BancoResponse>>(banco);
        }


    }
}