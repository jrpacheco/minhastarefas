using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Tarefa
{
    public class TarefaEntity
    {
        [Key]
        public int Id { get; set; }

        public int IdLista { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        public bool Importante { get; set; }

        public int Prioridade { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }
    }
}
