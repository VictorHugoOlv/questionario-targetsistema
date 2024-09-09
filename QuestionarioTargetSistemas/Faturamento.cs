using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuestionarioTargetSistemas;

[JsonSerializable(typeof(List<Venda>))]
public partial class DadosVendas : JsonSerializerContext
{ }

public class Faturamento
{
    public List<Venda>? TodasVendas { get; private set; }
        = [];

    public List<Venda>? VendasDiasUteis
        => TodasVendas?.Where(x => x.Valor > 0).ToList() ?? [];

    public Venda? MenorFaturamento
        => VendasDiasUteis?.First(x => x.Valor == VendasDiasUteis?.Min(x => x.Valor));

    public Venda? MaiorFaturamento
        => VendasDiasUteis?.First(x => x.Valor == VendasDiasUteis?.Max(x => x.Valor));

    public decimal? MediaFaturamentos
        => VendasDiasUteis?.Average(x => x.Valor);

    public int? QuantidadeVendasSuperiorMediaMes
        => VendasDiasUteis?.Count(x => x.Valor > MediaFaturamentos);

    public List<Venda>? VendasSuperiorMediaMes
        => VendasDiasUteis?.Where(x => x.Valor > MediaFaturamentos).ToList() ?? [];

    public Faturamento()
    {
        ObterVendas();
    }

    private void ObterVendas()
    {
        var jsonVendas = File.ReadAllText($@"{AppContext.BaseDirectory}\vendas.json");
        TodasVendas = JsonSerializer.Deserialize(jsonVendas, DadosVendas.Default.ListVenda);
    }
}

public class Venda
{
    [JsonPropertyName("dia")]
    public int Dia { get; set; }

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}