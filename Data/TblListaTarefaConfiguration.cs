// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data
{

    // TBL_Lista_Tarefa
    public class TblListaTarefaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TblListaTarefa>
    {
        public TblListaTarefaConfiguration()
            : this("dbo")
        {
        }

        public TblListaTarefaConfiguration(string schema)
        {
            ToTable("TBL_Lista_Tarefa", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdLista).HasColumnName(@"IdLista").HasColumnType("int").IsRequired();
            Property(x => x.IdTarefa).HasColumnName(@"IdTarefa").HasColumnType("int").IsRequired();
            Property(x => x.DataAlteracao).HasColumnName(@"DataAlteracao").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.TblLista).WithMany(b => b.TblListaTarefas).HasForeignKey(c => c.IdLista).WillCascadeOnDelete(false); // FK_TBL_Lista_Tarefa_Lista
            HasRequired(a => a.TblTarefa).WithMany(b => b.TblListaTarefas).HasForeignKey(c => c.IdTarefa).WillCascadeOnDelete(false); // FK_TBL_Lista_Tarefa_Tarefa
        }
    }

}
// </auto-generated>
