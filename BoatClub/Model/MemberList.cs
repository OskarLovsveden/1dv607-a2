using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
// using Newtonsoft.Json;

namespace Model
{
    public class MemberList
    {
        private List<Member> _members = new List<Member>();

        public MemberList()
        {
            PersonalID pid = new PersonalID("891126-5555");
            Member m = new Member("John", "789", pid);
            Member p = new Member("Patty", "888", pid);
            writeMemberToDirectory(m);
            writeMemberToDirectory(p);
            // _members = GetMembersFromDirectory();
        }
        private void writeMemberToDirectory(Member member)
        {
            string jsonString = JsonSerializer.Serialize(member);
            // File.AppendText("Registry/MemberRegistry/MemberRegistry.json", jsonString);

            // TODO: Recomended code from forums on internet, seems mor complicated that the code above tho.
            // JsonSerializer serializer = new JsonSerializer();
            // using (StreamWriter sw = new StreamWriter("Registry/MemberRegistry/MemberRegistry.json"))
            // using (JsonWriter writer = new JsonTextWriter(sw))
            // {
            //     //TODO: Check that code works
            //     serializer.Serialize(writer, member);
            // }

        }
        public void Add(Member member)
        {
            _members.Add(member);
        }
        // private  List<T> GetMembersFromDirectory()
        // {

        // }
        public override string ToString() => string.Join("\n", _members);
    }
}