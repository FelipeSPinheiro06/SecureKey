using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasswordGenerator;

namespace SecureKey.Pages;

public class KeyGeneratorModel : PageModel
{
    private readonly ILogger<KeyGeneratorModel> _logger;
    public string SenhaGerada {get; private set;} = string.Empty;

    public KeyGeneratorModel(ILogger<KeyGeneratorModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        SenhaGerada = string.Empty;
    }

    public IActionResult OnPostGerarSenha()
    {
        SenhaGerada = GerarSenhaSegura();
        return Page();
    }

    private string GerarSenhaSegura()
    {
        var securePassword = new Password();
        securePassword
            .IncludeLowercase()
            .IncludeUppercase()
            .IncludeNumeric()
            .IncludeSpecial()
            .LengthRequired(12);

        return securePassword.Next();
    }
}
