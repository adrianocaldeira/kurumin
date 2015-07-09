using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NHibernate.Criterion;
using Thunder.Model;

namespace Template.Models.Filters
{
    /// <summary>
    /// Filtro de <see cref="UserProfile"/>
    /// </summary>
    public class UserProfileFilter : Filter
    {
        /// <summary>
        /// Inicializa uma nova inst�ncia da classe <see cref="UserProfileFilter"/>
        /// </summary>
        public UserProfileFilter()
        {
            PageSize = DefaultPageSize;
        }

        /// <summary>
        /// Tamanho padr�o da pagina��o
        /// </summary>
        public const int DefaultPageSize = 15;

        /// <summary>
        /// Recupera ou define nome
        /// </summary>
        [Display(Name = "Nome")]
        public string Name { get; set; }

        /// <summary>
        /// Recupera ou define ativo
        /// </summary>
        [Display(Name = "Ativo")]
        public bool? Active { get; set; }

        /// <summary>
        /// Por nome
        /// </summary>
        public bool ByName
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        /// <summary>
        /// Por ativo
        /// </summary>
        public bool ByActive
        {
            get { return Active.HasValue; }
        }

        /// <summary>
        /// Crit�rios
        /// </summary>
        /// <returns></returns>
        public IList<ICriterion> Criterions()
        {
            var criterions = new List<ICriterion>();

            return criterions;
        }
    }
}