using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Models;

[Table("servidor")]
public class Servidor
{
    [Column("id_ser")]
    public int Id { get; set; }

    [Column("nome_ser")]
    public string? Nome { get; set; }

    [Column("cpf_ser")]
    public string? CPF { get; set; }

    [Column("siape_ser")]
    public int Siape { get; set; }

    [Column("id_cam_fk")]
    public int CampusId { get; set; }

    [ForeignKey("CampusId")]
    public virtual Campus? Campus { get; set; }
}

