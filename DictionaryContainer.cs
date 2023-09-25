using System.Collections.Generic;

namespace Assets.Scripts.Saving_System
{
    internal class DictionaryContainer
    {
        public List<int> Keys;
        public List<string> Values;
        public DictionaryContainer(Dictionary<int, string> dictionary)
        {
            Keys = new List<int>(dictionary.Keys);
            Values = new List<string>(dictionary.Values);
        }

        public Dictionary<int, string> ToDictionary()
        {
            var dict = new Dictionary<int, string>();
            for (int i = 0; i < Keys.Count; i++)
            {
                dict.Add(Keys[i], Values[i]);
            }
            return dict;
        }
    }
}