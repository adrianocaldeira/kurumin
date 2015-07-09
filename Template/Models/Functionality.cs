using System.Net;
using Thunder.Data.Pattern;

namespace Template.Models
{
    /// <summary>
    ///     Funcionalida de um m�dulo do sistema
    /// </summary>
    public class Functionality : Persist<Functionality, int>
    {
        /// <summary>
        ///     Inicializa uma nova inst�ncia da classe <see cref="Functionality" />.
        /// </summary>
        public Functionality()
        {
            HttpMethod = WebRequestMethods.Http.Get;
        }

        /// <summary>
        ///     Recupera ou define nome
        /// </summary>
        public virtual Module Module { get; set; }

        /// <summary>
        ///     Recupera ou define nome
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     Recupera ou define descri��o
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Recupera ou define a��o
        /// </summary>
        public virtual string Action { get; set; }

        /// <summary>
        ///     Recupera ou define controlador
        /// </summary>
        public virtual string Controller { get; set; }

        /// <summary>
        ///     Recupera ou define m�todo http
        /// </summary>
        public virtual string HttpMethod { get; set; }

        /// <summary>
        ///     Recupera ou define se a funcionalidade � a padr�o do m�dulo
        /// </summary>
        public virtual bool Default { get; set; }
    }
}