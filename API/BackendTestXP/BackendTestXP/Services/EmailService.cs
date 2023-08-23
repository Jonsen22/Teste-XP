using BackendTestXP.DTOs;
using System.Text.RegularExpressions;

namespace BackendTestXP.Services
{
    public class EmailService
    {
        public static string VerificarEmail(string email)
        {
            var mensagem = "ok";

            if (string.IsNullOrWhiteSpace(email))
                mensagem =  "Email nulo";

            // Regular expression pattern for validating an email address
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

             if(!Regex.IsMatch(email, pattern))
            {
                mensagem = "Email inválido";
            }

            return mensagem;
        }
    }
}
