﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebColumnas.Utilities
{
    public enum ComparisonType
    {
        LessThan,
        LessThanOrEqualTo,
        EqualTo,
        GreaterThan,
        GreaterThanOrEqualTo
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ComparisonAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string _comparisonProperty;
        private readonly ComparisonType _comparisonType;

        public ComparisonAttribute(string comparisonProperty, ComparisonType comparisonType)
        {
            _comparisonProperty = comparisonProperty;
            _comparisonType = comparisonType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            ErrorMessage = "Error, validación";

            if (value.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("value has not implemented IComparable interface");
            }

            var currentValue = (IComparable)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException("Comparison property with this name not found");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("Comparison property has not implemented IComparable interface");
            }

            if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
            {
                throw new ArgumentException("The properties types must be the same");
            }

            bool compareToResult;

            switch (_comparisonType)
            {
                case ComparisonType.LessThan:

                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) >= 0;
                    ErrorMessage = "Error, debe ser < " + _comparisonProperty ;
                    break;
                case ComparisonType.LessThanOrEqualTo:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) > 0;
                    ErrorMessage = "Error, debe ser <= " + _comparisonProperty;
                    break;
                case ComparisonType.EqualTo:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) != 0;
                    break;
                case ComparisonType.GreaterThan:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) <= 0;
                    ErrorMessage = "Error, debe ser > " + _comparisonProperty;
                    break;
                case ComparisonType.GreaterThanOrEqualTo:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) < 0;
                    ErrorMessage = "Error, debe ser >= " + _comparisonProperty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return compareToResult ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            var error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-error", error);
        }
    }
}
