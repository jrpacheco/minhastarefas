using Entity.Tarefa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ListaTarefa
{
    public class ListaTarefaEntity
    {
        [Key]
        public int Id { get; set; }

        public int IdLista { get; set; }

        public int IdTarefa { get; set; }        

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }
    }
}
