using FluentValidation;
using Lead.Management.Domain.Models;
using System.Text.RegularExpressions;

namespace Lead.Management.Domain.Validations
{
    public class ClientValidation : AbstractValidator<InviteCreateModel>
    {
        public ClientValidation()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .Length(3, 30);

            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.PhoneNumber)
           .NotEmpty()
           .NotNull()
           .MinimumLength(10).WithMessage("Número de telefone não pode ser menor que 10 digitos.")
           .MaximumLength(20).WithMessage("Número de telefone não pode ter mais 20 digitos.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Suburb)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Category)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty();
        }        
    }
}
