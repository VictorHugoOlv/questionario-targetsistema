using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace QuestionarioTargetSistemas;

[JsonSerializable(typeof(List<Registro>))]
public partial class MyJsonContext : JsonSerializerContext
{ }

public class Faturamento
{
    private List<Registro> _lacamentos;

    public Faturamento()
    {
        _lacamentos = new List<Registro>();
        ObterLancamentos();
    }
    public List<Registro> ObterLancamentos()
    {
        var jsonLancamentos = File.ReadAllText("C:\\repo\\QuestionarioTargetSistemas\\QuestionarioTargetSistemas\\lancamentos.json");

        _lacamentos = JsonSerializer.Deserialize<List<Registro>>(jsonLancamentos, MyJsonContext.Default.ListRegistro);      

        return _lacamentos.ToList();    
    }
}

public class Registro
{
    public int dia { get; set; }
    public double valor { get; set; }
}