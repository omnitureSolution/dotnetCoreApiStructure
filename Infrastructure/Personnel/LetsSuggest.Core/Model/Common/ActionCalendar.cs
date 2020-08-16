using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Attributes;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    [Validator(typeof(ActionCalendarModelValidator))]
    public class ActionCalendar :BaseEntity
    {
        public int ActioncalendarId { get; set; }

        public int? BusinessId { get; set; }

        public int? EventId { get; set;}
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }

        [ForeignKey("CreatedBy")]
        public LstPersonnel CreatedByName { get; set; }
        [ForeignKey("ModifiedBy")]
        public LstPersonnel ModifiedByName { get; set; }
    }

    public class ActionCalendarModelValidator : AbstractValidator<ActionCalendar>
    {
        public ActionCalendarModelValidator()
        {
            RuleFor(b => b.ActionDate).NotEmpty().WithMessage("Action Date is required");
        }
    }
}
