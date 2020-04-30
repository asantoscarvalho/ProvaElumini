using System;
using Xunit;
using ProjetoContato.Repository.Interface;
using ProjetoContato.Domain.Model;
using System.Collections.Generic;
using AutoMapper;
using ProjetoContato.Domain.Dtos;
using ProjetoContato.Repository;
using ProjetoContato.Repository.Contexts;
using ProjetoContato.Api.Controllers;
using System.Threading.Tasks;
using System.Net;

namespace ProjetoContato.Test
{
    public class ContatoControllerTest
    {
 
        [Fact]
        public async Task Test_Get()
        {
            using(var cliente = new TestClientProvider().Client)
            {

                var response = await cliente.GetAsync("/api/contato");


                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }




    }
}
