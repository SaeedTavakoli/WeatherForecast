using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Base
{
    public interface IEntity
    {
        bool IsDeleted { get; set; }

        string IsDeletedUserId { get; set; }

        DateTime? IsDeletedDate { get; set; }

        string UpdateUserId { get; set; }

        DateTime? UpdateDate { get; set; }

        string CreateUserId { get; set; }

        DateTime? CreateDate { get; set; }
    }

    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
    }

    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        protected BaseEntity()
        {
        }

        public virtual TKey Id { get; set; }

        //---------------------------------------------------
        [JsonIgnore]
        [DefaultValue(false)]
        public virtual bool IsDeleted { get; set; } = false;

        [JsonIgnore]
        [MaxLength(450)]
        public virtual string IsDeletedUserId { get; set; }

        [JsonIgnore]
        public virtual DateTime? IsDeletedDate { get; set; }

        //----------------------------------------------------
        [JsonIgnore]
        [MaxLength(450)]
        public virtual string UpdateUserId { get; set; }

        [JsonIgnore]
        public virtual DateTime? UpdateDate { get; set; }

        //-----------------------------------------------------
        [JsonIgnore]
        [MaxLength(450)]
        public virtual string CreateUserId { get; set; }

        [JsonIgnore]
        public virtual DateTime? CreateDate { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
