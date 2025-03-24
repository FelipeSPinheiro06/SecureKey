using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecureKey.Pages;

public class KeyValidatorModel : PageModel
{
    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public string MensagemValidacao { get; private set; } = string.Empty;

    public bool IsSenhaValida { get; private set; }

    public IActionResult OnPostValidarSenha()
    {
        if (string.IsNullOrWhiteSpace(Password))
        {
            MensagemValidacao = "A senha não pode estar vazia.";
            IsSenhaValida = false;
        }
        else if (Password.Length < 8)
        {
            MensagemValidacao = "A senha deve conter pelo menos 8 caracteres.";
            IsSenhaValida = false;
        }
        else if (!Password.Any(char.IsUpper))
        {
            MensagemValidacao = "A senha deve conter pelo menos uma letra maiúscula.";
            IsSenhaValida = false;
        }
        else if (!Password.Any(char.IsLower))
        {
            MensagemValidacao = "A senha deve conter pelo menos uma letra minúscula.";
            IsSenhaValida = false;
        }
        else if (!Password.Any(char.IsDigit))
        {
            MensagemValidacao = "A senha deve conter pelo menos um número.";
            IsSenhaValida = false;
        }
        else if (!Password.Any(c => "!@#$%^&*".Contains(c)))
        {
            MensagemValidacao = "A senha deve conter pelo menos um caractere especial (!@#$%^&*).";
            IsSenhaValida = false;
        }
        else
        {
            MensagemValidacao = "Senha válida!";
            IsSenhaValida = true;
        }

        return Page();
    }
}
