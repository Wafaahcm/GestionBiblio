using FluentValidation;
using JITCATALOG.APPLICATION.Contracts.Book.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Commands.Create
{
        public class CreateBookValidator : AbstractValidator<CreateBookCommand>
        {
            public CreateBookValidator()
            {
                RuleFor(p => p.Titre)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(100);

                RuleFor(p => p.NombrePage)
                        .NotEmpty()
                        .NotNull();

                RuleFor(p => p.Isbn)
                        .NotEmpty()
                        .NotNull().MaximumLength(20);

            }
        }
    
}
