using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IG.Validations.Exceptions;
using System.Runtime.InteropServices;

namespace IG.Validations
{
    public class ValidationCollection<TValidatedObject>
    {
        #region field definitions

        /// <summary>
        /// Das Dictionary&lt;Type, ValidationBase&lt;TValidatedObject&gt;&gt;, welches alle gefundenen Validierungsklassen eindeutig vom Typ auf ein jeweils Instanziiertes Objekt des Typs mapped
        /// </summary>
        private readonly Dictionary<Type, ValidationBase<TValidatedObject>> _validations;

        /// <summary>
        /// Ein Dictionary&lt;string, object&gt; zur zentralen Bereitstellung von validierungsrelevante Umgebungsdaten
        /// </summary>
        private readonly Dictionary<string, object> _validationEnvironmentSettings;

        /// <summary>
        /// Das zu validierende Objekt vom generischen Typ 'TValidatedObject'
        /// </summary>
        private readonly TValidatedObject _validatedObject;

        /// <summary>
        /// Eine Liste zur Angabe, welche "ValidationClassAttribute"-erbenden AttributTypen für die Validierung herausgefiltert werden sollen
        /// </summary>
        private readonly List<Type> _validationTypes;

        /// <summary>
        /// Eine Liste zur Angabe in welchen Assemblies die Validierungsklassen gesucht werden sollen
        /// </summary>
        private readonly Assembly[] _validationAssemblies;
        
        #endregion

        #region ctor

        /// <summary>
        /// Instanziiere eine neue typisierte ValidationCollection. Dabei können optional zusätzliche Inforamtionen angegeben werden. 
        /// WICHTIG: Werden keine Assemblies angegeben, muss die Liste der auszuführenden Validierungen explizit angegeben werden.
        /// </summary>
        /// <param name="validatedObject">Das zu validierende Objekt (pflicht)</param>
        /// <param name="types">Ein Array von Typen, welche "Kind"-Klassen des ValidationClassAttribute sind und eine Menge von Validierungen attributiert. (default: "ValidationClassAttribute")</param>
        /// <param name="settings">Ein Dictionary mit Validierungsrelevanten Key/Value-Paaren, die so initialisiert übernommen wird. (default: Leeres Dictionary&lt;string,object&gt;>)</param>
        /// <param name="assemblies">Ein Array von den Assemblies, in welchen nach Validierungsregeln gesucht wird. (default: "CallingAssembly")</param>
        public ValidationCollection(TValidatedObject validatedObject, IEnumerable<Type> types, Dictionary<string, object> settings, [Optional] IEnumerable<Assembly> assemblies)
        {
            _validatedObject = validatedObject;
            _validationEnvironmentSettings = settings;

            if (assemblies != null)
            {
                _validationAssemblies = assemblies.ToArray();
                _validationTypes = new List<Type>();
                foreach (var type in types)
                {
                    if (type == typeof(ValidationClassAttribute)
                        || type.IsSubclassOf(typeof(ValidationClassAttribute)))
                    {
                        _validationTypes.Add(type);
                    }
                    else
                    {
                        throw new InvalidValidationTypeException(type);
                    }
                }
                _validations = new Dictionary<Type, ValidationBase<TValidatedObject>>();
                GetValidationClasses().ToList().ForEach(AddValidationToCollection);
            }
            else
            {
                types.ToList().ForEach(AddValidationToCollection);
            }
        }

        #endregion

        /// <summary>
        /// Gibt das Dictionary&lt;Type, ValidationBase&lt;TValidatedObject&gt;&gt; zurück, 
        /// in welchem alle Typ-zu-TypInstanz Mappings enthalten sind
        /// </summary>
        /// <returns></returns>
        public Dictionary<Type, ValidationBase<TValidatedObject>> GetAll() => _validations;

        /// <summary>
        /// Gibt das instanziierte Objekt einer Validierung aus der ValidationCollection zurück
        /// </summary>
        /// <typeparam name="TValidationType">der Typ der Validierung für welche das instanziierte Objekt erwartet wird</typeparam>
        /// <returns>das instanziierte Objekt vom Typ '<typeparamref name="TValidatedObject">type</typeparamref>'</returns>
        public ValidationBase<TValidatedObject> GetValidationByType<TValidationType>() => GetValidationByType(typeof(TValidationType));

        /// <summary>
        /// Gibt das instanziierte Objekt einer Validierung aus der ValidationCollection zurück
        /// </summary>
        /// <param name="type">der Typ der Validierung für welche das instanziierte Objekt erwartet wird</param>
        /// <returns>das instanziierte Objekt vom Typ '<paramref name="type">type</paramref>'</returns>
        public ValidationBase<TValidatedObject> GetValidationByType(Type type)
        {
            if (_validations.ContainsKey(type))
            {
                return _validations[type];
            }
            return null;
        }

