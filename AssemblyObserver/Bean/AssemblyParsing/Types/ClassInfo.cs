using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AssemblyObserver.Bean.AssemblyParsing.Types
{
    internal class ClassInfo : IType
    {
        public string GetTypeDescription()
        {
            string description = "";
            if (_classType.IsClass)
            {
                description = "class ";
            } else if (_classType.IsInterface)
            {
                description = "interface ";
            }
            description += _classType.Name;
            return description;
        }

        public List<IType> GetNestedTypes()
        {
            return _nestedTypes;
        }

        internal ClassInfo(Type type)
        {
            _classType = type;
            _nestedTypes = new List<IType>();
            AddNestedFields();
            AddNestedProperties();
            AddNestedMethods();
        }


        private void AddNestedFields()
        {
            //Public fields
            FieldInfo[] publicFields = _classType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in publicFields)
            {
                _nestedTypes.Add(new SimpleType("public " + field.FieldType.Name + " " + field.Name));
            }
            //Private fields
            FieldInfo[] privateFields = _classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in privateFields)
            {
                _nestedTypes.Add(new SimpleType("private " + field.FieldType.Name + " " + field.Name));
            }
        }


        private void AddNestedProperties()
        {
            PropertyInfo[] properties = _classType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                _nestedTypes.Add(new SimpleType("public " + GetPropertyDescription(property)));
            }
            properties = _classType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {
                _nestedTypes.Add(new SimpleType("private " + GetPropertyDescription(property)));
            }
        }


        private string GetPropertyDescription(PropertyInfo property)
        {
            string propertyDesc = property.PropertyType.Name + " " + property.Name + " {";
            if (property.CanWrite)
                propertyDesc += "set; ";
            if (property.CanRead)
                propertyDesc += "get; ";
            propertyDesc += " }";
            return propertyDesc;
        }


        private void AddNestedMethods()
        {
            MethodInfo[] methods = _classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo method in methods)
            {
                _nestedTypes.Add(new SimpleType("public " + GetMethodSignature(method)));
            }
            methods = _classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo method in methods)
            {
                _nestedTypes.Add(new SimpleType("private " + GetMethodSignature(method)));
            }
        }


        private string GetMethodSignature(MethodInfo method)
        {
            string signature = "";
            signature += method.ReturnType.Name + " ";
            signature += method.Name + "(";
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                signature += parameter.ParameterType.Name + " " + parameter.Name;
            }
            signature += ")";
            return signature;
        }


        private Type _classType;
        private List<IType> _nestedTypes;
    }
}
