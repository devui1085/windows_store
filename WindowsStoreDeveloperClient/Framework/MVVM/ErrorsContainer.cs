using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.MVVM
{
    /// <summary>
    /// Manages validation errors for an object, notifying when the error state changes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ErrorsContainer<T>
    {
        private static readonly T[] NoErrors = new T[0];
        private readonly Action<string> _raiseErrorsChanged;
        private readonly Dictionary<string, List<T>> _validationResults;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorsContainer{T}"/> class.
        /// </summary>
        /// <param name="raiseErrorsChanged">The action that raises the <see cref="INotifyDataErrorInfo.ErrorsChanged"/>
        /// event.</param>
        public ErrorsContainer(Action<string> raiseErrorsChanged)
        {
            if (raiseErrorsChanged == null)
            {
                throw new ArgumentNullException(nameof(raiseErrorsChanged));
            }

            this._raiseErrorsChanged = raiseErrorsChanged;
            this._validationResults = new Dictionary<string, List<T>>();
        }

        /// <summary>
        /// Gets a value that indicates whether the object has validation errors. 
        /// </summary>
        public bool HasErrors => this._validationResults.Count != 0;

        /// <summary>
        /// Gets the validation errors for a specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The validation errors of type <typeparamref name="T"/> for the property.</returns>
        public IEnumerable<T> GetErrors(string propertyName)
        {
            var localPropertyName = propertyName ?? string.Empty;
            List<T> currentValidationResults = null;
            if (this._validationResults.TryGetValue(localPropertyName, out currentValidationResults))
            {
                return currentValidationResults;
            }
            else
            {
                return NoErrors;
            }
        }

        /// <summary>
        /// Sets the validation errors for the specified property.
        /// </summary>
        /// <remarks>
        /// If a change is detected then the errors changed event is raised.
        /// </remarks>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="newValidationResults">The new validation errors.</param>
        public void SetErrors(string propertyName, IEnumerable<T> newValidationResults)
        {
            var localPropertyName = propertyName ?? string.Empty;
            var hasCurrentValidationResults = this._validationResults.ContainsKey(localPropertyName);
            var validationResults = newValidationResults as T[] ?? newValidationResults.ToArray();
            var hasNewValidationResults = newValidationResults != null && validationResults.Count() > 0;

            if (hasCurrentValidationResults || hasNewValidationResults)
            {
                if (hasNewValidationResults)
                {
                    this._validationResults[localPropertyName] = new List<T>(validationResults);
                    this._raiseErrorsChanged(localPropertyName);
                }
                else
                {
                    this._validationResults.Remove(localPropertyName);
                    this._raiseErrorsChanged(localPropertyName);
                }
            }
        }
    }
}
