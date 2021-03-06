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

    // TBL_Lista
    public class TblListaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TblLista>
    {
        public TblListaConfiguration()
            : this("dbo")
        {
        }

        public TblListaConfiguration(string schema)
        {
            ToTable("TBL_Lista", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName(@"Nome").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(150);
            Property(x => x.Ativo).HasColumnName(@"Ativo").HasColumnType("bit").IsRequired();
            Property(x => x.DataAlteracao).HasColumnName(@"DataAlteracao").HasColumnType("datetime").IsRequired();
        }
    }

}
// </auto-generated>
