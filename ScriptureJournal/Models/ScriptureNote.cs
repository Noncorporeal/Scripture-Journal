using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace ScriptureJournal.Models
{
    public class ScriptureNote
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string Note { get; set; } = string.Empty;
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            try
            {
                return enumValue.GetType()
                                .GetMember(enumValue.ToString())
                                .First()
                                .GetCustomAttribute<DisplayAttribute>()
                                .GetName();
            }
            catch (Exception e)
            {
                return enumValue.ToString();
            }
        }
    }

    public enum Book
    {
        Genesis,
        Exodus,
        Leviticus,
        Numbers,
        Deuteronomy,
        Joshua,
        Judges,
        Ruth,
        [Display(Name = "1 Samuel")]
        Samuel1,
        [Display(Name = "2 Samuel")]
        Samuel2,
        [Display(Name = "1 Kings")]
        Kings1,
        [Display(Name = "2 Kings")]
        Kings2,
        [Display(Name = "1 Chronicles")]
        Chronicles1,
        [Display(Name = "2 Chronicles")]
        Chronicles2,
        Ezra,
        Nehemiah,
        Esther,
        Job,
        Psalms,
        Proverbs,
        Ecclesiastes,
        [Display(Name = "Songs of Solomon")]
        SongSolomon,
        Isaiah,
        Jeremiah,
        Lamentations,
        Ezekiel,
        Daniel,
        Hosea,
        Joel,
        Amos,
        Obadiah,
        Jonah,
        Micah,
        Nahum,
        Habakkuk,
        Zephaniah,
        Haggai,
        Zechariah,
        Malachi,
        Matthew,
        Mark,
        Luke,
        John,
        Acts,
        Romans,
        [Display(Name = "1 Corinthians")]
        Corinthians1,
        [Display(Name = "2 Corinthians")]
        Corinthians2,
        Galatians,
        Ephesians,
        Philippians,
        Colossians,
        [Display(Name = "1 Thessalonians")]
        Thessalonians1,
        [Display(Name = "2 Thessalonians")]
        Thessalonians2,
        [Display(Name = "1 Timothy")]
        Timothy1,
        [Display(Name = "2 Timothy")]
        Timothy2,
        Titus,
        Philemon,
        Hebrews,
        James,
        [Display(Name = "1 Peter")]
        Peter1,
        [Display(Name = "2 Peter")]
        Peter2,
        [Display(Name = "1 John")]
        John1,
        [Display(Name = "2 John")]
        John2,
        [Display(Name = "3 John")]
        John3,
        Jude,
        Revelation,
        [Display(Name = "1 Nephi")]
        Nephi1,
        [Display(Name = "2 Nephi")]
        Nephi2,
        Jacob,
        Enos,
        Jarom,
        Omni,
        [Display(Name = "Words of Mormon")]
        WordsOfMormon,
        Mosiah,
        Alma,
        Helaman,
        [Display(Name = "3 Nephi")]
        Nephi3,
        [Display(Name = "4 Nephi")]
        Nephi4,
        Mormon,
        Ether,
        Moroni,
    }

}