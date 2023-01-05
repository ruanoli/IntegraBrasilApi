using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IntegraBrasilApi.Dtos;
using IntegraBrasilApi.Interfaces;
using IntegraBrasilApi.Models;

namespace IntegraBrasilApi.Rest
{
    public class BrasilApiRest : IBrasilApi
    {
        public async Task<ResponseGenerico<EnderecoModel>> BuscarApiPorCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            
            var response = new ResponseGenerico<EnderecoModel>();
            using(var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResponse);

                if(responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }

            return response;
        }

        public async Task<ResponseGenerico<BancoModel>> BuscarBancoPorCodigo(string codigo)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{codigo}");
            
            var response = new ResponseGenerico<BancoModel>();
            using(var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<BancoModel>(contentResponse);

                if(responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }

            return response;
        }

        public async Task<ResponseGenerico<List<BancoModel>>> BuscarTodosBancos()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1");
            
            var response = new ResponseGenerico<List<BancoModel>>();
            using(var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<BancoModel>>(contentResponse);

                if(responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }

            return response;  
        }
    }
}