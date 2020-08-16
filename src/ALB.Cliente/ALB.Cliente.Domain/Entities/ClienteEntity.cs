using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Flunt.Validations;

namespace ALB.Cliente.Domain.Entities
{
    [Table("Cliente")]
    public class ClienteEntity : Entity<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new Guid Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }
        public int Idade { get; set; }
        public override void Validate()
        {
            AddNotifications(
                new Contract()
                .IsNotNullOrEmpty(Nome,"Nome", "Informe o nome do Cliente.")
                .AreNotEquals(Id, Guid.Parse("00000000-0000-0000-0000-000000000000"), "Id", "Id do cliente não informado.")
            );
        }
    }
}
