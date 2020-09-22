using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
    public class MemberList
    {
        private List<Member> _members;
        private string _registryPath = "Registry/MemberRegistry/MemberRegistry.json";

        public MemberList()
        {
            _members = GetMemberList();

        }
        private List<Member> GetMemberList()
        {
            using (StreamReader r = new StreamReader(_registryPath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Member>>(json);
            }
        }
        private void writeListToRegistry(List<Member> members)
        {
            var j = JsonConvert.SerializeObject(members, Formatting.Indented);
            File.WriteAllText(_registryPath, j);
        }
        public void Add(Member member) 
        {
            _members.Add(member);
        }

        public override string ToString() => string.Join("\n", _members);
    }
}