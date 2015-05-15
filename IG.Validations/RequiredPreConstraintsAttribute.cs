using System;
using System.Collections.Generic;
using System.Linq;

namespace IG.Validations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RequiredPreConstraintsAttribute : Attribute
    {
        private readonly List<Type> _preconstraints;

        /// <summary>
        /// registriert ein Array von ValidierungsTypen als PreConstraint-Typen für eine Methode
        /// </summary>
        /// <param name="preconstraints">eine Menge von ValidierungsTypen</param>
        public RequiredPreConstraintsAttribute(params Type[] preconstraints)
        {
            _preconstraints = preconstraints.ToList();
        }

        /// <summary>
        /// Gibt die registrierten PreConstraint-Typen als IEnumerable&lt;Type&gt; zurück
        /// </summary>
        public IEnumerable<Type> Preconstraints
        {
            get { return _preconstraints; }
        }
    }
}