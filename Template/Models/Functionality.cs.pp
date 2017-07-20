using System.ComponentModel.DataAnnotations;
using Thunder.Data;

namespace $rootnamespace$.Models
{
    /// <summary>
    ///     Funcionalida de um m�dulo do sistema
    /// </summary>
    public class Functionality : Persist<Functionality, int>
    {
        /// <summary>
        ///     Recupera ou define nome
        /// </summary>
        public virtual Module Module { get; set; }

        /// <summary>
        ///     Recupera ou define nome
        /// </summary>
        [Required]
        [Display(Name = "Nome")]
        public virtual string Name { get; set; }

        /// <summary>
        ///     Recupera ou define descri��o
        /// </summary>
        [Display(Name = "Descri��o")]
        public virtual string Description { get; set; }

        /// <summary>
        ///     Recupera ou define a��o
        /// </summary>
        [Required]
        [Display(Name = "Nome da Action")]
        public virtual string Action { get; set; }

        /// <summary>
        ///     Recupera ou define controlador
        /// </summary>
        [Required]
        [Display(Name = "Nome da Controller")]
        public virtual string Controller { get; set; }

        /// <summary>
        ///     Recupera ou define m�todo http
        /// </summary>
        [Required]
        [Display(Name = "M�todo HTTP")]
        public virtual string HttpMethod { get; set; }

        /// <summary>
        ///     Recupera ou define se a funcionalidade � a padr�o do m�dulo
        /// </summary>
        [Display(Name = "Principal")]
        public virtual bool Default { get; set; }
    }
}