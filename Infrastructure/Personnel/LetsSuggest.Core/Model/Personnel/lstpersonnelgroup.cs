using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Enums;

namespace LetsSuggest.Personnel.Core.Model.Personnel
{
    [Validator(typeof(PersonnelGroupModelValidator))]
    public class LstPersonnelGroup : BaseEntity
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int? BussinessId { get; set; }
        public PersonnelGroupType? GroupType { get; set; }
        public ICollection<PersonnelGroupMember> GroupMembers { get; set; }
        public ICollection<PersonnelGroupRight> GroupRights { get; set; }
    }
    public class PersonnelGroupModelValidator : AbstractValidator<LstPersonnelGroup>
    {
        public PersonnelGroupModelValidator()
        {
            RuleFor(p => p.GroupName).NotEmpty().WithMessage("Group Name is required");
        }
    }
}
