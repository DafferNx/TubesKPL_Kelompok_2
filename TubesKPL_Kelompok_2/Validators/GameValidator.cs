using FluentValidation;

public class GameValidator : AbstractValidator<Game>
{
    public GameValidator()
    {
        RuleFor(game => game.Id)
            .GreaterThan(0)
            .WithMessage("Id game harus lebih dari 0");

        RuleFor(game => game.Name)
            .NotEmpty()
            .WithMessage("Nama game tidak boleh kosong");

        RuleFor(game => game.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Harga game tidak boleh negatif");
    }
}
