using System.ComponentModel.DataAnnotations;

namespace Projetos.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
