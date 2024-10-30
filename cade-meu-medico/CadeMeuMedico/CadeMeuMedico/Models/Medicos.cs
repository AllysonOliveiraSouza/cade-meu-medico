using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace CadeMeuMedico.Models
{
    public class Medicos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Especialidade")]
        public int IdEspecialidade { get; set; }
        [Required(ErrorMessage ="Obrigatório informar o Crm")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir no máximo 30 caracteres")]
        public string? Crm { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo80 caracteres")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Endereço")]
        [StringLength(100, ErrorMessage = "O Endereço deve possuir no máximo 100 caracteres")]
        [Display(Name ="Endereço")]
        public string? Endereco { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Bairro")]
        [StringLength(60, ErrorMessage = "O Bairro deve possuir no máximo 60 caracteres")]
        public string? Bairro { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Cidade")]
        public int IdCidade { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o E-mail")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no máximo 100 caracteres")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Obrigatório informar se Atende por Convênio")]
        public bool AtendePorConvenio { get; set; }
        [Required(ErrorMessage = "Obrigatório informar se Tem Clínica")]
        public bool TemClinica { get; set; }
        [StringLength(80, ErrorMessage = "O Website deve possuir no máximo 80 caracteres")]
        public string? WebSiteBlog  { get; set; }
        public Especialidades? Especialidade { get; set; }
        public Cidades? Cidade { get; set; }
    }
}
