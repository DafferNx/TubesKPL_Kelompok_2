using FluentValidation;

public class WalletValidator : AbstractValidator<int>
{
    public WalletValidator()
    {
        RuleFor(amount => amount)
            .GreaterThan(0)
            .WithMessage("Nominal harus lebih dari 0");
    }
}
