using System.ComponentModel.DataAnnotations;

namespace CoreDomain.Entity
{

    public interface IEntity
    {
        object Id { get; set; }

        public byte IsDeleted { get; set; }
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

    }

    public abstract class BaseEntity<T> : IEntity
    {

        [Key]
        [Required]
        public T Id { get; set; }

        object IEntity.Id
        {
            get { return Id; }
            set { }
        }



        public byte IsDeleted { get; set; } = 0;

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

    }
}