using System.ComponentModel.DataAnnotations;

namespace RH.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createAt;

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.Now : value); }
        }

        private DateTime? _updateAt;

        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }

        public void CreateDate(DateTime create)
        {
            CreateAt = create;
        }

        public void AtribuirId(Guid id)
        {
            Id = id;
        }
    }
}
