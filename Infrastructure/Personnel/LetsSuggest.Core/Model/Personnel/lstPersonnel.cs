using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FluentValidation;
using FluentValidation.Attributes;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Common;
using LetsSuggest.Personnel.Core.Model.Enums;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    [Validator(typeof(PersonnelModelValidator))]
    public class LstPersonnel : BaseEntity
    {
        [Key]
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? ZipId { get; set; }
        public string Password { get; set; }
        public bool? IsLocked { get; set; } = false;
        public int? PhoneType { get; set; }
        public string Phone { get; set; }
        public bool? IsVerified { get; set; }
        public int LoginAttempt { get; set; }
        public Guid? GalleryId { get; set; }
        [ForeignKey("GalleryId")]
        public Gallery Gallery { get; set; }
        public IList<PersonnelBusinessUser> PersonnelBusinessUser { get; set; }
        public IList<PersonnelGroupMember> PersonnelGroupMembers { get; set; }
        public IList<PersonnelUserType> PersonnelUserTypes { get; set; }

        [NotMapped]
        public int? UserRole { get; set; }

    }
    public class PersonnelModelValidator : AbstractValidator<LstPersonnel>
    {
        public PersonnelModelValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required").When(p => p.UserID == 0);
            RuleFor(p => p.Email).NotNull().EmailAddress().WithMessage("Invalid email address");
            RuleFor(p => p.PersonnelGroupMembers).Must(collection => collection != null && collection.Any()).WithMessage("Atleat one group is required").When(p => p.UserRole != (int)PersonnelGroupType.PublicUser);
            //RuleFor(p => p.PersonnelBusinessUser).Must(collection => collection != null && collection.Any()).WithMessage("Atleat one business is required").When(p => p.UserRole != (int)PersonnelGroupType.PublicUser);
        }
    }

    public class lstPersonnelModel : LstPersonnel
    {
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }


    }
}
