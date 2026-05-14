using FluentValidation;

public class RefundValidator : AbstractValidator<Game>
{
    public RefundValidator()
    {
        RuleFor(game => game)
            .NotNull()
            .WithMessage("Game tidak ditemukan");

        RuleFor(game => game.Status)
            .Equal(GameStatus.Owned)
            .When(game => game != null)
            .WithMessage("Refund hanya bisa diajukan untuk game yang sudah dimiliki");
    }
}
