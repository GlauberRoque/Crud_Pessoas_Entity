using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaEntity.model
{
    public class Email
    {
        public int id { get; set; }
        public string email { get; set; }

        public virtual Pessoa pessoa { get; set; } //link de email com pessoa, vai gerar uma FK no banco de dados
    }
}
