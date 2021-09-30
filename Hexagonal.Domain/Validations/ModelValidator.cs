using Hexagonal.Domain.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Hexagonal.Domain.Validations
{
    public static class ModelValidator
    {
        /// <summary>
        /// Valida as propriedades do modelo informado
        /// </summary>
        /// <typeparam name="T">Tipo do modelo</typeparam>
        /// <param name="model">Modelo a ser validado</param>
        /// <exception cref="CoreException"></exception>
        public static void Validate<T>(T model)
        {
            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (!isValid)
            {
                var erros = validationResults
                    .Select(v => new CoreError(v.MemberNames.FirstOrDefault(),
                                               v.ErrorMessage))
                    .ToArray();

                throw new CoreException(erros);
            }
        }
    }
}
