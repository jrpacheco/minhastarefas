using System.Collections.Generic;

namespace Entity
{
    public class Retorno
    {
        public Retorno()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public dynamic Objeto { get; set; }
    }
}
