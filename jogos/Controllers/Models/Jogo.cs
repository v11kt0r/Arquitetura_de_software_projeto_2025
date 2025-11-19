namespace jogos.Models;

public class Jogo
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public string Desenvolvedor { get; set; } = string.Empty;
    public DateTime DataLancamento { get; set; }
    public bool Ativo { get; set; } = true;
}