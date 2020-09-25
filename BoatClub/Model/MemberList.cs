using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Model
{
    public class MemberList
    {
        private List<Member> _members;
        private string _registryPath = "Registry/MemberRegistry/MemberRegistry.json";

        public List<Member> All 
        {
            get => _members;
        }

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

        public List<string> GetVerboseList()
        {
            List<Member> members = GetMemberList();
            List<string> verboseMembers = new List<string>();
            foreach (Member member in members)
            {
                verboseMembers.Add(member.ToString("verbose"));
            }

            return verboseMembers;
        }
        private void WriteListToRegistry(List<Member> members)
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