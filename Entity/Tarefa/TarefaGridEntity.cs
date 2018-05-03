using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Tarefa
{
    public class TarefaGridEntity
    {        
        public int Id { get; set; }

        public int IdLista { get; set; }

        [Display(Name = "Tarefa")]
        public string NomeTarefa { get; set; }

        [Display(Name = "Lista")]
        public string NomeLista { get; set; }

        public string Importante { get; set; }

        public int Prioridade { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DataAlteracao { get; set; }
    }
}
