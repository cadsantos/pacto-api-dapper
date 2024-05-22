using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Pacto.Domain.Models.ViewModels.Assinaturas
{
    public class AssinaturaViewModel
    {
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int IdStatus { get; set; }
        public int? IdAssinante { get; set; }
        public int? IdTipoIdentificacao { get; set; }
        public bool? Excluido { get; set; }
        public int? Ordem { get; set; }
        public Guid Key { get; set; }
        public string? MotivoDeclinio { get; set; }
        public string? CargoAssinante { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NomeAssinante { get; set; }
        public string? JustificativaExclusao { get; set; }
        public string? IdentificacaoAssinante { get; set; }
        public string? QualificacaoAssinante { get; set; }
        public string? DataLimiteAssinatura { get; set; }
        public string? DataAssinaturaEletronica { get; set; }
        public string? DataAssinaturaDigital { get; set; }
        public string? DataDeclinio { get; set; }
        public string? Justificativa { get; set; }

    }
}
