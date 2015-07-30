using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IG.Validations
{
    public class ValidationResult
    {
        public ValidationStatus Status => Messages.Any(x => x.MessageType > MessageType.Warning) ? ValidationStatus.NotOk : ValidationStatus.Ok;

        private readonly List<ValidationMessage> _messages;

        public List<ValidationMessage> Messages => _messages;

        public ValidationResult()
        {
            _messages = new List<ValidationMessage>();
        }

        public static ValidationResult Create() => new ValidationResult();


        public void AddMessages(Expression<Func<string>> errorResource, MessageType messageType, string[] sources, params object[] formatArgs)
        {
            MemberExpression member = errorResource.Body as MemberExpression;
            if (member != null)
            {
                var prop = member.Member as PropertyInfo;
                if (prop != null)
                {
                    var errorMessage = prop.GetValue(null) as string;

                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        var formatStringChecker = new Regex(@"{/d}");

                        if (formatStringChecker.IsMatch(errorMessage) && formatArgs.Any())
                        {
                            errorMessage = string.Format(errorMessage, formatArgs);
                        }

                        _messages.Add(
                            new ValidationMessage
                            {
                                Message = errorMessage,
                                MessageType = messageType,
                                Source = string.Join(", ", sources),
                                
                            }
                            );
                    }
                }
                
            }

        }
    }

    public enum ValidationStatus
    {
        Ok,
        NotOk,
    }



}