﻿using JetBrains.Annotations;
using System;
using System.ComponentModel;
using System.Windows.Markup;

namespace AcadLib.WPF.Converters
{
    /// <summary>
    /// ComboBox ItemsSource="{Binding Source={local:EnumBindingSource {x:Type local:MyEnum}}}"    /// 
    /// </summary>
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        public Type EnumType
        {
            get { return _enumType; }
            set {
                if (value != _enumType)
                {
                    if (null != value)
                    {
                        var enumType = Nullable.GetUnderlyingType(value) ?? value;
                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    _enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            EnumType = enumType;
        }

        [NotNull]
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == _enumType)
                throw new InvalidOperationException("The EnumType must be specified.");

            var actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
            var enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == _enumType)
                return enumValues;

            var tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }

    /// <summary>
    /// Конвертер enum значений из описаний значений
    /// [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    /// public enum MyEnum
    /// {
    /// [Description("Центр")]
    /// Central,
    /// [Description("Восток")]
    /// East,
    /// [Description("Запад")]
    /// West
    /// }
    /// </summary>
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type)
            : base(type)
        {
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return GetEnumDescription(value);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public static string GetEnumDescription([CanBeNull] object enumValue)
        {
            if (enumValue == null) return null;
            var fi = enumValue.GetType().GetField(enumValue.ToString());
            if (fi == null) return null;
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return enumValue.ToString();
        }
    }

    public static class EnumDescriptionExt
    {
        public static string Description(this object enumValue)
        {
            return EnumDescriptionTypeConverter.GetEnumDescription(enumValue);
        }
    }
}
