using System.ComponentModel.DataAnnotations;

namespace IG.SettingsReaders
{
    public class AppSetting
    {
        [Required, StringLength(100)]
        public string Key { get; set; }

        [Required, StringLength(250)]
        public string Value { get; set; }
    }
}
