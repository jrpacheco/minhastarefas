using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.Lista
{
    public class ListaEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Data de Alteração")]             
        public DateTime DataAlteracao { get; set; }
    }
}
