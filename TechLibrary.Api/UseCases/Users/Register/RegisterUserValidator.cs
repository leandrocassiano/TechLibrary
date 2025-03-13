using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator() 
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(request => request.Email).EmailAddress().WithMessage("O email é obrigatório.");
            When(request => string.IsNullOrEmpty(request.Password), () =>
            {
                RuleFor(request => request.Password).NotEmpty().WithMessage("A senha deve ter mais que 6 caracteres.");
            });
        }
        
    }
}
