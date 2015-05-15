using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IG.Validations
{
    public static class Extensions
    {
        public static IEnumerable<ValidationMessage> CreateMessages(this Exception e)
        {
            return e.CreateMessages(null, null);
        }

        public static IEnumerable<ValidationMessage> CreateMessages(this Exception e, IEnumerable<string> sources)
        {
            return e.CreateMessages(null, sources);
        }

        public static IEnumerable<ValidationMessage> CreateMessages(this Exception e, int? messageId)
        {
            return e.CreateMessages(messageId, null);
        }

        public static IEnumerable<ValidationMessage> CreateMessages(this Exception e, int? messageId, IEnumerable<string> sources)
        {
            var enumerable = sources as IList<string> ?? sources.ToList();
            if (sources == null || enumerable.All(string.IsNullOrWhiteSpace))
            {
                sources = new List<string>();
            }
            if (!messageId.HasValue)
            {
                messageId = 9999;
            }
            var messages = e.GetJoinedExceptionMessages(null);
          
            return messages.Select(item => CreateMessage(item.Key, messageId.Value, CreateSources(item, enumerable.Where(x => !string.IsNullOrWhiteSpace(x))), MessageType.Exception));
        }

        private static ValidationMessage CreateMessage(string message, int messageId, IEnumerable<string> sources,
            MessageType messageType)
        {
            return new ValidationMessage
            {
                Message = message,
                MessageId = messageId,
                MessageType = messageType,
                Source = string.Join(", ", sources)
            };
        }

        private static IEnumerable<string> CreateSources(KeyValuePair<string, Tuple<string, string, string>> item, IEnumerable<string> sources)
        {
            var result = new[] { string.Format(CultureInfo.InvariantCulture, "Source: {0} ==> Type: {2} ==>> StackTrace: {1}", item.Value.Item1, item.Value.Item2, item.Value.Item3) };

            var enumerable = sources as IList<string> ?? sources.ToList();
            if (sources != null && enumerable.Any())
            {
                result.ToList().AddRange(enumerable);
            }

            return result;
        }

        private static Dictionary<string, Tuple<string, string, string>> GetJoinedExceptionMessages(this Exception e, Dictionary<string, Tuple<string, string, string>> messages)
        {
            if (messages == null)
            {
                messages = new Dictionary<string, Tuple<string, string, string>>();
            }

            if (e == null)
            {
                return messages;
            }

            messages.Add(e.Message, new Tuple<string, string, string>(e.Source, e.StackTrace, e.GetType().FullName));

            if (e.InnerException == null)
            {
                return messages;
            }

            return e.InnerException.GetJoinedExceptionMessages(messages);
        }



        /// <summary>
        /// Fügt einem Status eine Menge von CT_Meldungen hinzu
        /// </summary>
        /// <param name="result">Status an den die Meldung hinzugefügt werden</param>
        /// <param name="messages">Liste der Meldungen</param>
        public static void AddMessages(this ValidationResult result, params ValidationMessage[] messages)
        {
            AddMessages(result, messages, false);
        }

        /// <summary>
        /// Fügt einem Status eine Menge von CT_Meldungen hinzu
        /// </summary>
        /// <param name="result">Status an den die Meldung hinzugefügt werden</param>
        /// <param name="skipLog">True wird dann nicht geloggt in Entlib</param>
        /// <param name="messages">Liste der Meldungen</param>
        public static void AddMessages(this ValidationResult result, bool skipLog, params ValidationMessage[] messages)
        {
            AddMessages(result, messages, skipLog);
        }

        /// <summary>
        /// Fügt einem Status eine Menge von CT_Meldungen hinzu
        /// </summary>
        /// <param name="result">Status an den die Meldung hinzugefügt werden</param>
        /// <param name="messages">Liste der Meldungen</param>
        /// <param name="skipLog">True wird dann nicht geloggt in Entlib</param>
        public static void AddMessages(this ValidationResult result, ValidationMessage[] messages, bool skipLog)
        {
            messages.ToList().ForEach(x =>
            {
                if (!skipLog)
                {
                    // TODO LogCtMeldung(x);
                }
                result.Messages.Add(x);
            });
        }

    }
}
