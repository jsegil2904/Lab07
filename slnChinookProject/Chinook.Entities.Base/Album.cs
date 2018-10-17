namespace Chinook.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("Album")]
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
        //    Track = new HashSet<Track>();
        }

        public int AlbumId { get; set; }

        [DataMember]
        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        [DataMember]
        public int ArtistId { get; set; }

        [DataMember]
        public virtual Artist Artist { get; set; }

       // [DataMember]
       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       // public virtual ICollection<Track> Track { get; set; }
    }
}
