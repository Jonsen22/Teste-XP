using BackendTestXP.DTOs;
using System.Text.RegularExpressions;
using XPTesteAPI.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendTestXP.Services
{
    public class ClienteService
    {
        public static string VerificarCliente(string telefone)
        {
            string mensagem = "ok";

            if (telefone == null) 
                mensagem = "Telefone nulo";

            string telefoneTemp = telefone;
           
            Regex regex = new Regex(@"[^\d]");

            telefoneTemp = regex.Replace(telefoneTemp, "");

            if (!Regex.IsMatch(telefoneTemp, @"^55\d\d9")) 
                mensagem = "Telefone inválido";

            return mensagem;
        }
    }
}
