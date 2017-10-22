using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using ClientesWebApp.Models;

namespace ClientesWebApp.Models
{
    public class ClienteDAO
    {
        //creamos el cliente para acceder al servicio web
        // y crear peticiones tanto get, post, delete o put

        //y se agrega la url del servicio
        RestClient client = new RestClient("http://localhost:55681/api/");

        public List<Cliente> ListadoClientes()
        {
            //creamos una peticion de tipo get que apunte a http://localhost:55681/api/clientes
            RestRequest request = new RestRequest("clientes", Method.GET);

            //obtnemos un list de clientes a partir del request anterior 
            IRestResponse<List<Cliente>> response = client.Execute<List<Cliente>>(request);

            return response.Data;
        }


        public bool AgregarCliente(Cliente cliente)
        {
            RestRequest request = new RestRequest("clientes", Method.POST);

            IRestResponse response = client.Execute(request);

            // si el error es 500 significa qie ocurrio un error al crear el cliente
            if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                return false;
            }

            if(response.StatusCode  == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

    }
}