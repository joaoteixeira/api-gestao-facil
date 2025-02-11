using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Models;

[Table("portaria_servidor"), PrimaryKey(nameof(Id))]
public class PortariaServidor
{

  [Column("id_psd")]
  public int Id { get; set; }

  [Column("servidor_id_psd")]
  public int ServidorId { get; set; }

  [Column("portaria_id_psd")]

  public int PortariaId { get; set; }

  [Column("presidente_psd")]
  public bool Presidente { get; set; } = false;

  public virtual Servidor? Servidor { get; set; }

  public virtual Portaria? Portaria { get; set; }

}
