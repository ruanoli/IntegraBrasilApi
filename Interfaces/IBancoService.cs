using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Interfaces
{
    public interface IBancoService
    {
    Task<ResponseGenerico<List<BancoResponse>>> BuscarTodosBancos();
        Task<ResponseGenerico<BancoResponse>> BuscarBancoPorCodigo(string codigoBanco);
    }
}