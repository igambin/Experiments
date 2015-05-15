using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace IG.Validations
{
    public abstract class ValidationBase<TValidatedObject>
    {
        #region returnValues
        /// <summary>
        /// das Result-Objekt, welches das Ergebnis der Validierung einer Validierungsklasse enth�lt
        /// </summary>
        protected ValidationResult Result;

        #endregion

        #region fields & properties

        /// <summary>
        /// Eine Liste von Validierungsklassentypen, die als PreConstraints zur Ausf�hrung dieser Validierungsklasse "valide" sein m�ssen
        /// </summary>
        public List<Type> PreConstraints { get; private set; }

        /// <summary>
        /// Eine Liste zur Sammlung von Quellen-Informationen, die dann im Result-Objekt aufgelistet werden
        /// </summary>
        public List<string> FehlerQuellen { get; private set; }

        /// <summary>
        /// Das zu validierende Objekt
        /// </summary>
        protected TValidatedObject ValidatedObject;

        /// <summary>
        /// Eine Liste validierungsrelevanter Umgebungsdaten
        /// </summary>
        private readonly Dictionary<string, object> _validationEnvironmentSettings; 

        /// <summary>
        /// Die Liste aller f�r die Validierung gefundenen Validierungsklassen
        /// </summary>
        private readonly ValidationCollection<TValidatedObject> _validationCollection;

        #endregion

        #region abstract properties

        /// <summary>
        /// ein abstraktes Property, das die einer Validierung bereitgestellten Nachrichten-Ressource zur�ckgibt
        /// (MUSS in der abgeleiteten Validierungsklasse implementiert werden)
        /// </summary>
        public abstract Expression<Func<string>> ErrorResource { get; }

        /// <summary>
        /// ein abstraktes Property, das die zur Validierung ben�tigte Regel ausdefiniert 
        /// (MUSS in der abgeleiteten Validierungsklasse implementiert werden)
        /// </summary>
        public abstract bool ValidationRule { get; }

        #endregion

        #region virtual properties

        /// <summary>
        /// ein Accessor, der alle Fehlerquellen als string[] zur�ckgibt
        /// (kann in der jeweiligen Validierungsklasse �berschrieben werden)
        /// </summary>
        public virtual string[] Quelle
        {
            get { return FehlerQuellen.ToArray(); }
        }

        #endregion

        #region ctor

        /// <summary>
        /// erzeugt ein neues ValidationBase-Objekt
        /// </summary>
        /// <param name="validatedObject">zu validierendes Objekt</param>
        /// <param name="settings">Ein Dictionary mit Validierungsrelevanten Key/Value-Paaren, die so initialisiert �bernommen wird</param>
        /// <param name="validationCollection">die Liste aller Validierungen list of all ValidationRule-Instances</param>
        protected ValidationBase(TValidatedObject validatedObject, Dictionary<string, object> settings,  ValidationCollection<TValidatedObject> validationCollection)
        {
            _validationCollection = validationCollection;
            _validationEnvironmentSettings = settings;
            PreConstraints = new List<Type>();
            FehlerQuellen = new List<string>();
            Result = new ValidationResult();
            ValidatedObject = validatedObject;
        }
        #endregion

        #region settingsHandler

        /// <summary>
        /// gibt ein String[] zur�ck, welches alle Setting-Keys enth�lt
        /// </summary>
        protected string[] SettingKeys
        {
            get { return _validationEnvironmentSettings.Keys.ToArray(); }
        }

        /// <summary>
        /// Auslesen eines Setting-Wertes aus den validierungsrelevanten Umgebungsdaten und R�ckgabe als 'object'
        /// </summary>
        /// <param name="key">Key des zu suchenden Wertes</param>
        /// <returns>object value</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        protected object GetSetting(string key)
        {
            if (!_validationEnvironmentSettings.ContainsKey(key))
            {
                throw new KeyNotFoundException(
                    string.Format("Key '{0}' ist in den Validation-Environment-Settings nicht enthalten", key));
            }
            return _validationEnvironmentSettings[key];
        }

        /// <summary>
        /// Auslesen eines Setting-Wertes aus den validierungsrelevanten Umgebungsdaten
        /// </summary>
        /// <typeparam name="T">Typ des auszulesenden Wertes</typeparam>
        /// <param name="key">Key des zu suchenden Wertes</param>
        /// <returns></returns>
        protected T GetSetting<T>(string key)
        {
            T x;
            try
            {
                x = (T) GetSetting(key);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new InvalidDataException(string.Format("Nicht zul�ssiger R�ckgabetyp '{0}' f�r Validation-Environment-Setting '{1}'", typeof(T).Name, key));
            }
            return x;
        }

        #endregion

        #region ResourceInformation

        /// <summary>
        /// gibt die ID einer ErrorRessource zur�ck, wenn die Ressource gefunden wird und aufgel�st werden kann, oder -1 wenn der Versuch die ID aufzul�sen fehlschl�gt
        /// </summary>
        public int ErrorId 
        {
            get 
            {
                var memberExpr = ErrorResource.Body as MemberExpression;
                if (memberExpr != null)
                {
                    var type = memberExpr.Member.DeclaringType;
                    if (type != null)
                    {
                        var propInfo = memberExpr.Member as PropertyInfo;
                        if (propInfo != null)
                        {
                            var propName = propInfo.Name;
                            var idPropInfo = type.GetProperty(propName + "Id");
                            return (int)idPropInfo.GetValue(null, null);
                        }

                    }
                }
                return -1;
            }
        }
        #endregion

        #region PreConstraint-Handling

        /// <summary>
        /// f�gt Typen, die von ValidationBase&lt;TValidatedObject&gt; abgeleitet sind zur Liste der PreConstraints
        /// </summary>
        /// <typeparam name="TValidation">der Typ der hinzuzuf�genden Klasse</typeparam>
        protected void AddPreConstraint<TValidation>() where TValidation : ValidationBase<TValidatedObject>
        {
            AddPreConstraint(typeof (TValidation));
        }

        /// <summary>
        /// f�gt Typen, die von ValidationBase&lt;TValidatedObject&gt; abgeleitet sind zur Liste der PreConstraints
        /// </summary>
        /// <param name="constraintType">der Typ der hinzuzuf�genden Klasse</param>
        private void AddPreConstraint(Type constraintType)
        {
            var constructorInfo = constraintType.GetConstructor(new[] { typeof(TValidatedObject), typeof(Dictionary<string, object>), typeof(ValidationCollection<TValidatedObject>) });
            if (constructorInfo != null)
            {
                _validationCollection.PostRegisterPreConstraintType(constraintType);
                    
                if (!PreConstraints.Contains(constraintType))
                {
                    PreConstraints.Add(constraintType);
                }
            }
            else
            {
                throw new ArgumentException(constraintType.Name);// TODO LocalText.MissingValidConstructorInValidationClassFormat(constraintType.Name));
            }            
        }

        /// <summary>
        /// Untersucht die, in einer MethodCallExpression gekapselten, Methode nach dem 'RequiredPreConstrainsAttribute',
        /// und f�gt alle dort aufgelisteten ValidierungsTypen zur Liste der PreConstraints hinzu. 
        /// </summary>
        /// <param name="expression"></param>
        private void AddPreConstraintsFor(MethodCallExpression expression)
        {
            var method = expression.Method;

            var attrs = method.GetCustomAttributes(typeof(RequiredPreConstraintsAttribute), true).Cast<RequiredPreConstraintsAttribute>();
            foreach (var attr in attrs)
            {
                foreach (var constraint in attr.Preconstraints)
                {
                    AddPreConstraint(constraint);
                }
            }
        }

        /// <summary>
        /// Untersucht die, in einer MethodCallExpression gekapselten, Methode nach dem 'RequiredPreConstrainsAttribute',
        /// und f�gt alle dort aufgelisteten ValidierungsTypen zur Liste der PreConstraints hinzu. 
        /// (�ffentlicher Wrapper f�r Methoden ohne Eingabe-Parameter)
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        public void AddPreConstraintsFor<TOut>(Expression<Func<TOut>> extensionExpression)
        {
            AddPreConstraintsFor((MethodCallExpression) extensionExpression.Body);
        }
        /// <summary>
        /// Untersucht die, in einer MethodCallExpression gekapselten, Methode nach dem 'RequiredPreConstrainsAttribute',
        /// und f�gt alle dort aufgelisteten ValidierungsTypen zur Liste der PreConstraints hinzu. 
        /// (�ffentlicher Wrapper f�r Methoden mit einem Eingabe-Parameter)
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <typeparam name="TIn"></typeparam>
        public void AddPreConstraintsFor<TIn, TOut>(Expression<Func<TIn, TOut>> extensionExpression)
        {
            AddPreConstraintsFor((MethodCallExpression)extensionExpression.Body);
        }
        /// <summary>
        /// Untersucht die, in einer MethodCallExpression gekapselten, Methode nach dem 'RequiredPreConstrainsAttribute',
        /// und f�gt alle dort aufgelisteten ValidierungsTypen zur Liste der PreConstraints hinzu. 
        /// (�ffentlicher Wrapper f�r Methoden mit zwei Eingabe-Parametern)
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <typeparam name="TIn1"></typeparam>
        /// <typeparam name="TIn2"></typeparam>
        public void AddPreConstraintsFor<TIn1, TIn2, TOut>(Expression<Func<TIn1, TIn2, TOut>> extensionExpression)
        {
            AddPreConstraintsFor((MethodCallExpression)extensionExpression.Body);
        }
        /// <summary>
        /// Untersucht die, in einer MethodCallExpression gekapselten, Methode nach dem 'RequiredPreConstrainsAttribute',
        /// und f�gt alle dort aufgelisteten ValidierungsTypen zur Liste der PreConstraints hinzu. 
        /// (�ffentlicher Wrapper f�r Methoden mit drei Eingabe-Parametern)
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <typeparam name="TIn1"></typeparam>
        /// <typeparam name="TIn2"></typeparam>
        /// <typeparam name="TIn3"></typeparam>
        public void AddPreConstraintsFor<TIn1, TIn2, TIn3, TOut>(Expression<Func<TIn1, TIn2, TIn3, TOut>> extensionExpression)
        {
            AddPreConstraintsFor((MethodCallExpression)extensionExpression.Body);
        }
        /// <summary>
        /// Untersucht die, in einer MethodCallExpression gekapselten, Methode nach dem 'RequiredPreConstrainsAttribute',
        /// und f�gt alle dort aufgelisteten ValidierungsTypen zur Liste der PreConstraints hinzu. 
        /// (�ffentlicher Wrapper f�r Methoden mit vier Eingabe-Parametern)
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <typeparam name="TIn1"></typeparam>
        /// <typeparam name="TIn2"></typeparam>
        /// <typeparam name="TIn3"></typeparam>
        /// <typeparam name="TIn4"></typeparam>
        public void AddPreConstraintsFor<TIn1, TIn2, TIn3, TIn4, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TOut>> extensionExpression)
        {
            AddPreConstraintsFor((MethodCallExpression)extensionExpression.Body);
        }
        /// <summary>
        /// Untersucht die, in einer MethodCallExpression gekapselten, Methode nach dem 'RequiredPreConstrainsAttribute',
        /// und f�gt alle dort aufgelisteten ValidierungsTypen zur Liste der PreConstraints hinzu. 
        /// (�ffentlicher Wrapper f�r Methoden mit f�nf Eingabe-Parametern)
        /// </summary>
        /// <typeparam name="TOut"></typeparam>
        /// <typeparam name="TIn1"></typeparam>
        /// <typeparam name="TIn2"></typeparam>
        /// <typeparam name="TIn3"></typeparam>
        /// <typeparam name="TIn4"></typeparam>
        /// <typeparam name="TIn5"></typeparam>
        public void AddPreConstraintsFor<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(Expression<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>> extensionExpression)
        {
            AddPreConstraintsFor((MethodCallExpression)extensionExpression.Body);
        }

        /// <summary>
        /// Privates Feld zur Memoisierung der Auswertung der PreConstraints
        /// (Memoisierung nennt man das Vorgehen, Zwischenergebnisse zu speichern um bei erneuter Evaluierung die ausf�hrliche Berechnung durch R�ckgabe des gespeicherten Wertes zu sparen.)
        /// </summary>
        private bool? _preConstraintsAreValid;

        /// <summary>
        /// Evaluiert die G�ltigkeit aller PreConstraints, sofern vorhanden, und speichert das Ergebnis
        /// </summary>
        private bool PreConstraintsAreValid
        {
            get
            {
                if (PreConstraints != null && PreConstraints.Any())
                {
                    if (!_preConstraintsAreValid.HasValue)
                    {
                        var preConstraints = _validationCollection.GetPreConstraintTypes(PreConstraints.ToArray());
                        _preConstraintsAreValid = preConstraints.All(x => x.IsValid());
                    }
                }
                else
                {
                    _preConstraintsAreValid = true;
                }
                return _preConstraintsAreValid.Value;
            }

        }

        #endregion

        #region Validity-Evaluation

        /// <summary>
        /// Privates Feld zur Memoisierung der Auswertung der ValidationRule der aktuell betrachteten Validierungsklasse
        /// (Memoisierung nennt man das Vorgehen, Zwischenergebnisse zu speichern um bei erneuter Evaluierung die ausf�hrliche Berechnung durch R�ckgabe des gespeicherten Wertes zu sparen.)
        /// </summary>
        private bool? _isValid;

        /// <summary>
        /// Evaluiert die G�ltigkeit der ValidationRule und speichert das Ergebnis
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            if (!_isValid.HasValue)
            {
                if (!PreConstraintsAreValid)
                {
                    // accept testcase as valid if preconstraints are not valid in order to skip validationrulecheck
                    _isValid = true;
                }
                else
                {
                    _isValid = ValidationRule;
                }
            }
            return _isValid.Value;
        }

        #endregion

        #region Status/Result-Handling

        /// <summary>
        /// started die Evaluierung der aktuell betrachteten Validierungsklasse und gibt ein CT_Status-Objekt inkl. StatusId und dem zugeh�rigen CT_Meldung[] zur�ck
        /// (einziger �ffentlicher Zugangspunkt zur Auswertung der ValidationRule)
        /// </summary>
        /// <returns></returns>
        public ValidationResult GetResult()
        {
            Result = new ValidationResult();
            if (!IsValid()) {
                AddMessagesTo(Result);
            }

            CheckLeereQuellen();

            return Result;
        }

        /// <summary>
        /// F�gt PlausiID und Namen der Validierungsklasse der Liste der Fehlerquellen hinzu
        /// </summary>
        /// <returns></returns>
        private List<string> GetQuelle()
        {
            var quelle = new List<string>
            {
                string.Format("PlausiID {0}", ErrorId.ToString(CultureInfo.CurrentCulture)),
                string.Format("{0}", GetType().FullName)
            };
            quelle.AddRange(Quelle);
            return quelle;
        }

        /// <summary>
        /// F�gt eine CT_Meldung zum angegebenen CT_Status-Objekt hinzu
        /// </summary>
        /// <param name="status"></param>
        private void AddMessagesTo(ValidationResult result)
        {
            result.AddMessages(ErrorResource, MessageType.Error, GetQuelle().ToArray());
        }

        /// <summary>
        /// Stellt sicher, da� die Quelle in die Meldung aufgenommen wird
        /// (ist relevant, wenn eine Validierung z. B. wegen einer Exception abbricht, man aber trotzdem die Quelle (PlausiID, Name der Klasse) in der Meldung aufnehmen will)
        /// </summary>
        private void CheckLeereQuellen()
        {
            foreach (var item in Result.Messages.Where(item => string.IsNullOrWhiteSpace(item.Source)))
            {
                item.Source = string.Join("," ,GetQuelle());
            }
        }

        #endregion

    }
}