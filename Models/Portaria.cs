using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Models;

[Table("portaria"), PrimaryKey(nameof(Id))]
public class Portaria
{

  [Column("id_por")]
  public int Id { get; set; }

  [Column("titulo_por")]
  public required string Titulo { get; set; }

  [Column("descricao_por")]
  public string? Descricao { get; set; }

  [Column("numero_por")]
  public int Numero { get; set; }

  [Column("ano_por")]
  public int Ano { get; set; }

  [Column("data_criacao_por")]
  public DateTime DataCriacao { get; }

  [Column("campus_id_por")]
  public int CampusId { get; set; }

  public virtual Campus? Campus { get; set; }

  public List<PortariaServidor>? PortariaServidores { get; set; } = [];
}
