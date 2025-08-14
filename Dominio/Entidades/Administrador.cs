using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Dominio.Entidades
{
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
        [StringLength(10)]
        public string Perfil { get; set; } = string.Empty;
    }
}