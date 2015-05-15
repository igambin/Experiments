using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IG.Validations
{
    public abstract class ValidatorBase<TValidatedObject>
    {
        #region field definitions
        /// <summary>
        /// Eine Liste zur Angabe, welche "ValidationClassAttribute"-erbenden AttributTypen für die Validierung herausgefiltert werden sollen
        /// </summary>
        private readonly List<Type> _validationTypes;

        /// <summary>
        /// Eine Liste zur Angabe in welchen Assemblies die Validierungsklassen gesucht werden sollen
        /// </summary>
        private readonly Assembly[] _validationAssemblies;

        /// <summary>
        /// Die Liste in der alle gefundenen Validierungsregeln für einen Validierungslauf gespeichert werden (DISTINCT)
        /// </summary>
        private readonly ValidationCollection<TValidatedObject> _validationCollection;

        /// <summary>
        /// Das zu validierende Objekt
        /// </summary>
        protected TValidatedObject ValidatedObject;

        /// <summary>
        /// Ein Dictionary zur zentralen Bereitstellung von validierungsrelevante Umgebungsdaten
        /// </summary>
        private readonly Dictionary<string, object> _validationEnvironmentSettings;

        #endregion

        #region Handling validierungsrelevanter Umgebungsdaten
        /// <summary>
        /// Fügt ein Key/Value Paar dem Dictionary für validierungsrelevante Umgebungsdaten hinzu
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void AddSetting(string key, object value)
        {
            if (_validationEnvironmentSettings.ContainsKey(key))
            {
                _validationEnvironmentSettings[key] = value;
            }
            else
            {
                _validationEnvironmentSettings.Add(key, value);
            }
        }
        #endregion

        #region ctor
        /// <summary>
        /// Instanziiere eine neue typisierte Validierungsbasis. Dabei können optional zusätzliche Inforamtionen angegeben werden.
        /// </summary>
        /// <param name="validatedObject">Das zu validierende Objekt (pflicht)</param>
        /// <param name="assemblies">Ein Array von den Assemblies, in welchen nach Validierungsregeln gesucht wird. (default: "CallingAssembly")</param>
        /// <param name="validationTypes">Ein Array von Typen, welche "Kind"-Klassen des ValidationClassAttribute sind und eine Menge von Validierungen attributiert. (default: "ValidationClassAttribute")</param>
        /// <param name="validationEnvironmentSettings">Ein Dictionary mit Validierungsrelevanten Key/Value-Paaren, die so initialisiert übernommen wird. (default: Leeres Dictionary&lt;string,object&gt;>)</param>
        protected ValidatorBase(TValidatedObject validatedObject, [Optional] Assembly[] assemblies, [Optional] Type[] validationTypes, [Optional] Dictionary<string, object> validationEnvironmentSettings )
        {
            ValidatedObject = validatedObject;
            
            _validationAssemblies = assemblies ?? new [] { Assembly.GetCallingAssembly() };
            
            if(validationTypes != null && validationTypes.Any(x => x.IsSubclassOf(typeof(ValidationClassAttribute))))
            {
                _validationTypes = validationTypes.Where(x => x.IsSubclassOf(typeof (ValidationClassAttribute))).ToList();
            }
            else
            {
                _validationTypes = new List<Type> { typeof(ValidationClassAttribute) };
            }

            _validationEnvironmentSettings = validationEnvironmentSettings ?? new Dictionary<string, object>();

            _validationCollection = new ValidationCollection<TValidatedObject>(ValidatedObject, _validationTypes.ToArray(), _validationAssemblies, _validationEnvironmentSettings);
        }
        #endregion

        #region members
        /// <summary>
        /// Initiiert die Validierung aller zur Validierungsbasis gefundenen Validierungen
        /// </summary>
        /// <returns>einen CT_Status mit dem konsolidierten Ergebnis aller Validierungsregeln</returns>
        public ValidationResult IsValid()
        {
            var result = new ValidationResult();

            foreach (var validation in _validationCollection.GetAll())
            {
                ValidationBase<TValidatedObject> validationInstance = null;

                try
                {
                    validationInstance = validation.Value;

                    if (validationInstance == null)
                    {
                        result.AddMessages(new NullReferenceException("validationInstance").CreateMessages().ToArray());
                        continue;
                    }

                    var validationStatus = validationInstance.GetResult();
                    if (validationStatus.Status == ValidationStatus.NotOk)
                    {
                        result.AddMessages(validationStatus.Messages.ToArray(), true);
                    }
                }
                catch (Exception e)
                {
                    if (validationInstance != null)
                    {
                        var quelle = new List<string>
                        {
                            String.Format("PlausiID {0}", validationInstance.ErrorId.ToString(CultureInfo.CurrentCulture)),
                            String.Format("{0}", GetType().FullName)
                        };
                        quelle.AddRange(validationInstance.Quelle);
                        result.AddMessages(validationInstance.ErrorResource, MessageType.Exception, validationInstance.Quelle);
                    }
                    result.AddMessages(e.CreateMessages().ToArray());
                }
            }

            return result;
        }
        #endregion

    }

}