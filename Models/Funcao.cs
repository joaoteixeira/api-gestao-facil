using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoFacil.Models;

[Table("funcao"), PrimaryKey(nameof(Id))]
public class Funcao
{
    [Column("id_fun")]
    public int Id { get; set; }

    [Column("nome_fun")]
    public required string Nome { get; set; }

    public List<Servidor> Servidores { get; } = [];
}

