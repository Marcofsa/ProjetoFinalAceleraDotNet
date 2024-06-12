namespace Atos.WebApi.Endpoints.DTO;

public class UsuarioDTO
{
    public string IdUsuario { get; set; } = null!;

    public int IdUnidadeInstUsuario { get; set; }

    public string DescNomeUsuario { get; set; } = null!;

    public virtual UnidadeInstituicao UnidadeInstituicao { get; set; } = null!;

    public virtual ICollection<Terminal> Terminals { get; set; } = new List<Terminal>();
}