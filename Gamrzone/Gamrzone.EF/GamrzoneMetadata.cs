using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gamrzone.EF
{
    #region Categories Metadata
    public class CategoryMetadata
    {
        [Display(Name = "Parent Category")]
        public Nullable<int> ParentID { get; set; }

        [Required]
        [StringLength(maximumLength: 30, ErrorMessage = "Name is too long. 30 characters maximum.")]
        public string Name { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "Description too long. 150 characters maximum.")]
        public string Description { get; set; }

        public bool IsLocked { get; set; }

        [Required]
        [Range(minimum:0, maximum:255)]
        public byte Permissions { get; set; }
    }
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {

    }
    #endregion

    #region Posts Metadata
    public class PostMetaData
    {
        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Topic")]
        public string Title { get; set; }

        public string Tags { get; set; }

        public string PContent { get; set; }

        [Display(Name = "Create an event?")]
        public Nullable<bool> IsEvent { get; set; }

        public bool IsLocked { get; set; }

        public byte Permissions { get; set; }
    }
    [MetadataType(typeof(PostMetaData))]
    public partial class Post
    {

    }
    #endregion

    #region Users Metadata
    public class UserMetadata
    {
        public long Steam { get; set; }
        public string Avatar { get; set; }

        [StringLength(maximumLength: 15, ErrorMessage = "Username is too long. 30 characters maximum.")]
        public string Username { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "To prevent from spam accounts we have limited emails to 50 characters.")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number should be digits only.")]
        public string Phone { get; set; }

        [Display(Name = "Group")]
        public Nullable<int> GroupID { get; set; }

        public byte Permissions { get; set; }

        public bool IsBanned { get; set; }
    }
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {

    }
    #endregion

    #region Roles Metadata
    public class RoleMetadata
    {
        [Display(Name = "Nickname")]
        public string RoleName { get; set; }

        [Required]
        [Range(minimum: 0, maximum:100, ErrorMessage = "Delegations must be 0-100")]
        public byte ViewPower { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Delegations must be 0-100")]
        public byte CreatePower { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Delegations must be 0-100")]
        public byte ModifyPower { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "Delegations must be 0-100")]
        public byte DeletePower { get; set; }
    }
    [MetadataType(typeof(RoleMetadata))]
    public partial class Role
    {

    }
    #endregion

    #region Events Metadata
    public class EventMetadata
    {

    }
    [MetadataType(typeof(EventMetadata))]
    public partial class Event
    {

    }
    #endregion
}
