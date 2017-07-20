using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Template.Repository;
using Thunder.ComponentModel.DataAnnotations;
using Thunder.Data;
using Thunder.Extensions;

namespace Template.Models
{
    /// <summary>
    ///     Perfil de usu�rio
    /// </summary>
    public class UserProfile : Persist<UserProfile, int>
    {
        /// <summary>
        ///     Inicializa uma nova inst�ncia da classe <see cref="UserProfile" />.
        /// </summary>
        public UserProfile()
        {
            Functionalities = new List<Functionality>();
        }

        /// <summary>
        ///     Recupera ou define c�digo
        /// </summary>
        [Display(Name = "Perfil")]
        public new virtual int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        ///     Recuper ou define nome
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public virtual string Name { get; set; }

        /// <summary>
        ///     Recuper aou define funcionalidades
        /// </summary>
        [ListRequired(ErrorMessage = "Selecione ao menos uma funcionalidade.")]
        public virtual IList<Functionality> Functionalities { get; set; }

        /// <summary>
        ///     Recupera ou define estado do perfil
        /// </summary>
        [Display(Name = "Status")]
        public virtual bool Active { get; set; }

        /// <summary>
        ///     Recupera ou define descri��o de audit�ria
        /// </summary>
        public virtual string AuditDescription { get; set; }

        /// <summary>
        ///     Recupera ou define usu�rio de audit�ria
        /// </summary>
        public virtual string AuditUser { get; set; }

        /// <summary>
        ///     Recupera ou define grupo refer�ncia de audit�ria
        /// </summary>
        public virtual string AuditGroupReference { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{0} - {1}".With(Id, Name);
        }

        /// <summary>
        ///     Possui acesso ao m�dulo do sistema
        /// </summary>
        /// <param name="module">
        ///     <see cref="Module" />
        /// </param>
        /// <returns>Possui acesso</returns>
        public virtual bool HasAccess(Module module)
        {
            return Functionalities.Any(module.Contains);
        }

        /// <summary>
        ///     Possui acesso a funcionalidade de um m�dulo
        /// </summary>
        /// <param name="functionality">
        ///     <see cref="Functionality" />
        /// </param>
        /// <returns>Possui acesso</returns>
        public virtual bool HasAccess(Functionality functionality)
        {
            return Functionalities.Contains(functionality);
        }

        /// <summary>
        /// Valida <see cref="UserProfile"/>
        /// </summary>
        /// <param name="modelState"><see cref="ModelStateDictionary"/></param>
        /// <param name="repository"><see cref="IUserProfileRepository"/></param>
        /// <returns></returns>
        public virtual bool IsValid(ModelStateDictionary modelState, IUserProfileRepository repository)
        {
            if (!modelState.IsValid) return modelState.IsValid;

            if (repository.ExistName(Id, Name))
            {
                modelState.AddModelError("Name", "O nome informado j� existe.");
            }

            return modelState.IsValid;
        }

        
    }
}