        /// <summary>
        /// Gibt ein IEnumerable&lt;ValidationBase&lt;TValidatedObject&gt;&gt;> zurück, deren Typ(en) beim Aufruf 
        /// der Methode übergeben wurde(n) und deren instanziierte Objekte enthält
        /// </summary>
        /// <param name="types">1 - n Validierungs-Typen, deren instanziierte Objekte erwarted werden</param>
        /// <returns></returns>
        public IEnumerable<ValidationBase<TValidatedObject>> GetValidationsByTypes(params Type[] types) => from item in _validations where types.Contains(item.Key) select item.Value;

        /// <summary>
        ///     <para>
        ///         Gibt ein IEnumerable&lt;ValidationBase&lt;TValidatedObject&gt;&gt;> zurück, deren Typ(en) beim Aufruf 
        ///         der Methode übergeben wurde(n) und deren instanziierte Objekte enthält
        ///     </para>
        ///     <para>
        ///         WICHTIG: Beinhaltet zusätzlich alle instanziierten Validierungsregeln, die als "PreConstraints" der 
        ///         übergebenen Typen definiert wurden
        ///     </para>
        /// </summary>
        /// <param name="types">1 - n Validierungs-Typen, deren instanziierte Objekte erwarted werden</param>
        /// <returns></returns>
        public IEnumerable<ValidationBase<TValidatedObject>> GetPreConstraintTypes(params Type[] types)
        {
            var result = new List<ValidationBase<TValidatedObject>>();

            foreach (var item in _validations)
            {
                if (types.Contains(item.Key))
                {
                    result.Add(item.Value);
                    result.AddRange(GetPreConstraintTypes(item.Value.PreConstraints.ToArray()));
                }
            }

            return result.Distinct();
        }

        #region ValidationClass Identifiers
        /// <summary>
        /// Erlaubt das nachträgliche Hinzufügen von PreConstraint-Validierungen zur ValidationCollection
        /// </summary>
        /// <param name="constraintType">Typ der hinzuzufügenden Validierung</param>
        public void PostRegisterPreConstraintType(Type constraintType)
        {
            AddValidationToCollection(constraintType);
        }

        /// <summary>
        /// Erzeugt zum übergebenen Validierungstyp ein instanziiertes Validierungsobjekt und fügt 
        /// dieses zu der ValidationCollection hinzu.
        /// </summary>
        /// <param name="constraintType">Typ der hinzuzufügenden Validierung</param>
        private void AddValidationToCollection(Type constraintType)
        {
            if (GetValidationByType(constraintType) != null) return;

            try
            {
                var constructorInfo =
                    constraintType.GetConstructor(new Type[]
                        {
                            typeof (TValidatedObject), typeof (Dictionary<string, object>),
                            typeof (ValidationCollection<TValidatedObject>)
                        });
                if (constructorInfo != null)
                {
                    _validations.Add(constraintType,
                                     (ValidationBase<TValidatedObject>)
                                     constructorInfo.Invoke(new object[]
                                         {_validatedObject, _validationEnvironmentSettings, this}));
                }
            }
            catch (Exception e)
            {
                throw new MissingConstructorInValidationException(constraintType, e);
            }
        }

        /// <summary>
        /// Sucht alle Validierungsklassen aus allen dazu angegebenen Assemblies, filtert nur diejenigen 
        /// heraus die mit den geforderten ValidierungsClassAttribut-SubKlassen attributiert sind und 
        /// gibt diese als IEnumerable&lt;Type&gt; zurück.
        /// </summary>
        /// <returns>IEnumberable&lt;Type&gt;, welches alle Validierungsklassen enthält die mit einer
        /// SubKlasse des ValidationClassAttributs attributiert sind</returns>
        private IEnumerable<Type> GetValidationClasses()
        {
            List<Type> all = new List<Type>();

            foreach (var assembly in _validationAssemblies)
            {

                var x = assembly.GetTypes();
                foreach (var type in _validationTypes)
                {
                    Type type1 = type;
                    var y = x.Where(t => t.GetCustomAttributes(type1, false).Any());
                    var z =
                        y.Where(
                            t =>
                            t.GetConstructor(new []
                                {
                                    typeof(TValidatedObject), 
                                    typeof (Dictionary<string, object>), 
                                    typeof (ValidationCollection<TValidatedObject>)
                                }) != null);
                    all.AddRange(z);
                }
            }
            return all.Distinct();
        }
        #endregion

    }
}