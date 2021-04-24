using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Framework.MVVM
{
    /// <summary>
    /// Base domain object class.
    /// </summary>
    /// <remarks>
    /// Provides support for implementing <see cref="INotifyPropertyChanged"/> and 
    /// implements <see cref="INotifyDataErrorInfo"/> using <see cref="ValidationAttribute"/> instances
    /// on the validated properties.
    /// </remarks>
    public abstract class DomainObject : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private ErrorsContainer<ValidationResult> _errorsContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainObject"/> class.
        /// </summary>
        protected DomainObject()
        {
        }

        /// <summary>
        /// Event raised when a property value changes.
        /// </summary>
        /// <seealso cref="INotifyPropertyChanged"/>
        public event PropertyChangedEventHandler PropertyChanged;

        #region INotifyDataErrorInfo

        /// <summary>
        /// Event raised when the validation status changes.
        /// </summary>
        /// <seealso cref="INotifyDataErrorInfo"/>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Gets the error status.
        /// </summary>
        /// <seealso cref="INotifyDataErrorInfo"/>
        public bool HasErrors
        {
            get { return this.ErrorsContainer.HasErrors; }
        }

        /// <summary>
        /// Returns the errors for <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property for which the errors are requested.</param>
        /// <returns>An enumerable with the errors.</returns>
        /// <seealso cref="INotifyDataErrorInfo"/>
        public IEnumerable GetErrors(string propertyName)
        {
            return this._errorsContainer.GetErrors(propertyName);
        }

        #endregion

        /// <summary>
        /// Gets the container for errors in the properties of the domain object.
        /// </summary>
        protected ErrorsContainer<ValidationResult> ErrorsContainer
        {
            get
            {
                if (this._errorsContainer == null)
                {
                    this._errorsContainer =
                        new ErrorsContainer<ValidationResult>(pn => this.RaiseErrorsChanged(pn));
                }

                return this._errorsContainer;
            }
        }



        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the changed property.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method supports event.")]
        protected void RaisePropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">The argument for the event.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Validates <paramref name="value"/> as the value for the property named <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value for the property.</param>
        protected void ValidateProperty(string propertyName, object value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            this.ValidateProperty(new ValidationContext(this, null, null) { MemberName = propertyName }, value);
        }

        /// <summary>
        /// Validates <paramref name="value"/> as the value for the property specified by 
        /// <paramref name="validationContext"/> using data annotations validation attributes.
        /// </summary>
        /// <param name="validationContext">The context for the validation.</param>
        /// <param name="value">The value for the property.</param>
        protected virtual void ValidateProperty(ValidationContext validationContext, object value)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            List<ValidationResult> validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(value, validationContext, validationResults);

            this.ErrorsContainer.SetErrors(validationContext.MemberName, validationResults);
        }

        /// <summary>
        /// Raises the <see cref="ErrorsChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property which changed its error status.</param>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method supports event.")]
        protected void RaiseErrorsChanged(string propertyName)
        {
            this.OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the <see cref="ErrorsChanged"/> event.
        /// </summary>
        /// <param name="e">The argument for the event.</param>
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            var handler = this.ErrorsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
